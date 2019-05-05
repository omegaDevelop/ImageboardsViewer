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
    public partial class TagEditorForm : Form
    {
        TbibParser tbibParser;
        TableName tableName;
        public TagEditorForm(string fileName, TbibParser tbibParser, TableName tableName)
        {
            InitializeComponent();
            textBox1.Text = LoadTagsFromFile(fileName);
            this.tbibParser = tbibParser;
            this.tableName = tableName;
        }

        private string LoadTagsFromFile(string fileName) //Загружаю в лист артистов из текстовика
        {
            StreamReader streamReader = new StreamReader(fileName);
            string s = streamReader.ReadToEnd();
            streamReader.Close();
            return s;
        }

        private void ButtonStartLoad_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text.Replace("\r\n", " "); //вытянул тэги в линию хз зачем
            List<string> tagsFromFile = new List<string>();
            tagsFromFile.AddRange(s.Split(' '));
            progressBar1.Value = 0;
            progressBar1.Maximum = tagsFromFile.Count;
            string[] tagCategotyAndWeight;
            string dontLoad = "";
            for (int i = 0; i < tagsFromFile.Count; i++)
            {
                tagCategotyAndWeight = tbibParser.GetTagCategorAndWeight(tagsFromFile.ElementAt(i));
                if(tagCategotyAndWeight[0] != "????" && tagCategotyAndWeight[1] != "????")
                {
                    SQLiteDBManager.AddTag(tagsFromFile.ElementAt(i), tagCategotyAndWeight[0], tagCategotyAndWeight[1], tableName);
                    progressBar1.Value++;
                }
                else
                {
                    dontLoad += tagsFromFile.ElementAt(i) + "\n";
                }
            }
            MessageBox.Show("В БД таблицу '" + tableName.ToString() + "' загружено тегов: " + progressBar1.Value + " из " + tagsFromFile.Count + " кроме следующих:\n" + dontLoad);
            this.Close();
        }
    }
}
