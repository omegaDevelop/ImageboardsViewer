
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageboardsViewer
{
    //Todo отвалилась загрузка тегов по клику на превьюгшки
    //todo определитья как грузить теги при фулках
    //TODO: запилить поддрежку видосиков
    //TODO: заебывает перекидывать теги поодному
    //TODO: избавиться от магических переменных
    //TODO: сделать возможность загружать другие списки фильтров
    //TODO: добавитиь возможность перезагрузить веса и категории в таблице для всех тэгов
    //TODO: добавить функцию сохранения последнего состояния программы(тег страница)
    //TODO: добавить блэклист
    //TODO: заменить режимы зума у фуллки на просто щелчёк и увеличение

    struct SearchRequest
    {
        public string tag;
        public int pageIndex;
        public SearchRequest(string tag, int pageIndex)
        {
            this.tag = tag;
            this.pageIndex = pageIndex;
        }
    }

    public partial class MainForm : Form
    {
        private int lastX, lastY, lastSizeW = 0, lastSizeH = 0;
        private bool tabOpened;
        private const int IMAGES_COUNT_ON_PAGE = 42;
        private TbibParser tbibParser;
        private Stack<SearchRequest> searchHistory;
        private string lastSavePath = Directory.GetCurrentDirectory() + "\\tbib";
        private int sortedDGVTagsColumnIndex = 0;
        private ListSortDirection listSortDirection = ListSortDirection.Descending;
        private Rectangle sS = Screen.PrimaryScreen.Bounds;
        private ToolStripDropDown dropDown = new ToolStripDropDown();
        private Panel panelFull;
        private PictureBox pictureBoxFull;
        private int fullImageIndex = -1;
        public MainForm()
        {
            InitializeComponent();
            ///////////////
            panelFull = new Panel
            {
                BackColor = Color.LightPink,
                Location = new Point(0, 0),
                AutoScroll = true
            };
            panelFull.MouseClick += delegate (object lol, MouseEventArgs ex)
            {
                if (ex.Button == MouseButtons.Left)
                {
                    if (tabOpened)
                    {
                        tabControl.Location = new Point(Width - 40, 0);
                        tabOpened = false;
                    }
                }
            };
            Controls.Add(panelFull);
            pictureBoxFull = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Thistle
            };
            pictureBoxFull.MouseMove += delegate (object sendera, MouseEventArgs em)
            {
                if (em.Button == MouseButtons.Left && pictureBoxFull.SizeMode == PictureBoxSizeMode.StretchImage)
                {
                    int xInc = panelFull.HorizontalScroll.Value + em.X - lastX;
                    if (xInc < 0)
                    {
                        panelFull.HorizontalScroll.Value = 0;
                    }
                    else if (xInc > panelFull.HorizontalScroll.Maximum)
                    {
                        panelFull.HorizontalScroll.Value = panelFull.HorizontalScroll.Maximum;
                    }
                    else
                    {
                        panelFull.HorizontalScroll.Value += (em.X - lastX);
                    }
                    int yInc = panelFull.VerticalScroll.Value + em.Y - lastY;
                    if (yInc < 0)
                    {
                        panelFull.VerticalScroll.Value = 0;
                    }
                    else if (yInc > panelFull.VerticalScroll.Maximum)
                    {
                        panelFull.VerticalScroll.Value = panelFull.VerticalScroll.Maximum;
                    }
                    else
                    {
                        panelFull.VerticalScroll.Value += (em.Y - lastY);
                    }
                }
                lastX = em.X;
                lastY = em.Y;
            };
            pictureBoxFull.MouseClick += delegate (object senderb, MouseEventArgs en)
            {
                if (en.Button == MouseButtons.Right)
                {
                    pictureBoxFull.Dispose();
                    panelFull.Hide();
                    flowLayoutPanel.Visible = true;
                }
                if (en.Button == MouseButtons.Left)
                {
                    if (tabOpened)
                    {
                        tabControl.Location = new Point(Width - 40, 0);
                        tabOpened = false;
                    }
                }
            };
            pictureBoxFull.MouseDown += delegate (object sendera, MouseEventArgs esn)
            {
                if (esn.Button == MouseButtons.Middle)
                {
                    lastSizeW = ((PictureBox)sendera).Width;
                    lastSizeH = ((PictureBox)sendera).Height;
                    //картинка шире
                    if (((PictureBox)sendera).Width - panelFull.Width > ((PictureBox)sendera).Height - panelFull.Height)
                    {
                        int height = (int)(panelFull.Width * (((PictureBox)sendera).Height * 1.0 / ((PictureBox)sendera).Width));
                        pictureBoxFull.Size = new Size(panelFull.Width, height);
                    }
                    //картинка длиннее
                    else
                    {
                        int width = (int)(panelFull.Height * (((PictureBox)sendera).Width * 1.0 / ((PictureBox)sendera).Height));
                        pictureBoxFull.Size = new Size(width, panelFull.Height);
                    }
                }
            };
            pictureBoxFull.MouseUp += delegate (object senderb, MouseEventArgs en)
            {
                if (en.Button == MouseButtons.Middle)
                {
                    pictureBoxFull.Size = new Size(lastSizeW, lastSizeH);
                }
            };
            pictureBoxFull.DoubleClick += delegate (object senderb, EventArgs en)
            {
                if (((MouseEventArgs)en).Location.X > panelFull.Width / 2)
                {
                    if (fullImageIndex - 1 < 42)
                    {
                        fullImageIndex++;
                        LoadFullImage();
                    }
                    else
                    {
                        LoadTumbImagesToPicBoxes(PageDirection.next, true);
                        //todo перекидывает на др страницу
                    }
                }
                else
                {
                    if (fullImageIndex - 1 >= 0)
                    {
                        fullImageIndex--;
                        LoadFullImage();
                    }
                    else
                    {
                        LoadTumbImagesToPicBoxes(PageDirection.back, true);
                        //todo перекидывает на др страницу
                    }
                }
            };
            panelFull.Controls.Add(pictureBoxFull);
            //////////////
            tsDropDownButton.DropDown = dropDown;
            LoadProxysFromTXT();
            flowLayoutPanel.Parent = this;
            WindowState = FormWindowState.Maximized; //максимизировал окно
            tbibParser = new TbibParser(true); //запускаю парсер
            searchHistory = new Stack<SearchRequest>(); //открываю стек истории
            DirectoryInfo directoryInfo = new DirectoryInfo("tbib"); //создаю папку если не создана
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            //Всплывающее меню для тэгов
            contextMenuStripTags.Items[0].Click += new EventHandler(MenuItemFindTag_Click);
            contextMenuStripTags.Items[1].Click += new EventHandler(MenuItemCreateFolderWithTagName_Click);
            contextMenuStripTags.Items[2].Click += new EventHandler(MenuItemAddSelectedTagToList_Click);
            //Всплывающее меню для списков авторов и категорий
            contextMenuStripListArtists.Items[0].Click += new EventHandler(MenuItemOpenArtistFromList_Click);
            contextMenuStripListArtists.Items[1].Click += new EventHandler(MenuItemDeleteTagFromList_Click);
            (contextMenuStripListArtists.Items[2] as ToolStripDropDownItem).DropDownItems[0].Click += new EventHandler(MenuItemDownloadAllTagImages_Click);
            contextMenuStripListArtists.Items[3].Click += new EventHandler(MenuItemSendTagToOtherList_Click);

            dgvCatTags.DataSource = SQLiteDBManager.GetTags(TableName.categories); //загружаю теги из бд
            dgvArtistsTags.DataSource = SQLiteDBManager.GetTags(TableName.artists);
            //сортировка
            void DGVTags_ColumnSortModeChanged(object o, DataGridViewCellMouseEventArgs ea)
            {
                if (listSortDirection.Equals(System.ComponentModel.ListSortDirection.Ascending)) listSortDirection = System.ComponentModel.ListSortDirection.Descending;
                else listSortDirection = System.ComponentModel.ListSortDirection.Ascending;
                sortedDGVTagsColumnIndex = ea.ColumnIndex;
            };
            dgvCatTags.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(DGVTags_ColumnSortModeChanged);
            dgvArtistsTags.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(DGVTags_ColumnSortModeChanged);
            LoadTumbImagesToPicBoxes(PageDirection.first, true);
        }

        List<Thread> picsLoadThreads = new List<Thread>();
        private void LoadTumbImagesToPicBoxes(PageDirection pageDirection, bool resetPanelScroll)
        {
            // if (tssProgressBar.Value >= tssProgressBar.Maximum)
            {
                //получаю ссылки 2.7 сек
                tbibParser.LoadPageImagesFromWeb(textBoxSearch.Text, pageDirection, (DataTable)dgvCatTags.DataSource);
                if (tbibParser.GetImagesCount() < 1)
                {
                    if (checkBoxFiltrate.Checked)
                    {
                        dgvLogs.Rows.Add(new[] { DateTime.Now.ToString(), "По тегу: \"" + textBoxSearch.Text + "\" нет уникальных изображений" });
                    }
                    else
                    {
                        dgvLogs.Rows.Add(new[] { DateTime.Now.ToString(), "По тегу: \"" + textBoxSearch.Text + "\" не найдено изображений" });
                    }
                }
                //гружу сами картинки  16 сек
                flowLayoutPanel.Controls.Clear();
                tssProgressBar.Value = 0;
                tssProgressBar.Maximum = tbibParser.GetImagesCount();

                //загрузка картинок
                if (picsLoadThreads != null && picsLoadThreads.Count != 0)
                {
                    for (int i = 0; i < picsLoadThreads.Count; i++)
                    {
                        if (picsLoadThreads[i].ThreadState != System.Threading.ThreadState.Stopped)
                        {
                            picsLoadThreads[i].Abort();
                        }
                        picsLoadThreads.RemoveAt(i);
                    }
                }
                else
                {
                    picsLoadThreads = new List<Thread>();
                }
                int scaleValue = trackBarTumbScale.Value;
                for (int i = 0; i < tbibParser.GetImagesCount(); i++)
                {
                    PictureBox pictureBoxThumb = new PictureBox
                    {
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BackColor = Color.Thistle,
                        Name = i.ToString()
                    };
                    picsLoadThreads.Add(new Thread(() =>
                    {
                        HTMLDownloader.LoadThumbImageByUrlThread(tbibParser.GetImageThumbUrl(i), pictureBoxThumb, tssLabelNetSpeed, tssProgressBar, scaleValue);
                    }));
                    picsLoadThreads[picsLoadThreads.Count - 1].Start();
                    //событие открфыть фул
                    pictureBoxThumb.DoubleClick += GetFullImageByIndex;
                    flowLayoutPanel.Controls.Add(pictureBoxThumb);
                }
                //TODO: оптимизировать всю хуйню со строкками во всём коде
                tssLabelPageIndex.Text = tbibParser.Padeindex.ToString();
                tssLabelPageCount.Text = tbibParser.PageCount.ToString();  //19 сек
            }
        }

        void GetFullImageByIndex(object sender, EventArgs e)
        {
            fullImageIndex = Convert.ToInt32(((PictureBox)sender).Name);
            LoadFullImage();
        }

        void LoadFullImage()
        {
            pictureBoxFull.Image = pictureBoxFull.InitialImage;
            ToolStripStatusLabel tssLabelDownloadPage = new ToolStripStatusLabel("Загрузка картинки №" + fullImageIndex);
            dropDown.Items.Add(tssLabelDownloadPage);
            tsDropDownButton.ShowDropDown();

            picsLoadThreads.Add(new Thread(() =>
            {
                HTMLDownloader.LoadFullImageByUrlThread(tbibParser.GetImageUrl(fullImageIndex), pictureBoxFull, tssLabelNetSpeed, panelFull, flowLayoutPanel, dropDown);
            }));
            picsLoadThreads[picsLoadThreads.Count - 1].Start();
        }


        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (tbibParser.Padeindex + 42 <= tbibParser.PageCount)
            {
                LoadTumbImagesToPicBoxes(PageDirection.next, true); //гружу следующую страницу
            }
        }

        private void ButtonPrev_Click(object sender, EventArgs e)
        {
            if (tbibParser.Padeindex - 42 > -1)
            {
                LoadTumbImagesToPicBoxes(PageDirection.back, true);//гружу предыдущую страницу
            }
        }

        //событие клик по тэгу в списке слева
        private void DataGridViewAuthorTags_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1) contextMenuStripTags.Show(Cursor.Position);

        }

        //создать папку с названием выбранного тега в списке слева
        private void MenuItemCreateFolderWithTagName_Click(object sender, EventArgs e)
        {
            String tagName = "tbib\\" + dgvCurrentImageTags.SelectedCells[0].Value.ToString();
            if (!Directory.Exists(tagName)) Directory.CreateDirectory(tagName);
        }

        //добавить выбранный в списке слева тэг в список справа
        private void MenuItemAddSelectedTagToList_Click(object sender, EventArgs e)
        {
            string tagName = dgvCurrentImageTags.CurrentRow.Cells[0].Value.ToString();
            string tagCategory = dgvCurrentImageTags.CurrentRow.Cells[1].Value.ToString();
            string tagWeight = dgvCurrentImageTags.CurrentRow.Cells[2].Value.ToString();
            if (tabControl.SelectedIndex == 1) //теги категорий
            {
                SQLiteDBManager.AddTag(tagName, tagCategory, tagWeight, TableName.categories);
                dgvCatTags.DataSource = SQLiteDBManager.GetTags(TableName.categories);
            }
            else
            {
                SQLiteDBManager.AddTag(tagName, tagCategory, tagWeight, TableName.artists);
                dgvArtistsTags.DataSource = SQLiteDBManager.GetTags(TableName.artists);
            }
            if (checkBoxFiltrate.Checked)
            {
                LoadTumbImagesToPicBoxes(PageDirection.current, false);
            }
        }

        //найти картинки по выбранному тэгу из списка слева
        private void MenuItemFindTag_Click(object sender, EventArgs e)
        {
            String tagName = dgvCurrentImageTags.SelectedCells[0].Value.ToString();
            searchHistory.Push(new SearchRequest(textBoxSearch.Text, tbibParser.Padeindex)); //добавил предыдущий поисковый запрос в стек
            textBoxSearch.Text = tagName;
            LoadTumbImagesToPicBoxes(PageDirection.first, true);
        }

        //открыть меню для списка справа
        private void DataGridViewArtists_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) contextMenuStripListArtists.Show(Cursor.Position);
        }

        //найти картинки по выбранному тэгу из списка справа
        private void MenuItemOpenArtistFromList_Click(object sender, EventArgs e)
        {
            String tagName = (string)dgvCatTags.CurrentRow.Cells[0].Value;
            searchHistory.Push(new SearchRequest(textBoxSearch.Text, tbibParser.Padeindex)); //добавил предыдущий поисковый запрос в стек
            textBoxSearch.Text = tagName;
            LoadTumbImagesToPicBoxes(PageDirection.first, true);
            contextMenuStripListArtists.Hide();
        }

        //удалить тэг из списка справа
        private void MenuItemDeleteTagFromList_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 1) //теги категорий
            {
                string tagName = dgvCatTags.CurrentRow.Cells[0].Value.ToString();
                SQLiteDBManager.RemoveTag(TableName.categories, tagName);
                dgvCatTags.DataSource = SQLiteDBManager.GetTags(TableName.categories);
            }
            else
            {
                string tagName = dgvArtistsTags.CurrentRow.Cells[0].Value.ToString();
                SQLiteDBManager.RemoveTag(TableName.artists, tagName);
                dgvArtistsTags.DataSource = SQLiteDBManager.GetTags(TableName.artists);
            }
            if (checkBoxFiltrate.Checked)
            {
                LoadTumbImagesToPicBoxes(PageDirection.current, false);
            }
            contextMenuStripListArtists.Hide();
        }

        //скачать все картинки по выбраннрому тэгу из списка справа
        private void MenuItemDownloadAllTagImages_Click(object sender, EventArgs e)
        {
            int startIndex = Convert.ToInt32((contextMenuStripListArtists.Items[2] as ToolStripDropDownItem).DropDownItems[1].Text);
            string tag = (string)dgvCatTags.CurrentRow.Cells[0].Value;
            DownloadAllTagImagesForm downloadAllTagImages = new DownloadAllTagImagesForm(tag, startIndex);
            downloadAllTagImages.Show();
            this.Focus();
            /* panel1.VerticalScroll.Value = panelScrollValue;
             panel1.PerformLayout();*/
        }

        //перекинуть картинки из текущего списка в другой
        private void MenuItemSendTagToOtherList_Click(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 1: //теги категорий
                    string tagName = dgvCatTags.CurrentRow.Cells[0].Value.ToString();
                    string tagCategory = dgvCatTags.CurrentRow.Cells[1].Value.ToString();
                    string tagWeight = dgvCatTags.CurrentRow.Cells[2].Value.ToString();
                    SQLiteDBManager.AddTag(tagName, tagCategory, tagWeight, TableName.categories);
                    SQLiteDBManager.RemoveTag(TableName.artists, tagName);
                    int index = dgvCatTags.FirstDisplayedScrollingRowIndex;
                    dgvCatTags.DataSource = SQLiteDBManager.GetTags(TableName.categories);
                    dgvCatTags.Sort(dgvCatTags.Columns[sortedDGVTagsColumnIndex], listSortDirection);
                    dgvArtistsTags.DataSource = SQLiteDBManager.GetTags(TableName.artists);
                    dgvArtistsTags.Sort(dgvArtistsTags.Columns[sortedDGVTagsColumnIndex], listSortDirection);

                    dgvCatTags.FirstDisplayedScrollingRowIndex = index;
                    break;
                case 2: //теги артистов
                    tagName = dgvArtistsTags.CurrentRow.Cells[0].Value.ToString();
                    tagCategory = dgvArtistsTags.CurrentRow.Cells[1].Value.ToString();
                    tagWeight = dgvArtistsTags.CurrentRow.Cells[2].Value.ToString();
                    SQLiteDBManager.AddTag(tagName, tagCategory, tagWeight, TableName.artists);
                    SQLiteDBManager.RemoveTag(TableName.categories, tagName);
                    index = dgvArtistsTags.FirstDisplayedScrollingRowIndex;
                    dgvCatTags.DataSource = SQLiteDBManager.GetTags(TableName.categories);
                    dgvCatTags.Sort(dgvCatTags.Columns[sortedDGVTagsColumnIndex], listSortDirection);
                    dgvArtistsTags.DataSource = SQLiteDBManager.GetTags(TableName.artists);
                    dgvArtistsTags.Sort(dgvArtistsTags.Columns[sortedDGVTagsColumnIndex], listSortDirection);
                    dgvArtistsTags.FirstDisplayedScrollingRowIndex = index;
                    break;
            }
            if (checkBoxFiltrate.Checked)
            {
                LoadTumbImagesToPicBoxes(PageDirection.current, false);
            }
            contextMenuStripListArtists.Hide();
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            if (searchHistory.Count > 0)
            {
                SearchRequest s = searchHistory.Pop();
                textBoxSearch.Text = s.tag;
                tbibParser.Padeindex = s.pageIndex;
                LoadTumbImagesToPicBoxes(PageDirection.current, true);
            }
            else MessageBox.Show("Нет запросов в истории");
        }

        //при изменении номера страницы
        private void TextBoxPageIndex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && Convert.ToInt32(tssLabelPageIndex.Text) <= tbibParser.PageCount)
            {
                tbibParser.Padeindex = Convert.ToInt32(tssLabelPageIndex.Text);
                LoadTumbImagesToPicBoxes(PageDirection.current, true);
            }
        }

        //исключить/включить теги в списке из/в поиска
        private void FiltrateMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (tbibParser.FiltrateArtist)
            {
                checkBoxFiltrate.BackColor = Color.Gray;
                checkBoxFiltrate.Text = "Filtrate Off";
            }
            else
            {
                checkBoxFiltrate.BackColor = Color.Lime;
                checkBoxFiltrate.Text = "Filtrate On";
            }
            tbibParser.FiltrateArtist = !tbibParser.FiltrateArtist;
            LoadTumbImagesToPicBoxes(PageDirection.current, false);
        }

        //перед закрытием программы
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SQLiteDBManager.CloseDB();
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (flowLayoutPanel.Visible == true)
                    {
                        if (tbibParser.Padeindex + 42 <= tbibParser.PageCount) LoadTumbImagesToPicBoxes(PageDirection.next, true); //гружу следующую страницу
                    }
                    else
                    {

                    }
                    break;
                case Keys.Left:
                    if (tbibParser.Padeindex - 42 > -1) LoadTumbImagesToPicBoxes(PageDirection.back, true); //гружу предыдущую страницу;
                    break;
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            //pictureBoxFull 548; 329
            const int HEIGHT_SPACE = 64, BUTTON_SPACE = 37; //отступ снизу и сверху
            flowLayoutPanel.Size = new Size(Width - 46, Height - HEIGHT_SPACE);
            panelFull.Size = new Size(Width - 46, Height - HEIGHT_SPACE);
            if (tabOpened)
            {
                tabControl.Location = new Point(Width - 415, 0);
            }
            else
            {
                tabControl.Location = new Point(Width - 40, 0);
            }
            tabControl.Height = Height - HEIGHT_SPACE;
            tabControlDB.Height = Height - HEIGHT_SPACE - 8;
            dgvCurrentImageTags.Height = Height - HEIGHT_SPACE - BUTTON_SPACE;
            dgvCatTags.Height = Height - HEIGHT_SPACE - BUTTON_SPACE;
            dgvArtistsTags.Height = Height - HEIGHT_SPACE - BUTTON_SPACE;
            dgvLogs.Height = Height - HEIGHT_SPACE;
            //panelSettings.Height = Height - HEIGHT_SPACE;
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            /* if (dgvCatTags.DataSource != null)
             {
                 LoadTumbImagesToPicBoxes(PageDirection.current, false);
             }*/
        }

        private void MainForm_MaximizedBoundsChanged(object sender, EventArgs e)
        {
            /*if (dgvCatTags.DataSource != null)
            {
                LoadTumbImagesToPicBoxes(PageDirection.current, false);
            }*/
        }

        private void TabControl1_Click(object sender, EventArgs e)
        {
            if (!tabOpened)
            {
                tabControl.Location = new Point(Width - 415, 0);
                tabOpened = true;
            }
        }

        private void Panel1_Click(object sender, EventArgs e)
        {
            if (tabOpened)
            {
                tabControl.Location = new Point(Width - 40, 0);
                tabOpened = false;
            }
        }

        private void ContextMenuStripTags_MouseLeave(object sender, EventArgs e)
        {
            contextMenuStripTags.Hide();
        }

        private void ContextMenuStripListArtists_MouseLeave(object sender, EventArgs e)
        {
            contextMenuStripListArtists.Hide();
        }

        private void toolStripContainer1_RightToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        //отпустил кнопку в поисковике
        private void TextBoxSearchedTags_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadTumbImagesToPicBoxes(PageDirection.first, true);
            }
        }

        private void MaskedTextBoxPageIndex_KeyUp(object sender, KeyEventArgs e)
        {
            int enterPageIndex = maskedTextBoxPageIndex.Text != "" ? Convert.ToInt32(maskedTextBoxPageIndex.Text) : 0;
            if (e.KeyCode == Keys.Enter && enterPageIndex < tbibParser.PageCount)
            {
                tbibParser.Padeindex = enterPageIndex;
                LoadTumbImagesToPicBoxes(PageDirection.current, true);
            }
        }

        private void LoadProxysFromTXT()
        {
            string path = Environment.CurrentDirectory + "/proxys.txt";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string[] s;
                    while (!sr.EndOfStream)
                    {
                        s = sr.ReadLine().Split(':');
                        dgvProxy.Rows.Add(s[0], s[1]);
                    }
                }
            }
        }
    }
}
