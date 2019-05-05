using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageboardsViewer
{
    public partial class DownloadAllTagImagesForm : Form
    {
        string tagName, savePath;
        int startIndex;
        Thread thread;
        public DownloadAllTagImagesForm(string tagName, int startIndex)
        {
            InitializeComponent();
            //создаю папку если не создана
            DirectoryInfo directoryInfo = new DirectoryInfo("tbib\\" + tagName);
            if (!directoryInfo.Exists) directoryInfo.Create();
            savePath = "tbib\\" + tagName + "\\";
            this.Text =  tagName + " download";
            this.tagName = tagName;
            this.startIndex = startIndex;
        }

        private string GetImagePathAndName(string savePath, string imageId, string imageUrl)
        {
            if (imageUrl.IndexOf(".jpg") != -1) return savePath + imageId + ".jpg";
            else if (imageUrl.IndexOf(".jpeg") != -1) return savePath + imageId + ".jpeg";
            else if (imageUrl.IndexOf(".png") != -1) return savePath + imageId + ".png";
            else if (imageUrl.IndexOf(".gif") != -1) return savePath + imageId + ".gif";
            else return savePath + imageId + ".bmp";
        }

        private void DownloadAllTagImages_Load(object sender, EventArgs e)
        {
            thread = new Thread(() => StartDownload());
            thread.Start();
        }

        private bool CheckUrl(string URL)
        {
            try
            {
                WebClient wc = new WebClient();
                string HTMLSource = wc.DownloadString(URL);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void DownloadAllTagImages_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread.Abort();
        }

        private void StartDownload()
        {
            //получаю максимальное количество изображений   //допилить взять из тэгов
            IHtmlDocument webPage = new HtmlParser().Parse(HTMLDownloader
               .GetHTMLByUrl("https://tbib.org/index.php?page=post&s=list&tags=" + tagName + "&pid=0"));

            //у тега не всегда кол-во соответствует реальному - этот способ не стабилен
            // int searchTagCount = Convert.ToInt32(webPage.All.Where(m => (m.ClassName == "tag-type-general" | m.ClassName == "tag-type-artist") && m.Children.Count() > 2 && m.Children[2].TextContent == tagName).ElementAt(0).Children[3].TextContent);
            int searchTagCount;
            IEnumerable<IElement> lastPageItems = webPage.All.Where(m => m.TextContent == ">>");
            try
            {
                string pc = lastPageItems.ElementAt(0).Attributes.ElementAt(0).Value;
                searchTagCount = Convert.ToInt32(pc.Remove(0, pc.IndexOf("d=") + 2)) + 42;
            }
            catch (Exception) { searchTagCount = 84; }
            
            progressBar.Invoke(new Action(() => { progressBar.Maximum = searchTagCount; }));
            progressBar.Invoke(new Action(() => { progressBar.Value = startIndex; }));
            WebClient webClient = new WebClient();
            IEnumerable<IElement> listItemsLinq;
            string[] imageFormats = { "jpg", "png", "gif", "bmp", "jpeg" };
            string imageId = "", imageThumbUrl, url;
            int i;

            //перебор страниц
            for (int padeIndex = (startIndex/42)*42; padeIndex <= searchTagCount; padeIndex += 42)
            {
                webPage = new HtmlParser().Parse(HTMLDownloader
                .GetHTMLByUrl("https://tbib.org/index.php?page=post&s=list&tags=" + tagName + "&pid=" + padeIndex));
                listItemsLinq = webPage.All.Where(m => m.ClassName == "preview");
                //перебор картинок на одной странице
                foreach (var imageItem in listItemsLinq)
                {
                    imageId = imageItem.Attributes.ElementAt(0).Value;  //.jpg?
                    imageId = imageId.Remove(0, imageId.IndexOf(".jpg?")+5);
                    //получил ссылку на кратинку
                    imageThumbUrl = "https:" + imageItem.Attributes.ElementAt(0).Value;
                    url = imageThumbUrl.Remove(imageThumbUrl.IndexOf('?'))
                                       .Replace("thumbnails", "images")
                                       .Replace("thumbnail_", "");
                    url = url.Remove(url.Length - 3);
                    try
                    {
                        //подбираю расширение  допилить проверить может загрузка одной страницы картинки быстрее бем дрочить расширения
                        i = 0;
                        while (true)
                        {
                            if (CheckUrl(url + imageFormats[i]))
                            {
                                url += imageFormats[i];
                                break;
                            }
                            else i++;
                        }
                        //конкретно скачиваю на комп
                        webClient.DownloadFile(url, GetImagePathAndName(savePath, imageId, url));
                        progressBar.Invoke(new Action(() => { progressBar.Value++; }));
                    }
                    catch (Exception err)
                    {
                        NotifyIcon NI = new NotifyIcon
                        {
                            BalloonTipText = "Чот не качается фотка номер " + progressBar.Value + '\n'
                            + err.Message,
                            BalloonTipTitle = "Загрузчик",
                            BalloonTipIcon = ToolTipIcon.Info,
                            Icon = this.Icon,
                            Visible = true
                        };
                        NI.ShowBalloonTip(1);
                    }
                    label1.Invoke(new Action(() => { label1.Text = "Скачано: " + progressBar.Value + "/" + searchTagCount; }));
                }
            }
            MessageBox.Show("Тэг " + tagName + " скачан.\n Количество загруженных картинок: " + progressBar.Value + " из " + searchTagCount);
            webClient.Dispose();
            this.Invoke(new Action(() => { this.Close(); }));
        }
    }
}
