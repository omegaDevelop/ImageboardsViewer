using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ImageboardsViewer
{
    public enum PageDirection { first, next, back, current }

    public class TbibParser
    {
        public bool FiltrateArtist { get; set; }
        public int Padeindex { get; set; }
        public int PageCount { get; set; }
        public List<MyImage> ImagesList { get; set; }

        public TbibParser(bool FiltrateArtist)
        {
            this.FiltrateArtist = FiltrateArtist;
        }

        public string[] GetTagCategorAndWeight(string tagName)
        {
            var document = new HtmlParser()
               .Parse(HTMLDownloader.GetContentByLink("http://tbib.org/index.php?page=post&s=list&tags=" + tagName));
            IEnumerable<IElement> listItemsLinq = document.All.
               Where(m => (m.ClassName == "tag-type-copyright"
               | m.ClassName == "tag-type-character"
               | m.ClassName == "tag-type-artist"
               | m.ClassName == "tag-type-general") && m.Children[2].TextContent.Replace(" ", "_").Equals(tagName));
            string tagCategory = "";
            if (listItemsLinq.Count() != 0)
            {
                switch (listItemsLinq.ElementAt(0).ClassName.ToString())
                {
                    case "tag-type-copyright":
                        tagCategory = "copyright";
                        break;
                    case "tag-type-character":
                        tagCategory = "character";
                        break;
                    case "tag-type-artist":
                        tagCategory = "artist";
                        break;
                    case "tag-type-general":
                        tagCategory = "general";
                        break;
                }
                return new string[] { tagCategory, listItemsLinq.ElementAt(0).Children[3].TextContent };
            }
            return new string[] { "????", "????" };
        }

        private void LoadPageImagesFromWeb(string searchQuery, int pageIncrementValue, DataTable filtrateTags) //"tag1" or "tag1+tag+..etc"
        {

            Padeindex +=pageIncrementValue;
            ImagesList = new List<MyImage>();
            IHtmlDocument document = new HtmlParser()
                .Parse(HTMLDownloader
                .GetContentByLink("http://tbib.org/index.php?page=post&s=list&tags=" + searchQuery + "&pid=" + Padeindex));
            IEnumerable<IElement> lastPageItems = document.All.Where(m => m.TextContent == ">>");
            if(lastPageItems.Count() > 0)
            {
                string pc = lastPageItems.ElementAt(0).Attributes.ElementAt(0).Value;
                PageCount = Convert.ToInt32(pc.Remove(0, pc.IndexOf("d=") + 2)) + 42;
            }
            else PageCount = 42; 
            string imageId = "";
            string[] tags;
            List<string> s = filtrateTags.AsEnumerable().Select(x => x[0].ToString()).ToList();
            IEnumerable<IElement> listItemsLinq = document.All.Where(m => m.ClassName == "preview");
            foreach (var imageItem in listItemsLinq)
            {
                imageId = imageItem.Attributes.ElementAt(0).Value;  //.jpg?
                imageId = imageId.Remove(0, imageId.IndexOf(".jpg?") + 5);
                tags = imageItem.Attributes.ElementAt(1).Value.Replace("\n", "").Split(' ');
                if (FiltrateArtist == false || (s.Intersect(tags)).Count() < 1 ) ImagesList.Add(new MyImage(imageId, imageItem));
            }
        }

        public void LoadPageImagesFromWeb(string searchQuery, PageDirection pageDirection, DataTable filtrateTags) //"tag1" or "tag1+tag+..etc"
        {
            switch (pageDirection)
            {
                case PageDirection.first:
                    LoadPageImagesFromWeb(searchQuery, -Padeindex, filtrateTags);
                    break;
                case PageDirection.next:
                    LoadPageImagesFromWeb(searchQuery, 42, filtrateTags);
                    break;
                case PageDirection.back:
                    LoadPageImagesFromWeb(searchQuery, -42, filtrateTags);
                    break;
                case PageDirection.current:
                    LoadPageImagesFromWeb(searchQuery, 0, filtrateTags);
                    break;
            }
        }

        public DataTable GetImageTags(int imageIndex)
        {
            DataTable imageTagsTable = new DataTable();
            imageTagsTable.Columns.Add("name");
            imageTagsTable.Columns.Add("category");
            imageTagsTable.Columns.Add("weight");
            if (ImagesList.ElementAt(imageIndex).TagsCount() > 0)
            {
                imageTagsTable = ImagesList.ElementAt(imageIndex).GetTags();
            }
            else
            {
                IHtmlDocument document = new HtmlParser()
                .Parse(HTMLDownloader.GetContentByLink(ImagesList.ElementAt(imageIndex).PageUrl));
                IEnumerable<IElement> listItemsLinq = document.All.
                   Where(m => m.ClassName == "tag-type-copyright tag"
                   | m.ClassName == "tag-type-character tag"
                   | m.ClassName == "tag-type-artist tag"
                   | m.ClassName == "tag-type-general tag");
                foreach (var item in listItemsLinq)
                {
                    imageTagsTable.Rows.Add(new string[] {
                        item.Children[0].TextContent.Replace(" ", "_"),
                        item.ClassName.Replace("tag-type-", "").Replace(" tag", ""),
                        item.Children[1].TextContent });

                    if (item.ClassName == "tag-type-artist tag")
                    {
                        ImagesList.ElementAt(imageIndex).Artist = item.Children[0].TextContent.Replace(" ", "_");
                    }
                }
                ImagesList.ElementAt(imageIndex).AddTags(imageTagsTable);
            }
            return imageTagsTable;
        }

        public int GetImagesCount() { return ImagesList.Count; }
        public int GetImageTagsCount(int imageIndex) { return ImagesList.ElementAt(imageIndex).TagsCount(); }
        public string GetImageUrl(int imageIndex) { return ImagesList.ElementAt(imageIndex).Url; }
        public string GetImageThumbUrl(int imageIndex) { return ImagesList.ElementAt(imageIndex).ThumbUrl; }
        public string GetImageId(int imageIndex) { return ImagesList.ElementAt(imageIndex).Id; }
        public string GetImageArtist(int imageIndex) { return ImagesList.ElementAt(imageIndex).Artist; }
       /* public string[] GetImageTag(int imageIndex, int tagIndex)
        {
            return new string[] { PageImagesList.ElementAt(imageIndex).GetImageTag(tagIndex), PageImagesList.ElementAt(imageIndex).GetImageTagWeight(tagIndex) };
        }*/
    }
}
