using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageboardsViewer
{
    //TODO: запилить поддрежку видосиков
    //TODO: заебывает перекидывать теги поодному
    //TODO: избавиться от магических переменных
    //TODO: сделать возможность загружать другие списки фильтров
    //TODO: при удалении одного повторяющегося тэга он удаляет все похожие из бд
    //TODO: добавитиь возможность перезагрузить веса и категории в таблице для всех тэгов
    //TODO: добавить функцию сохранения таблицы
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
        private int panelScrollValue;
        private const int IMAGES_COUNT_ON_PAGE = 42;
        private TableName currentTableName;
        private TbibParser tbibParser;
        private Stack<SearchRequest> searchHistory;
        private string lastSavePath = Directory.GetCurrentDirectory() + "\\tbib";
        private int sortedDGVTagsColumnIndex = 0;
        private System.ComponentModel.ListSortDirection listSortDirection = System.ComponentModel.ListSortDirection.Descending;
        private Rectangle sS = System.Windows.Forms.Screen.PrimaryScreen.Bounds;

        public MainForm()
        {
            InitializeComponent();
            int thisWidth = (int)(700), thisHeight = (int)(sS.Height / 1.607); //30 - ширина верхней шапки
            this.Width = thisWidth; this.Height = thisHeight;
            menuStrip1.Size = new Size(menuStrip1.Size.Width, thisHeight / 30);
            panel1.Size = new Size((int)(thisWidth * 0.64), (int)(thisHeight - menuStrip1.Size.Height - 44));
            panel1.Location = new Point(2, menuStrip1.Size.Height + 2);
            DGVCurrentImageTags.Size = DGVTags.Size = new Size((int)((this.Width - panel1.Size.Width)/1.07), (int)((panel1.Size.Height-4) / 2));
            DGVCurrentImageTags.Location = new Point(panel1.Size.Width+5, menuStrip1.Size.Height + 2);
            DGVTags.Location = new Point(panel1.Size.Width + 5, DGVTags.Size.Height+5+ menuStrip1.Size.Height + 2);


            currentTableName = TableName.artists;
            tbibParser = new TbibParser(true);
            searchHistory = new Stack<SearchRequest>();
            //создаю папку если не создана
            DirectoryInfo directoryInfo = new DirectoryInfo("tbib");
            if (!directoryInfo.Exists) directoryInfo.Create();
            //Всплывающее меню для тэгов
            contextMenuStripTags.Items[0].Click += new EventHandler(MenuItemFindTag_Click);
            contextMenuStripTags.Items[1].Click += new EventHandler(MenuItemCreateFolderWithTagName_Click);
            contextMenuStripTags.Items[2].Click += new EventHandler(MenuItemAddSelectedTagToList_Click);
            //Всплывающее меню для списков авторов и категорий
            contextMenuStripListArtists.Items[0].Click += new EventHandler(MenuItemOpenArtistFromList_Click);
            contextMenuStripListArtists.Items[1].Click += new EventHandler(MenuItemDeleteTagFromList_Click);
            (contextMenuStripListArtists.Items[2] as ToolStripDropDownItem).DropDownItems[0].Click += new EventHandler(MenuItemDownloadAllTagImages_Click);
            contextMenuStripListArtists.Items[3].Click += new EventHandler(MenuItemSendTagToOtherList_Click);
            DGVTags.DataSource = SQLiteDBManager.GetTags(TableName.artists);

            void DGVTags_ColumnSortModeChanged(object o, DataGridViewCellMouseEventArgs ea) {
                if (listSortDirection.Equals(System.ComponentModel.ListSortDirection.Ascending)) listSortDirection = System.ComponentModel.ListSortDirection.Descending;
                else listSortDirection = System.ComponentModel.ListSortDirection.Ascending;
                sortedDGVTagsColumnIndex = ea.ColumnIndex; };
            DGVTags.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(DGVTags_ColumnSortModeChanged);

            /*PictureBox pictureBox1;
            int w = 0, h = 0;
            int sizePicBox = panel1.Width/3;
            int columnPicsCount = panel1.Width / 200;
            for (int i = 0; i < IMAGES_COUNT_ON_PAGE; i++)  
            {
                pictureBox1 = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.Thistle,
                    Location = new System.Drawing.Point(w * 200, h * 200),
                    Size = new System.Drawing.Size(195, 195),
                    Name = i.ToString()
                };
                pictureBox1.DoubleClick += new EventHandler(PictureBox_DoubleClick);
                panel1.Controls.Add(pictureBox1);
                if (w > columnPicsCount-2)
                {
                    w = 0;
                    h++;
                }
                else w++;
            }*/
            LoadTumbImagesToPicBoxes(PageDirection.first, true);
        }
        
        private void LoadTumbImagesToPicBoxes(PageDirection pageDirection, bool resetPanelScroll)
        {
            tbibParser.LoadPageImagesFromWeb(searchedTagsTextBox.Text, pageDirection, (DataTable)DGVTags.DataSource);
            if (tbibParser.GetImagesCount() < 1)
            {
                NotifyIcon NI = new NotifyIcon
                {
                    BalloonTipText = "Нет уникальных изображений",
                    BalloonTipTitle = "Поисковик",
                    BalloonTipIcon = ToolTipIcon.Info,
                    Icon = this.Icon,
                    Visible = true
                };
                NI.ShowBalloonTip(1);
            }
            /*for (int i = 0; i < IMAGES_COUNT_ON_PAGE; i++)
            {
                var lockat = ((PictureBox)panel1.Controls[i]).Location;
                if (i < tbibParser.GetImagesCount())
                {
                    ((PictureBox)panel1.Controls[i]).LoadAsync(tbibParser.GetImageThumbUrl(i));
                    ((PictureBox)panel1.Controls[i]).Visible = true;

                }
                else ((PictureBox)panel1.Controls[i]).Visible = false;
                ((PictureBox)panel1.Controls[i]).Location = lockat;
            }*/
            panel1.Controls.Clear();
            PictureBox pictureBox1;
            int w = 0, h = 0;
            int sizePicBox = panel1.Width / 3;
            int columnPicsCount = panel1.Width / 200;
            for (int i = 0; i < tbibParser.GetImagesCount(); i++)
            {
                pictureBox1 = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.Thistle,
                    Location = new System.Drawing.Point(w * 200, h * 200),
                    Size = new System.Drawing.Size(195, 195),
                    Name = i.ToString()

                };
                pictureBox1.LoadAsync(tbibParser.GetImageThumbUrl(i));
                pictureBox1.DoubleClick += new EventHandler(PictureBox_DoubleClick);
                panel1.Controls.Add(pictureBox1);
                if (w > columnPicsCount - 2)
                {
                    w = 0;
                    h++;
                }
                else w++;
            }

            if (resetPanelScroll)
            {
                panel1.VerticalScroll.Value = 0;
            }
            //TODO: оптимизировать всю хуйню со строкками во всём коде
            pageIndexTextBox.Text = tbibParser.Padeindex.ToString();
            pageCountTextBox.Text = tbibParser.PageCount.ToString();
        }
        //загрузить полную версию фотки
        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            panelScrollValue = panel1.VerticalScroll.Value;
            int imageIndex = Convert.ToInt32(((PictureBox)sender).Name);
            FullImageForm fullImageForm = new FullImageForm(tbibParser.GetImageUrl(imageIndex), tbibParser.GetImageId(imageIndex), lastSavePath, imageIndex);
            fullImageForm.SaveFolderChanged += delegate(string newSaveFolderPath) { lastSavePath = newSaveFolderPath; };
            fullImageForm.KeyPressed += delegate (string message, int delimageIndex) {
                switch (message)
                {
                    case "next":
                        if(delimageIndex < tbibParser.GetImagesCount()) fullImageForm.loadImage(tbibParser.GetImageUrl(delimageIndex + 1), delimageIndex + 1);
                        break;
                    case "prew":
                        if (delimageIndex > 0) fullImageForm.loadImage(tbibParser.GetImageUrl(delimageIndex - 1), delimageIndex - 1);
                        break;
                }
            };
            fullImageForm.Show();
            this.Focus();
            DGVCurrentImageTags.DataSource = tbibParser.GetImageTags(imageIndex);
            panel1.Visible = false;
            panel1.VerticalScroll.Value = panelScrollValue;
            panel1.Visible = true;
        }
        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (tbibParser.Padeindex + 42 <= tbibParser.PageCount)
                LoadTumbImagesToPicBoxes(PageDirection.next, true); //гружу следующую страницу
        }
        private void ButtonPrev_Click(object sender, EventArgs e)
        {
            if (tbibParser.Padeindex - 42 > -1) LoadTumbImagesToPicBoxes(PageDirection.back, true);//гружу предыдущую страницу
        }
        //энтер запроса в поисковой строке
        private void TextBoxSearchedTags_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                LoadTumbImagesToPicBoxes(PageDirection.first, true);
            } 
        }
        //***********************************************************************************************
        //событие клик по тэгу в списке слева
        private void DataGridViewAuthorTags_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1) contextMenuStripTags.Show(Cursor.Position);
           
        }
        //создать папку с названием выбранного тега в списке слева
        private void MenuItemCreateFolderWithTagName_Click(object sender, EventArgs e)
        {
            String tagName = "tbib\\" + DGVCurrentImageTags.SelectedCells[0].Value.ToString();
            if (!Directory.Exists(tagName)) Directory.CreateDirectory(tagName);
        }
        //добавить выбранный в списке слева тэг в список справа
        private void MenuItemAddSelectedTagToList_Click(object sender, EventArgs e)
        {
            string tagName = DGVCurrentImageTags.CurrentRow.Cells[0].Value.ToString();
            string tagCategory = DGVCurrentImageTags.CurrentRow.Cells[1].Value.ToString();
            string tagWeight = DGVCurrentImageTags.CurrentRow.Cells[2].Value.ToString();
            SQLiteDBManager.AddTag(tagName, tagCategory, tagWeight, currentTableName);
            DGVTags.DataSource = SQLiteDBManager.GetTags(currentTableName);
            LoadTumbImagesToPicBoxes(PageDirection.current, false);
        }
        //найти картинки по выбранному тэгу из списка слева
        private void MenuItemFindTag_Click(object sender, EventArgs e)
        {
            String tagName = DGVCurrentImageTags.SelectedCells[0].Value.ToString();
            searchHistory.Push(new SearchRequest(searchedTagsTextBox.Text, tbibParser.Padeindex)); //добавил предыдущий поисковый запрос в стек
            searchedTagsTextBox.Text = tagName;
            LoadTumbImagesToPicBoxes(PageDirection.first, true);
        }
        //******************************************************************************************
        //открыть меню для списка справа
        private void DataGridViewArtists_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1) contextMenuStripListArtists.Show(Cursor.Position);
        }
        //найти картинки по выбранному тэгу из списка справа
        private void MenuItemOpenArtistFromList_Click(object sender, EventArgs e)
        {
            String tagName = (string)DGVTags.CurrentRow.Cells[0].Value;
            searchHistory.Push(new SearchRequest(searchedTagsTextBox.Text, tbibParser.Padeindex)); //добавил предыдущий поисковый запрос в стек
            searchedTagsTextBox.Text = tagName;
            LoadTumbImagesToPicBoxes(PageDirection.first, true);
            contextMenuStripListArtists.Hide();
        }
        //удалить тэг из списка справа
        private void MenuItemDeleteTagFromList_Click(object sender, EventArgs e)
        {
            string tagName = DGVTags.CurrentRow.Cells[0].Value.ToString();
            SQLiteDBManager.RemoveTag(currentTableName, tagName);
            DGVTags.DataSource = SQLiteDBManager.GetTags(currentTableName);
            LoadTumbImagesToPicBoxes(PageDirection.current, false);
            contextMenuStripListArtists.Hide();
        }
        //скачать все картинки по выбраннрому тэгу из списка справа
        private void MenuItemDownloadAllTagImages_Click(object sender, EventArgs e)
        {
            int startIndex = Convert.ToInt32((contextMenuStripListArtists.Items[2] as ToolStripDropDownItem).DropDownItems[1].Text);
            string tag = (string)DGVTags.CurrentRow.Cells[0].Value;
            DownloadAllTagImagesForm downloadAllTagImages = new DownloadAllTagImagesForm(tag, startIndex);
            downloadAllTagImages.Show();
            this.Focus();
           /* panel1.VerticalScroll.Value = panelScrollValue;
            panel1.PerformLayout();*/
        }
        //перекинуть картинки из текущего списка в другой
        private void MenuItemSendTagToOtherList_Click(object sender, EventArgs e)
        {
            //TODO: какой блять другой надо чотко определить может их тыща будет. расхардкодить
            string tagName = DGVTags.CurrentRow.Cells[0].Value.ToString();
            string tagCategory = DGVTags.CurrentRow.Cells[1].Value.ToString();
            string tagWeight = DGVTags.CurrentRow.Cells[2].Value.ToString();
            switch (tablesNamesComboBox.SelectedIndex)
            {
                case 0:
                    SQLiteDBManager.AddTag(tagName, tagCategory, tagWeight, TableName.categories);
                    SQLiteDBManager.RemoveTag(TableName.artists, tagName);
                    break;
                case 1:
                    SQLiteDBManager.AddTag(tagName, tagCategory, tagWeight, TableName.artists);
                    SQLiteDBManager.RemoveTag(TableName.categories, tagName);
                    break;
            }
            int index = DGVTags.FirstDisplayedScrollingRowIndex;

            DGVTags.DataSource = SQLiteDBManager.GetTags(currentTableName);
            LoadTumbImagesToPicBoxes(PageDirection.current, false);
            contextMenuStripListArtists.Hide();
            DGVTags.FirstDisplayedScrollingRowIndex = index;
            DGVTags.Sort(DGVTags.Columns[sortedDGVTagsColumnIndex], listSortDirection);
        }
        //**********************************************************************************************
        private void ButtonBack_Click(object sender, EventArgs e)
        {
            if (searchHistory.Count > 0)
            {
                SearchRequest  s = searchHistory.Pop();
                searchedTagsTextBox.Text = s.tag;
                tbibParser.Padeindex = s.pageIndex;
                LoadTumbImagesToPicBoxes(PageDirection.current, true);
            }
            else MessageBox.Show("Нет запросов в истории");
        }
        //при изменении номера страницы
        private void TextBoxPageIndex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && Convert.ToInt32(pageIndexTextBox.Text) <= tbibParser.PageCount)
            {
                tbibParser.Padeindex = Convert.ToInt32(pageIndexTextBox.Text);
                LoadTumbImagesToPicBoxes(PageDirection.current, true);
            }
        }
        //перед закрытием программы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SQLiteDBManager.CloseDB();
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
          switch (e.KeyCode)
            {
                case Keys.Right:
                    if (tbibParser.Padeindex + 42 <= tbibParser.PageCount) LoadTumbImagesToPicBoxes(PageDirection.next, true); //гружу следующую страницу
                    break;
                case Keys.Left:
                    if (tbibParser.Padeindex - 42 > -1) LoadTumbImagesToPicBoxes(PageDirection.back, true); //гружу предыдущую страницу;
                    break;
            }
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(tbibParser);
            void settingsForm_FormClosed(object o, FormClosedEventArgs eh) {
                this.Visible = true;
                panel1.VerticalScroll.Value = panelScrollValue;
               // panel1.PerformLayout();
            }
            settingsForm.FormClosed += new FormClosedEventHandler(settingsForm_FormClosed);
            this.Hide();
            settingsForm.Show();
            settingsForm.Focus();
            
        }
        //исключить/включить теги в списке из/в поиска
        private void FiltrateMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (tbibParser.FiltrateArtist)
            {
                FiltrateMenuItem.BackColor = Color.Gray;
                FiltrateMenuItem.Text = "Фильтр ВЫКЛ";
            }
            else
            {
                FiltrateMenuItem.BackColor = Color.YellowGreen;
                FiltrateMenuItem.Text = "Фильтр ВКЛ";
            }
            tbibParser.FiltrateArtist = !tbibParser.FiltrateArtist;
            LoadTumbImagesToPicBoxes(PageDirection.current, false);
            panelScrollValue = 0;
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) ;//contextMenuStripFormRightClick.Show();
        }

        private void tablesNamesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ToolStripComboBox)sender).SelectedIndex == 0) currentTableName = TableName.artists;
            else currentTableName = TableName.categories;
            DGVTags.DataSource = SQLiteDBManager.GetTags(currentTableName);
            LoadTumbImagesToPicBoxes(PageDirection.current, true);
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            menuStrip1.Size = new Size(menuStrip1.Size.Width, this.Height / 30);
            panel1.Size = new Size((int)(this.Width * 0.64), (int)(this.Height - menuStrip1.Size.Height - 44));
            panel1.Location = new Point(2, menuStrip1.Size.Height + 2);
            DGVCurrentImageTags.Size = DGVTags.Size = new Size((int)((this.Width - panel1.Size.Width) / 1.07), (int)((panel1.Size.Height - 4) / 2));
            DGVCurrentImageTags.Location = new Point(panel1.Size.Width + 5, menuStrip1.Size.Height + 2);
            DGVTags.Location = new Point(panel1.Size.Width + 5, DGVTags.Size.Height + 5 + menuStrip1.Size.Height + 2);
            
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            if (DGVTags.DataSource != null)
            {
                LoadTumbImagesToPicBoxes(PageDirection.current, false);
            }
        }

        private void MainForm_MaximizedBoundsChanged(object sender, EventArgs e)
        {
            if (DGVTags.DataSource != null)
            {
                LoadTumbImagesToPicBoxes(PageDirection.current, false);
            }
        }
    }
}
