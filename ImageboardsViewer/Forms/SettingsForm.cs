using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageboardsViewer
{
    public partial class SettingsForm : Form
    {
        TbibParser tbibParser;
        public SettingsForm(TbibParser tbibParser)
        {
            InitializeComponent();
            if (((PictureBoxSizeMode)Properties.Settings.Default["FullImageSizeMode"]) == PictureBoxSizeMode.AutoSize) checkBoxImageZoom.Checked = false;
            comboBox1.Items.AddRange(new string[] { TableName.artists.ToString(), TableName.categories.ToString()});
            comboBox1.SelectedIndex = 0;
            this.tbibParser = tbibParser;
        }

        private void ButtonBrowseFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            TableName tn;
            if (comboBox1.SelectedItem.ToString() == TableName.artists.ToString()) tn = TableName.artists;
            else tn = TableName.categories;
            TagEditorForm lookFileTagsForm = new TagEditorForm(openFileDialog1.FileName, tbibParser, tn);

            void lookFileTagsForm_FormClosed(object o, FormClosedEventArgs eh) { this.Visible = true; }
            lookFileTagsForm.FormClosed += new FormClosedEventHandler(lookFileTagsForm_FormClosed);

            lookFileTagsForm.Show();
            lookFileTagsForm.Focus();
            this.Hide();
        }

        private void buttonSaveTableToFile_Click(object sender, EventArgs e)
        {

        }

        private void buttonDeleteCopy_Click(object sender, EventArgs e)
        {
            TableName tn;
            if (comboBox1.SelectedItem.ToString() == TableName.artists.ToString()) tn = TableName.artists;
            else tn = TableName.categories;
            MessageBox.Show(string.Format("В таблице '{0}' найдено и удалено {1} похожих записей.", tn, SQLiteDBManager.DeleteCopy(tn)));
        }

        private void checkBoxImageZoom_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == true) Properties.Settings.Default["FullImageSizeMode"] = PictureBoxSizeMode.Zoom;
            else Properties.Settings.Default["FullImageSizeMode"] = PictureBoxSizeMode.AutoSize;
            Properties.Settings.Default.Save(); 
        }

        private void buttonScanFolderName_Click(object sender, EventArgs e)
        {
            DirectoryInfo dirInfo = new DirectoryInfo("tbib");
            DirectoryInfo[] di = dirInfo.GetDirectories();
            StreamWriter streamWriter = new StreamWriter("tbib\\dirNames.txt");
            int count = di.Length;
            for (int i = 0; i < count; i++)
            {
                if (i < count - 1) streamWriter.WriteLine(di[i].Name);
                else streamWriter.Write(di[i].Name);
            }
            streamWriter.Close();

            TagEditorForm lookFileTagsForm = new TagEditorForm("tbib\\dirNames.txt", tbibParser, TableName.artists);
            void lookFileTagsForm_FormClosed(object o, FormClosedEventArgs eh) { this.Visible = true; }
            lookFileTagsForm.FormClosed += new FormClosedEventHandler(lookFileTagsForm_FormClosed);
            lookFileTagsForm.Show();
            lookFileTagsForm.Focus();
            this.Hide();
        }



        /* public static void SaveTagsToFile(string fileName)
         {
             if (tagsFromFile != null)
             {
                 StreamWriter streamWriter = new StreamWriter(fileName);
                 int count = tagsFromFile.Count;
                 for (int i = 0; i < count; i++)
                 {
                     if (i < count - 1) streamWriter.WriteLine(tagsFromFile.ElementAt(i));
                     else streamWriter.Write(tagsFromFile.ElementAt(i));
                 }
                 streamWriter.Close();
             }
         }*/
    }
}
