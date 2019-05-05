namespace ImageboardsViewer
{
    partial class SettingsForm
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
            this.buttonBrowseFile = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonSaveTableToFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonDeleteCopy = new System.Windows.Forms.Button();
            this.checkBoxImageZoom = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonScanFolderName = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBrowseFile
            // 
            this.buttonBrowseFile.Location = new System.Drawing.Point(12, 39);
            this.buttonBrowseFile.Name = "buttonBrowseFile";
            this.buttonBrowseFile.Size = new System.Drawing.Size(228, 23);
            this.buttonBrowseFile.TabIndex = 0;
            this.buttonBrowseFile.Text = "Add Tags To DB From TXT ";
            this.buttonBrowseFile.UseVisualStyleBackColor = true;
            this.buttonBrowseFile.Click += new System.EventHandler(this.ButtonBrowseFile_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(145, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // buttonSaveTableToFile
            // 
            this.buttonSaveTableToFile.Location = new System.Drawing.Point(12, 68);
            this.buttonSaveTableToFile.Name = "buttonSaveTableToFile";
            this.buttonSaveTableToFile.Size = new System.Drawing.Size(228, 23);
            this.buttonSaveTableToFile.TabIndex = 3;
            this.buttonSaveTableToFile.Text = "Save Table As TXT";
            this.buttonSaveTableToFile.UseVisualStyleBackColor = true;
            this.buttonSaveTableToFile.Click += new System.EventHandler(this.ButtonSaveTableToFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
            // 
            // buttonDeleteCopy
            // 
            this.buttonDeleteCopy.Location = new System.Drawing.Point(12, 97);
            this.buttonDeleteCopy.Name = "buttonDeleteCopy";
            this.buttonDeleteCopy.Size = new System.Drawing.Size(228, 23);
            this.buttonDeleteCopy.TabIndex = 6;
            this.buttonDeleteCopy.Text = "Delete dublicate from table";
            this.buttonDeleteCopy.UseVisualStyleBackColor = true;
            this.buttonDeleteCopy.Click += new System.EventHandler(this.ButtonDeleteCopy_Click);
            // 
            // checkBoxImageZoom
            // 
            this.checkBoxImageZoom.AutoSize = true;
            this.checkBoxImageZoom.Checked = true;
            this.checkBoxImageZoom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxImageZoom.Location = new System.Drawing.Point(12, 126);
            this.checkBoxImageZoom.Name = "checkBoxImageZoom";
            this.checkBoxImageZoom.Size = new System.Drawing.Size(104, 17);
            this.checkBoxImageZoom.TabIndex = 7;
            this.checkBoxImageZoom.Text = "Zoom Full Image";
            this.checkBoxImageZoom.UseVisualStyleBackColor = true;
            this.checkBoxImageZoom.CheckedChanged += new System.EventHandler(this.CheckBoxImageZoom_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.SystemColors.Info;
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(11, 224);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(152, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "навигации по страницам";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.BackColor = System.Drawing.SystemColors.Info;
            this.checkBox3.ForeColor = System.Drawing.Color.Black;
            this.checkBox3.Location = new System.Drawing.Point(11, 178);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(163, 17);
            this.checkBox3.TabIndex = 10;
            this.checkBox3.Text = "добавлении тэга в таблицу";
            this.checkBox3.UseVisualStyleBackColor = false;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.BackColor = System.Drawing.SystemColors.Info;
            this.checkBox5.ForeColor = System.Drawing.Color.Black;
            this.checkBox5.Location = new System.Drawing.Point(12, 316);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(101, 17);
            this.checkBox5.TabIndex = 12;
            this.checkBox5.Text = "поиске по тэгу";
            this.checkBox5.UseVisualStyleBackColor = false;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.BackColor = System.Drawing.SystemColors.Info;
            this.checkBox7.ForeColor = System.Drawing.Color.Black;
            this.checkBox7.Location = new System.Drawing.Point(11, 201);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(159, 17);
            this.checkBox7.TabIndex = 14;
            this.checkBox7.Text = "удалении тэга из таблицы";
            this.checkBox7.UseVisualStyleBackColor = false;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.BackColor = System.Drawing.SystemColors.Info;
            this.checkBox8.ForeColor = System.Drawing.Color.Black;
            this.checkBox8.Location = new System.Drawing.Point(12, 270);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(131, 17);
            this.checkBox8.TabIndex = 15;
            this.checkBox8.Text = "перекидывании тэга";
            this.checkBox8.UseVisualStyleBackColor = false;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.BackColor = System.Drawing.SystemColors.Info;
            this.checkBox11.ForeColor = System.Drawing.Color.Black;
            this.checkBox11.Location = new System.Drawing.Point(12, 247);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(145, 17);
            this.checkBox11.TabIndex = 18;
            this.checkBox11.Text = "переключение фильтра";
            this.checkBox11.UseVisualStyleBackColor = false;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.BackColor = System.Drawing.SystemColors.Info;
            this.checkBox12.ForeColor = System.Drawing.Color.Black;
            this.checkBox12.Location = new System.Drawing.Point(11, 293);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(118, 17);
            this.checkBox12.TabIndex = 19;
            this.checkBox12.Text = "загрузке таблицы";
            this.checkBox12.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Сбрасывать скролл при:";
            // 
            // buttonScanFolderName
            // 
            this.buttonScanFolderName.Location = new System.Drawing.Point(12, 339);
            this.buttonScanFolderName.Name = "buttonScanFolderName";
            this.buttonScanFolderName.Size = new System.Drawing.Size(228, 23);
            this.buttonScanFolderName.TabIndex = 21;
            this.buttonScanFolderName.Text = "Add new artists from folders names";
            this.buttonScanFolderName.UseVisualStyleBackColor = true;
            this.buttonScanFolderName.Click += new System.EventHandler(this.ButtonScanFolderName_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 434);
            this.Controls.Add(this.buttonScanFolderName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox12);
            this.Controls.Add(this.checkBox11);
            this.Controls.Add(this.checkBox8);
            this.Controls.Add(this.checkBox7);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkBoxImageZoom);
            this.Controls.Add(this.buttonDeleteCopy);
            this.Controls.Add(this.buttonSaveTableToFile);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonBrowseFile);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBrowseFile;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonSaveTableToFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonDeleteCopy;
        private System.Windows.Forms.CheckBox checkBoxImageZoom;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonScanFolderName;
    }
}