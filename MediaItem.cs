using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Basic_Developer_Test
{
    class MediaItem : iMedia
    {
        private List<MetaDataItem> items;
        private List<string> pngs;
        private string mediaPath;
        public MediaItem(string mediaPath)
        {
            if (!Directory.Exists(mediaPath)) throw new DirectoryNotFoundException(String.Format("Folder not found at path {0}", mediaPath));
            this.items = new List<MetaDataItem>();
            this.mediaPath = mediaPath;

            // load all pngs in media file.
            this.pngs = Directory.EnumerateFiles(this.mediaPath, "*.png").ToList();
        }

        /// <summary>
        /// GetAll
        /// <para>Returns internal data structure full of metadataitems.</para>
        /// </summary>
        /// <returns>An enumerable data structure.</returns>
        public IEnumerable<MetaDataItem> GetAll()
        {
            return items.AsEnumerable();
        }

        /// <summary>
        /// AddItem:
        /// <para>AddItem will add a meta data item to the inner data structure. A GUID will be assigned to 
        /// the item in the method and then returned. </para>
        /// </summary>
        /// <param name="item">A meta data description of some item.</param>
        /// <returns>An identifier to the item.</returns>
        public Guid AddItem(MetaDataItem item)
        {
            Guid identifer = new Guid();
            item.itemId = identifer;
            item.thumbnailPath = this.findThumbnailPath(item);
            items.Add(item);
            return identifer;
        }

        /// <summary>
        /// findThumbnailPath
        /// <para>Method will correlate a media item to a .png file. It is assumed that a media item
        /// thumbnail may exist with the file name in it somewhere.</para>
        /// </summary>
        /// <param name="item">The item to find a .png file for.</param>
        /// <returns>The path to the thumbnail file.</returns>
        private string findThumbnailPath(MetaDataItem item)
        {
            string filePath = "";
            if (item.sourcePath.Contains('\\')) filePath = item.sourcePath.Split('\\').Last();
            if (item.sourcePath.Contains('_'))
            {
                filePath = item.sourcePath.Split('_').First();
                filePath = this.pngs.FirstOrDefault(x => x.Contains(filePath));
            }
            return filePath;
        }
    }
}
