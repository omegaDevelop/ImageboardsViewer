using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageboardsViewer
{
    static class HTMLDownloader
    {
        private static WebProxy webProxy = new WebProxy("221.126.249.102", 8080); //87.120.179.187    183.179.199.232   221.126.249.102

        public static string GetHTMLByUrl(string url)
        {
            string s = "";
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Proxy = webProxy;
                request.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36 OPR/60.0.3255.59";
                CookieContainer cookieContainer = new CookieContainer();
                cookieContainer.Add(new Cookie("cf_clearance", "e039bb0208c36c14194a726dc32d3172a5caf996-1556370104-31536000-220", "/", "tbib.org"));
                request.CookieContainer = cookieContainer;
               
                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                s = sr.ReadToEnd();
                int df = s.Length;
                response.Close();
                sr.Close();
                stream.Close();
            }
            catch (Exception e)
            {
                return "";
            }
            return s;
        }
        
        public static void LoadImageByUrl(string url, PictureBox pictureBox, ToolStripStatusLabel toolStripStatusLabelNetSpeed, int imageScale)
        {
            string[] ends = new[] { ".jpg", ".png", ".jpeg", ".gif", ".bmp" }; //TODO это костыль
            int index = 1;
            while (index < ends.Length)
            {
                try
                {
                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                    request.Proxy = webProxy;
                    request.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36 OPR/60.0.3255.59";
                    CookieContainer cookieContainer = new CookieContainer();
                    cookieContainer.Add(new Cookie("cf_clearance", "e039bb0208c36c14194a726dc32d3172a5caf996-1556370104-31536000-220", "/", "tbib.org"));
                    request.CookieContainer = cookieContainer;
                    Debug.WriteLine("OP thread");
                    DateTime dateTimeFirst = DateTime.Now;
                    WebResponse response = request.GetResponse();
                    DateTime dateTimeSecond = DateTime.Now;
                    Stream stream = response.GetResponseStream();
                    Bitmap bitmap = new Bitmap(stream);
                    long jpegByteSize;
                    using (var ms = new MemoryStream(1)) 
                    {
                        bitmap.Save(ms, ImageFormat.Jpeg); 
                        jpegByteSize = ms.Length;
                    }
                    int netSpeed = (int)Math.Round((jpegByteSize * 1.0) / (dateTimeSecond - dateTimeFirst).Seconds);
                    try
                    {
                        if (netSpeed > 1024)
                        {
                            toolStripStatusLabelNetSpeed.Text = (netSpeed /= 1024).ToString() + "Kbyte/sec";
                        }
                        else
                        {
                            toolStripStatusLabelNetSpeed.Text = netSpeed.ToString() + "Byte/sec";
                        }
                    }
                    catch (InvalidOperationException e)
                    {
                        //TODO log it
                    }
                    try
                    {
                        pictureBox.Invoke(new Action(() => pictureBox.Size = bitmap.Size));
                        pictureBox.Invoke(new Action(() => pictureBox.Image = bitmap));
                        pictureBox.Invoke(new Action(() => pictureBox.Scale(imageScale)));
                    }
                    catch (InvalidOperationException e)
                    {
                        //TODO log it
                    }
                    
                    response.Close();
                    stream.Close();
                    return;
                }
                catch (WebException e)
                {
                    url = url.Replace(ends[index - 1], ends[index]);
                    index++;
                }
            }
            int y = 0;
        }

        public static void LoadThumbImageByUrlThread(string url, PictureBox pictureBox, ToolStripStatusLabel toolStripStatusLabelNetSpeed, ToolStripProgressBar tssProgressBar, int imageScale)
        {
            LoadImageByUrl(url, pictureBox, toolStripStatusLabelNetSpeed, imageScale);
            pictureBox.Invoke(new Action(() => tssProgressBar.PerformStep()));
        } 

        public static void LoadFullImageByUrlThread(string url, PictureBox pictureBox, ToolStripStatusLabel toolStripStatusLabelNetSpeed, Panel panelFull, FlowLayoutPanel flowLayoutPanel, ToolStripDropDown dropDown)
        {
            ToolStripStatusLabel tssLabelDownloadPage = (ToolStripStatusLabel)dropDown.Items[dropDown.Items.Count - 1];
            LoadImageByUrl(url, pictureBox, toolStripStatusLabelNetSpeed, 1);
            flowLayoutPanel.Invoke(new Action(() => flowLayoutPanel.Hide()));
            panelFull.Invoke(new Action(() => panelFull.Show()));
            dropDown.Invoke(new Action(() => dropDown.Items.Remove(tssLabelDownloadPage)));
        }
    }
}

// request.Accept = @"*/*";
//request.Proxy = webProxy;
//  request.Timeout = 20000;
//request.ContinueTimeout = 20000;
//request.ReadWriteTimeout = 32000;
// request.UseDefaultCredentials = true;
// request.ProtocolVersion = HttpVersion.Version11;
// request.Proxy.Credentials = CredentialCache.DefaultCredentials;
//  request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
//request.Accept = @"text/html,*/*";
// request.Accept = @"*/*";
//  request.Method = "GET";
//request.ContentType = @"text/html; charset=UTF-8";
//  request.Referer = "no-referrer-when-downgrade";
//  request.Headers.Add(@"accept-language: ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7");
//request.Headers.Add(@"dnt: 1");
//  request.Headers.Add(@"upgrade-insecure-requests: 1");
//  request.AllowAutoRedirect = true;
//request.KeepAlive = false;
