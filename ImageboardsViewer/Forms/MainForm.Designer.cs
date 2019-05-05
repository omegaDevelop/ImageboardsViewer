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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prevMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchedTagsTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.pageIndexTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.pageCountTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.FiltrateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablesNamesComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DGVCurrentImageTags = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.DGVTags = new System.Windows.Forms.DataGridView();
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
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCurrentImageTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTags)).BeginInit();
            this.contextMenuStripTags.SuspendLayout();
            this.contextMenuStripListArtists.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.MediumPurple;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsMenuItem,
            this.backMenuItem,
            this.prevMenuItem,
            this.nextMenuItem,
            this.searchedTagsTextBox,
            this.pageIndexTextBox,
            this.pageCountTextBox,
            this.FiltrateMenuItem,
            this.tablesNamesComboBox});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1436, 27);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // SettingsMenuItem
            // 
            this.SettingsMenuItem.BackColor = System.Drawing.Color.BlueViolet;
            this.SettingsMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SettingsMenuItem.ForeColor = System.Drawing.Color.White;
            this.SettingsMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.SettingsMenuItem.Name = "SettingsMenuItem";
            this.SettingsMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.SettingsMenuItem.Size = new System.Drawing.Size(18, 23);
            this.SettingsMenuItem.Text = "S";
            this.SettingsMenuItem.Click += new System.EventHandler(this.SettingsMenuItem_Click);
            // 
            // backMenuItem
            // 
            this.backMenuItem.BackColor = System.Drawing.Color.BlueViolet;
            this.backMenuItem.ForeColor = System.Drawing.Color.White;
            this.backMenuItem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.backMenuItem.Name = "backMenuItem";
            this.backMenuItem.Size = new System.Drawing.Size(44, 23);
            this.backMenuItem.Text = "Back";
            this.backMenuItem.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // prevMenuItem
            // 
            this.prevMenuItem.BackColor = System.Drawing.Color.BlueViolet;
            this.prevMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.prevMenuItem.ForeColor = System.Drawing.Color.White;
            this.prevMenuItem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.prevMenuItem.Name = "prevMenuItem";
            this.prevMenuItem.Size = new System.Drawing.Size(42, 23);
            this.prevMenuItem.Text = "Prev";
            this.prevMenuItem.Click += new System.EventHandler(this.ButtonPrev_Click);
            // 
            // nextMenuItem
            // 
            this.nextMenuItem.BackColor = System.Drawing.Color.BlueViolet;
            this.nextMenuItem.ForeColor = System.Drawing.Color.White;
            this.nextMenuItem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nextMenuItem.Name = "nextMenuItem";
            this.nextMenuItem.Size = new System.Drawing.Size(43, 23);
            this.nextMenuItem.Text = "Next";
            this.nextMenuItem.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // searchedTagsTextBox
            // 
            this.searchedTagsTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.searchedTagsTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.searchedTagsTextBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.searchedTagsTextBox.Name = "searchedTagsTextBox";
            this.searchedTagsTextBox.Size = new System.Drawing.Size(100, 23);
            this.searchedTagsTextBox.Text = "big_breasts";
            this.searchedTagsTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxSearchedTags_KeyDown);
            // 
            // pageIndexTextBox
            // 
            this.pageIndexTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pageIndexTextBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pageIndexTextBox.Name = "pageIndexTextBox";
            this.pageIndexTextBox.Size = new System.Drawing.Size(60, 23);
            this.pageIndexTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxPageIndex_KeyDown);
            // 
            // pageCountTextBox
            // 
            this.pageCountTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.pageCountTextBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pageCountTextBox.Name = "pageCountTextBox";
            this.pageCountTextBox.ReadOnly = true;
            this.pageCountTextBox.Size = new System.Drawing.Size(60, 23);
            // 
            // FiltrateMenuItem
            // 
            this.FiltrateMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.FiltrateMenuItem.BackColor = System.Drawing.Color.YellowGreen;
            this.FiltrateMenuItem.Checked = true;
            this.FiltrateMenuItem.CheckOnClick = true;
            this.FiltrateMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FiltrateMenuItem.ForeColor = System.Drawing.Color.White;
            this.FiltrateMenuItem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FiltrateMenuItem.Name = "FiltrateMenuItem";
            this.FiltrateMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.FiltrateMenuItem.Size = new System.Drawing.Size(77, 23);
            this.FiltrateMenuItem.Text = "Фильтр ВКЛ";
            this.FiltrateMenuItem.CheckedChanged += new System.EventHandler(this.FiltrateMenuItem_CheckedChanged);
            // 
            // tablesNamesComboBox
            // 
            this.tablesNamesComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tablesNamesComboBox.Items.AddRange(new object[] {
            "artists",
            "categories"});
            this.tablesNamesComboBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tablesNamesComboBox.Name = "tablesNamesComboBox";
            this.tablesNamesComboBox.Size = new System.Drawing.Size(100, 23);
            this.tablesNamesComboBox.Text = "artists";
            this.tablesNamesComboBox.SelectedIndexChanged += new System.EventHandler(this.tablesNamesComboBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.MediumPurple;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(382, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 600);
            this.panel1.TabIndex = 11;
            // 
            // DGVCurrentImageTags
            // 
            this.DGVCurrentImageTags.AllowUserToAddRows = false;
            this.DGVCurrentImageTags.AllowUserToDeleteRows = false;
            this.DGVCurrentImageTags.AllowUserToResizeColumns = false;
            this.DGVCurrentImageTags.AllowUserToResizeRows = false;
            this.DGVCurrentImageTags.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVCurrentImageTags.BackgroundColor = System.Drawing.Color.BlueViolet;
            this.DGVCurrentImageTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVCurrentImageTags.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVCurrentImageTags.Location = new System.Drawing.Point(0, 30);
            this.DGVCurrentImageTags.MultiSelect = false;
            this.DGVCurrentImageTags.Name = "DGVCurrentImageTags";
            this.DGVCurrentImageTags.ReadOnly = true;
            this.DGVCurrentImageTags.RowHeadersVisible = false;
            this.DGVCurrentImageTags.Size = new System.Drawing.Size(377, 600);
            this.DGVCurrentImageTags.TabIndex = 12;
            this.DGVCurrentImageTags.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewAuthorTags_CellClick);
            // 
            // DGVTags
            // 
            this.DGVTags.AllowUserToAddRows = false;
            this.DGVTags.AllowUserToDeleteRows = false;
            this.DGVTags.AllowUserToResizeColumns = false;
            this.DGVTags.AllowUserToResizeRows = false;
            this.DGVTags.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVTags.BackgroundColor = System.Drawing.Color.BlueViolet;
            this.DGVTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVTags.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGVTags.Location = new System.Drawing.Point(1047, 30);
            this.DGVTags.MultiSelect = false;
            this.DGVTags.Name = "DGVTags";
            this.DGVTags.ReadOnly = true;
            this.DGVTags.RowHeadersVisible = false;
            this.DGVTags.Size = new System.Drawing.Size(377, 600);
            this.DGVTags.TabIndex = 21;
            this.DGVTags.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewArtists_CellClick);
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
            this.toolStripMenuItem4.Click += new System.EventHandler(this.ToolStripMenuItem4_Click);
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
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(1436, 642);
            this.Controls.Add(this.DGVTags);
            this.Controls.Add(this.DGVCurrentImageTags);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "ImageboardsViewer V0.1";
            this.MaximizedBoundsChanged += new System.EventHandler(this.MainForm_MaximizedBoundsChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCurrentImageTags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTags)).EndInit();
            this.contextMenuStripTags.ResumeLayout(false);
            this.contextMenuStripListArtists.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DGVCurrentImageTags;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView DGVTags;
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
        private System.Windows.Forms.ToolStripMenuItem SettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prevMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextMenuItem;
        private System.Windows.Forms.ToolStripTextBox searchedTagsTextBox;
        private System.Windows.Forms.ToolStripTextBox pageIndexTextBox;
        private System.Windows.Forms.ToolStripTextBox pageCountTextBox;
        private System.Windows.Forms.ToolStripMenuItem FiltrateMenuItem;
        private System.Windows.Forms.ToolStripComboBox tablesNamesComboBox;
    }
}

