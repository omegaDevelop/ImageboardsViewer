using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ImageboardsViewer
{
    public class MyImage
    {
        public string PageUrl { get; }
        public string Url { get; }
        public string ThumbUrl { get; }
        public string Id { get; set; }
        public string Artist { get; set; }
        private DataTable tagsTable;

        public MyImage(string id, IElement imageItem)
        {
            Id = id;
            PageUrl = "https://tbib.org/index.php?page=post&s=view&id=" + id;
            ThumbUrl = "https:" + imageItem.Attributes.ElementAt(0).Value;
            Url = ThumbUrl.Remove(ThumbUrl.IndexOf('?'))
                               .Replace("thumbnails", "images")
                               .Replace("thumbnail_", "");
            Artist = "";
            tagsTable = new DataTable();
        }

        public DataTable GetTags() { return tagsTable; }
        public void AddTags(DataTable imageTagsTable) { tagsTable = imageTagsTable; }
        public int TagsCount() { return tagsTable.Rows.Count; }
    }
}
