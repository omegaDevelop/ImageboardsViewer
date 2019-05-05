using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageboardsViewer
{
    static class HTMLDownloader
    {
        public static string GetContentByLink(string link)
        {
            string s = "";
            try
            {
                WebRequest request = WebRequest.Create(link);
                WebResponse response = request.GetResponseAsync().Result;
                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                s = sr.ReadToEnd();
                response.Close();
                sr.Close();
                stream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ОШИБКА ЗАГРУЗКИ ТЭГА: \n" + e.InnerException.InnerException.Message
                    + "\n---------------------\nПроверь тэг через браузер, вероятно он не доступен вообще");
            }
            return s;
        }
    }
}
