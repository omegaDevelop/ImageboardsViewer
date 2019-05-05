namespace ImageboardsViewer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuItemFindTag = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCreateFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAddTagToList = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripTags = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripListArtists = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssLabelPageIndex = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssLabelPageCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssButtonBackResult = new System.Windows.Forms.ToolStripSplitButton();
            this.tssButtonPrew = new System.Windows.Forms.ToolStripSplitButton();
            this.tssButtonNext = new System.Windows.Forms.ToolStripSplitButton();
            this.tssProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tssLabelNetSpeed = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.sddwvwevToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageTags = new System.Windows.Forms.TabPage();
            this.maskedTextBoxPageIndex = new System.Windows.Forms.MaskedTextBox();
            this.checkBoxFiltrate = new System.Windows.Forms.CheckBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.dgvCurrentImageTags = new System.Windows.Forms.DataGridView();
            this.tabPageDB = new System.Windows.Forms.TabPage();
            this.tabControlDB = new System.Windows.Forms.TabControl();
            this.tabPageCat = new System.Windows.Forms.TabPage();
            this.dgvCatTags = new System.Windows.Forms.DataGridView();
            this.buttonImportCTags = new System.Windows.Forms.Button();
            this.buttonExportCTags = new System.Windows.Forms.Button();
            this.tabPageArt = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dgvArtistsTags = new System.Windows.Forms.DataGridView();
            this.tabPageBlacklist = new System.Windows.Forms.TabPage();
            this.tabPageSet = new System.Windows.Forms.TabPage();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarTumbScale = new System.Windows.Forms.TrackBar();
            this.checkBoxUseProxy = new System.Windows.Forms.CheckBox();
            this.dgvProxy = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripTags.SuspendLayout();
            this.contextMenuStripListArtists.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageTags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentImageTags)).BeginInit();
            this.tabPageDB.SuspendLayout();
            this.tabControlDB.SuspendLayout();
            this.tabPageCat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatTags)).BeginInit();
            this.tabPageArt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtistsTags)).BeginInit();
            this.tabPageSet.SuspendLayout();
            this.panelSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTumbScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProxy)).BeginInit();
            this.tabPageLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // menuItemFindTag
            // 
            this.menuItemFindTag.Name = "menuItemFindTag";
            this.menuItemFindTag.Size = new System.Drawing.Size(239, 22);
            this.menuItemFindTag.Text = "Найти картинки с этим  тэгом";
            // 
            // menuItemCreateFolder
            // 
            this.menuItemCreateFolder.Name = "menuItemCreateFolder";
            this.menuItemCreateFolder.Size = new System.Drawing.Size(239, 22);
            this.menuItemCreateFolder.Text = "Создать папку для этого тэга ";
            // 
            // menuItemAddTagToList
            // 
            this.menuItemAddTagToList.Name = "menuItemAddTagToList";
            this.menuItemAddTagToList.Size = new System.Drawing.Size(239, 22);
            this.menuItemAddTagToList.Text = "Добавить тэг в список справа";
            // 
            // contextMenuStripTags
            // 
            this.contextMenuStripTags.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFindTag,
            this.menuItemCreateFolder,
            this.menuItemAddTagToList});
            this.contextMenuStripTags.Name = "contextMenuStrip1";
            this.contextMenuStripTags.Size = new System.Drawing.Size(240, 70);
            this.contextMenuStripTags.MouseLeave += new System.EventHandler(this.ContextMenuStripTags_MouseLeave);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(231, 22);
            this.toolStripMenuItem3.Text = "Открыть этот тэг";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(231, 22);
            this.toolStripMenuItem1.Text = "Удалить этот тэг";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripTextBox3});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(231, 22);
            this.toolStripMenuItem2.Text = "Скачать тэг полностью";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(211, 22);
            this.toolStripMenuItem4.Text = "Начиная со страницы №";
            // 
            // toolStripTextBox3
            // 
            this.toolStripTextBox3.Name = "toolStripTextBox3";
            this.toolStripTextBox3.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox3.Text = "0";
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.ToolStripMenuItem.Text = "Перекинуть в другой список";
            // 
            // contextMenuStripListArtists
            // 
            this.contextMenuStripListArtists.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.ToolStripMenuItem});
            this.contextMenuStripListArtists.Name = "contextMenuStrip1";
            this.contextMenuStripListArtists.Size = new System.Drawing.Size(232, 92);
            this.contextMenuStripListArtists.MouseLeave += new System.EventHandler(this.ContextMenuStripListArtists_MouseLeave);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabel1,
            this.tssLabelPageIndex,
            this.tssLabel3,
            this.tssLabelPageCount,
            this.tssButtonBackResult,
            this.tssButtonPrew,
            this.tssButtonNext,
            this.tssProgressBar,
            this.tssLabelNetSpeed,
            this.tsDropDownButton});
            this.statusStrip1.Location = new System.Drawing.Point(0, 339);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(817, 22);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssLabel1
            // 
            this.tssLabel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tssLabel1.Name = "tssLabel1";
            this.tssLabel1.Size = new System.Drawing.Size(39, 17);
            this.tssLabel1.Text = "Page: ";
            // 
            // tssLabelPageIndex
            // 
            this.tssLabelPageIndex.BackColor = System.Drawing.Color.LightCyan;
            this.tssLabelPageIndex.Name = "tssLabelPageIndex";
            this.tssLabelPageIndex.Size = new System.Drawing.Size(13, 17);
            this.tssLabelPageIndex.Text = "0";
            // 
            // tssLabel3
            // 
            this.tssLabel3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tssLabel3.Name = "tssLabel3";
            this.tssLabel3.Size = new System.Drawing.Size(80, 17);
            this.tssLabel3.Text = "Pages Count: ";
            // 
            // tssLabelPageCount
            // 
            this.tssLabelPageCount.BackColor = System.Drawing.Color.LightCyan;
            this.tssLabelPageCount.Name = "tssLabelPageCount";
            this.tssLabelPageCount.Size = new System.Drawing.Size(13, 17);
            this.tssLabelPageCount.Text = "0";
            // 
            // tssButtonBackResult
            // 
            this.tssButtonBackResult.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssButtonBackResult.Image = ((System.Drawing.Image)(resources.GetObject("tssButtonBackResult.Image")));
            this.tssButtonBackResult.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssButtonBackResult.Name = "tssButtonBackResult";
            this.tssButtonBackResult.Size = new System.Drawing.Size(32, 20);
            this.tssButtonBackResult.Text = "toolStripSplitButton1";
            this.tssButtonBackResult.ToolTipText = "dfhrh4rh";
            this.tssButtonBackResult.ButtonClick += new System.EventHandler(this.ButtonBack_Click);
            // 
            // tssButtonPrew
            // 
            this.tssButtonPrew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssButtonPrew.Image = ((System.Drawing.Image)(resources.GetObject("tssButtonPrew.Image")));
            this.tssButtonPrew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssButtonPrew.Name = "tssButtonPrew";
            this.tssButtonPrew.Size = new System.Drawing.Size(32, 20);
            this.tssButtonPrew.Text = "toolStripSplitButton2";
            this.tssButtonPrew.ButtonClick += new System.EventHandler(this.ButtonPrev_Click);
            // 
            // tssButtonNext
            // 
            this.tssButtonNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssButtonNext.Image = ((System.Drawing.Image)(resources.GetObject("tssButtonNext.Image")));
            this.tssButtonNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssButtonNext.Name = "tssButtonNext";
            this.tssButtonNext.Size = new System.Drawing.Size(32, 20);
            this.tssButtonNext.Text = "toolStripSplitButton3";
            this.tssButtonNext.ButtonClick += new System.EventHandler(this.ButtonNext_Click);
            // 
            // tssProgressBar
            // 
            this.tssProgressBar.Maximum = 0;
            this.tssProgressBar.Name = "tssProgressBar";
            this.tssProgressBar.Size = new System.Drawing.Size(100, 16);
            this.tssProgressBar.Step = 1;
            // 
            // tssLabelNetSpeed
            // 
            this.tssLabelNetSpeed.BackColor = System.Drawing.Color.Lavender;
            this.tssLabelNetSpeed.Name = "tssLabelNetSpeed";
            this.tssLabelNetSpeed.Size = new System.Drawing.Size(13, 17);
            this.tssLabelNetSpeed.Text = "0";
            // 
            // tsDropDownButton
            // 
            this.tsDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sddwvwevToolStripMenuItem});
            this.tsDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("tsDropDownButton.Image")));
            this.tsDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDropDownButton.Name = "tsDropDownButton";
            this.tsDropDownButton.Size = new System.Drawing.Size(85, 20);
            this.tsDropDownButton.Text = "Загрузки";
            // 
            // sddwvwevToolStripMenuItem
            // 
            this.sddwvwevToolStripMenuItem.Name = "sddwvwevToolStripMenuItem";
            this.sddwvwevToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.sddwvwevToolStripMenuItem.Text = "sddwvwev";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "PORT";
            this.Column2.Name = "Column2";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "IP";
            this.Column1.Name = "Column1";
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            this.RightToolStripPanel.Click += new System.EventHandler(this.toolStripContainer1_RightToolStripPanel_Click);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(229, 227);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.Plum;
            this.flowLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(554, 336);
            this.flowLayoutPanel.TabIndex = 24;
            this.flowLayoutPanel.Click += new System.EventHandler(this.Panel1_Click);
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl.Controls.Add(this.tabPageTags);
            this.tabControl.Controls.Add(this.tabPageDB);
            this.tabControl.Controls.Add(this.tabPageSet);
            this.tabControl.Controls.Add(this.tabPageLog);
            this.tabControl.Location = new System.Drawing.Point(560, 0);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(406, 336);
            this.tabControl.TabIndex = 25;
            this.tabControl.Click += new System.EventHandler(this.TabControl1_Click);
            // 
            // tabPageTags
            // 
            this.tabPageTags.Controls.Add(this.maskedTextBoxPageIndex);
            this.tabPageTags.Controls.Add(this.checkBoxFiltrate);
            this.tabPageTags.Controls.Add(this.textBoxSearch);
            this.tabPageTags.Controls.Add(this.dgvCurrentImageTags);
            this.tabPageTags.Location = new System.Drawing.Point(23, 4);
            this.tabPageTags.Name = "tabPageTags";
            this.tabPageTags.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTags.Size = new System.Drawing.Size(379, 328);
            this.tabPageTags.TabIndex = 0;
            this.tabPageTags.Text = "Img Tags";
            this.tabPageTags.UseVisualStyleBackColor = true;
            // 
            // maskedTextBoxPageIndex
            // 
            this.maskedTextBoxPageIndex.Location = new System.Drawing.Point(322, 4);
            this.maskedTextBoxPageIndex.Mask = "0000000";
            this.maskedTextBoxPageIndex.Name = "maskedTextBoxPageIndex";
            this.maskedTextBoxPageIndex.Size = new System.Drawing.Size(51, 20);
            this.maskedTextBoxPageIndex.TabIndex = 16;
            this.maskedTextBoxPageIndex.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MaskedTextBoxPageIndex_KeyUp);
            // 
            // checkBoxFiltrate
            // 
            this.checkBoxFiltrate.AutoSize = true;
            this.checkBoxFiltrate.BackColor = System.Drawing.Color.Lime;
            this.checkBoxFiltrate.Checked = true;
            this.checkBoxFiltrate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFiltrate.Location = new System.Drawing.Point(7, 7);
            this.checkBoxFiltrate.Name = "checkBoxFiltrate";
            this.checkBoxFiltrate.Size = new System.Drawing.Size(76, 17);
            this.checkBoxFiltrate.TabIndex = 15;
            this.checkBoxFiltrate.Text = "Filtrate ON";
            this.checkBoxFiltrate.UseVisualStyleBackColor = false;
            this.checkBoxFiltrate.CheckedChanged += new System.EventHandler(this.FiltrateMenuItem_CheckedChanged);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBoxSearch.Location = new System.Drawing.Point(85, 4);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(230, 20);
            this.textBoxSearch.TabIndex = 14;
            this.textBoxSearch.Text = "idolmaster";
            this.textBoxSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxSearchedTags_KeyUp);
            // 
            // dgvCurrentImageTags
            // 
            this.dgvCurrentImageTags.AllowUserToAddRows = false;
            this.dgvCurrentImageTags.AllowUserToDeleteRows = false;
            this.dgvCurrentImageTags.AllowUserToResizeColumns = false;
            this.dgvCurrentImageTags.AllowUserToResizeRows = false;
            this.dgvCurrentImageTags.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCurrentImageTags.BackgroundColor = System.Drawing.Color.BlueViolet;
            this.dgvCurrentImageTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentImageTags.Location = new System.Drawing.Point(0, 30);
            this.dgvCurrentImageTags.MultiSelect = false;
            this.dgvCurrentImageTags.Name = "dgvCurrentImageTags";
            this.dgvCurrentImageTags.ReadOnly = true;
            this.dgvCurrentImageTags.RowHeadersVisible = false;
            this.dgvCurrentImageTags.Size = new System.Drawing.Size(379, 299);
            this.dgvCurrentImageTags.TabIndex = 12;
            // 
            // tabPageDB
            // 
            this.tabPageDB.BackColor = System.Drawing.Color.Gray;
            this.tabPageDB.Controls.Add(this.tabControlDB);
            this.tabPageDB.Location = new System.Drawing.Point(23, 4);
            this.tabPageDB.Name = "tabPageDB";
            this.tabPageDB.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDB.Size = new System.Drawing.Size(379, 328);
            this.tabPageDB.TabIndex = 1;
            this.tabPageDB.Text = "DB Tags";
            // 
            // tabControlDB
            // 
            this.tabControlDB.Controls.Add(this.tabPageCat);
            this.tabControlDB.Controls.Add(this.tabPageArt);
            this.tabControlDB.Controls.Add(this.tabPageBlacklist);
            this.tabControlDB.Location = new System.Drawing.Point(1, 0);
            this.tabControlDB.Name = "tabControlDB";
            this.tabControlDB.SelectedIndex = 0;
            this.tabControlDB.Size = new System.Drawing.Size(376, 328);
            this.tabControlDB.TabIndex = 28;
            // 
            // tabPageCat
            // 
            this.tabPageCat.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPageCat.Controls.Add(this.dgvCatTags);
            this.tabPageCat.Controls.Add(this.buttonImportCTags);
            this.tabPageCat.Controls.Add(this.buttonExportCTags);
            this.tabPageCat.Location = new System.Drawing.Point(4, 22);
            this.tabPageCat.Name = "tabPageCat";
            this.tabPageCat.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCat.Size = new System.Drawing.Size(368, 302);
            this.tabPageCat.TabIndex = 0;
            this.tabPageCat.Text = "Categories";
            // 
            // dgvCatTags
            // 
            this.dgvCatTags.AllowUserToAddRows = false;
            this.dgvCatTags.AllowUserToDeleteRows = false;
            this.dgvCatTags.AllowUserToResizeColumns = false;
            this.dgvCatTags.AllowUserToResizeRows = false;
            this.dgvCatTags.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCatTags.BackgroundColor = System.Drawing.Color.BlueViolet;
            this.dgvCatTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCatTags.Location = new System.Drawing.Point(6, 32);
            this.dgvCatTags.MultiSelect = false;
            this.dgvCatTags.Name = "dgvCatTags";
            this.dgvCatTags.ReadOnly = true;
            this.dgvCatTags.RowHeadersVisible = false;
            this.dgvCatTags.Size = new System.Drawing.Size(359, 267);
            this.dgvCatTags.TabIndex = 21;
            // 
            // buttonImportCTags
            // 
            this.buttonImportCTags.BackColor = System.Drawing.Color.Coral;
            this.buttonImportCTags.Location = new System.Drawing.Point(111, 3);
            this.buttonImportCTags.Name = "buttonImportCTags";
            this.buttonImportCTags.Size = new System.Drawing.Size(99, 23);
            this.buttonImportCTags.TabIndex = 26;
            this.buttonImportCTags.Tag = "";
            this.buttonImportCTags.Text = "Import artists tags";
            this.buttonImportCTags.UseVisualStyleBackColor = false;
            // 
            // buttonExportCTags
            // 
            this.buttonExportCTags.BackColor = System.Drawing.Color.Coral;
            this.buttonExportCTags.Location = new System.Drawing.Point(6, 3);
            this.buttonExportCTags.Name = "buttonExportCTags";
            this.buttonExportCTags.Size = new System.Drawing.Size(99, 23);
            this.buttonExportCTags.TabIndex = 25;
            this.buttonExportCTags.Tag = "";
            this.buttonExportCTags.Text = "Export artists tags";
            this.buttonExportCTags.UseVisualStyleBackColor = false;
            // 
            // tabPageArt
            // 
            this.tabPageArt.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPageArt.Controls.Add(this.button1);
            this.tabPageArt.Controls.Add(this.button2);
            this.tabPageArt.Controls.Add(this.dgvArtistsTags);
            this.tabPageArt.Location = new System.Drawing.Point(4, 22);
            this.tabPageArt.Name = "tabPageArt";
            this.tabPageArt.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageArt.Size = new System.Drawing.Size(368, 302);
            this.tabPageArt.TabIndex = 1;
            this.tabPageArt.Text = "Artists";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Coral;
            this.button1.Location = new System.Drawing.Point(111, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 27;
            this.button1.Tag = "";
            this.button1.Text = "Import artists tags";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Coral;
            this.button2.Location = new System.Drawing.Point(6, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 26;
            this.button2.Tag = "";
            this.button2.Text = "Export artists tags";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // dgvArtistsTags
            // 
            this.dgvArtistsTags.AllowUserToAddRows = false;
            this.dgvArtistsTags.AllowUserToDeleteRows = false;
            this.dgvArtistsTags.AllowUserToResizeColumns = false;
            this.dgvArtistsTags.AllowUserToResizeRows = false;
            this.dgvArtistsTags.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArtistsTags.BackgroundColor = System.Drawing.Color.BlueViolet;
            this.dgvArtistsTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArtistsTags.Location = new System.Drawing.Point(6, 32);
            this.dgvArtistsTags.MultiSelect = false;
            this.dgvArtistsTags.Name = "dgvArtistsTags";
            this.dgvArtistsTags.ReadOnly = true;
            this.dgvArtistsTags.RowHeadersVisible = false;
            this.dgvArtistsTags.Size = new System.Drawing.Size(359, 267);
            this.dgvArtistsTags.TabIndex = 25;
            // 
            // tabPageBlacklist
            // 
            this.tabPageBlacklist.Location = new System.Drawing.Point(4, 22);
            this.tabPageBlacklist.Name = "tabPageBlacklist";
            this.tabPageBlacklist.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBlacklist.Size = new System.Drawing.Size(368, 302);
            this.tabPageBlacklist.TabIndex = 2;
            this.tabPageBlacklist.Text = "Blacklist";
            this.tabPageBlacklist.UseVisualStyleBackColor = true;
            // 
            // tabPageSet
            // 
            this.tabPageSet.BackColor = System.Drawing.Color.White;
            this.tabPageSet.Controls.Add(this.panelSettings);
            this.tabPageSet.Location = new System.Drawing.Point(23, 4);
            this.tabPageSet.Name = "tabPageSet";
            this.tabPageSet.Size = new System.Drawing.Size(379, 328);
            this.tabPageSet.TabIndex = 3;
            this.tabPageSet.Text = "Settings";
            // 
            // panelSettings
            // 
            this.panelSettings.BackColor = System.Drawing.Color.Gainsboro;
            this.panelSettings.Controls.Add(this.label1);
            this.panelSettings.Controls.Add(this.trackBarTumbScale);
            this.panelSettings.Controls.Add(this.checkBoxUseProxy);
            this.panelSettings.Controls.Add(this.dgvProxy);
            this.panelSettings.Location = new System.Drawing.Point(3, 3);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(373, 322);
            this.panelSettings.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Масштаб превьюшек";
            // 
            // trackBarTumbScale
            // 
            this.trackBarTumbScale.Location = new System.Drawing.Point(250, 54);
            this.trackBarTumbScale.Maximum = 5;
            this.trackBarTumbScale.Minimum = 1;
            this.trackBarTumbScale.Name = "trackBarTumbScale";
            this.trackBarTumbScale.Size = new System.Drawing.Size(120, 45);
            this.trackBarTumbScale.TabIndex = 2;
            this.trackBarTumbScale.Value = 1;
            // 
            // checkBoxUseProxy
            // 
            this.checkBoxUseProxy.AutoSize = true;
            this.checkBoxUseProxy.Location = new System.Drawing.Point(250, 5);
            this.checkBoxUseProxy.Name = "checkBoxUseProxy";
            this.checkBoxUseProxy.Size = new System.Drawing.Size(70, 17);
            this.checkBoxUseProxy.TabIndex = 1;
            this.checkBoxUseProxy.Text = "Use poxy";
            this.checkBoxUseProxy.UseVisualStyleBackColor = true;
            // 
            // dgvProxy
            // 
            this.dgvProxy.AllowUserToAddRows = false;
            this.dgvProxy.AllowUserToDeleteRows = false;
            this.dgvProxy.AllowUserToResizeColumns = false;
            this.dgvProxy.AllowUserToResizeRows = false;
            this.dgvProxy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProxy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6});
            this.dgvProxy.Location = new System.Drawing.Point(3, 5);
            this.dgvProxy.Name = "dgvProxy";
            this.dgvProxy.RowHeadersVisible = false;
            this.dgvProxy.Size = new System.Drawing.Size(241, 194);
            this.dgvProxy.TabIndex = 0;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "IP";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.HeaderText = "PORT";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 62;
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.dgvLogs);
            this.tabPageLog.Location = new System.Drawing.Point(23, 4);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Size = new System.Drawing.Size(379, 328);
            this.tabPageLog.TabIndex = 4;
            this.tabPageLog.Text = "Logs";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // dgvLogs
            // 
            this.dgvLogs.AllowUserToAddRows = false;
            this.dgvLogs.AllowUserToDeleteRows = false;
            this.dgvLogs.AllowUserToResizeColumns = false;
            this.dgvLogs.AllowUserToResizeRows = false;
            this.dgvLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLogs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLogs.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLogs.Location = new System.Drawing.Point(0, 0);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.RowHeadersVisible = false;
            this.dgvLogs.Size = new System.Drawing.Size(376, 328);
            this.dgvLogs.TabIndex = 0;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column3.HeaderText = "Date";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 55;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Log";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(817, 361);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.Text = "-";
            this.MaximizedBoundsChanged += new System.EventHandler(this.MainForm_MaximizedBoundsChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.contextMenuStripTags.ResumeLayout(false);
            this.contextMenuStripListArtists.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageTags.ResumeLayout(false);
            this.tabPageTags.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentImageTags)).EndInit();
            this.tabPageDB.ResumeLayout(false);
            this.tabControlDB.ResumeLayout(false);
            this.tabPageCat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatTags)).EndInit();
            this.tabPageArt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtistsTags)).EndInit();
            this.tabPageSet.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTumbScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProxy)).EndInit();
            this.tabPageLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem menuItemFindTag;
        private System.Windows.Forms.ToolStripMenuItem menuItemCreateFolder;
        private System.Windows.Forms.ToolStripMenuItem menuItemAddTagToList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTags;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripListArtists;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tssLabelPageIndex;
        private System.Windows.Forms.ToolStripStatusLabel tssLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tssLabelPageCount;
        private System.Windows.Forms.ToolStripSplitButton tssButtonBackResult;
        private System.Windows.Forms.ToolStripSplitButton tssButtonPrew;
        private System.Windows.Forms.ToolStripSplitButton tssButtonNext;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageTags;
        private System.Windows.Forms.CheckBox checkBoxFiltrate;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.DataGridView dgvCurrentImageTags;
        private System.Windows.Forms.TabPage tabPageDB;
        private System.Windows.Forms.TabControl tabControlDB;
        private System.Windows.Forms.TabPage tabPageCat;
        private System.Windows.Forms.DataGridView dgvCatTags;
        private System.Windows.Forms.Button buttonImportCTags;
        private System.Windows.Forms.Button buttonExportCTags;
        private System.Windows.Forms.TabPage tabPageArt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvArtistsTags;
        private System.Windows.Forms.TabPage tabPageSet;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.ToolStripProgressBar tssProgressBar;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.CheckBox checkBoxUseProxy;
        private System.Windows.Forms.DataGridView dgvProxy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.ToolStripStatusLabel tssLabelNetSpeed;
        private System.Windows.Forms.ToolStripDropDownButton tsDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem sddwvwevToolStripMenuItem;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPageIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarTumbScale;
        private System.Windows.Forms.TabPage tabPageBlacklist;
    }
}

