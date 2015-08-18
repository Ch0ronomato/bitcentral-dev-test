using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Developer_Test
{
    class Program
    {
        static string manifestLocation = "C:\\BasicDevTest\\item_manifest.txt";
        static string mediaLocation = @"C:\BasicDevTest\Media";
        static string outputLocation = @"C:\BasicDevTest\output.txt";
        static void Main(string[] args)
        {
            string[] manifestItems = File.ReadAllLines(manifestLocation);
            iMedia media = new MediaItem(mediaLocation);
            for (int i = 0; i < manifestItems.Length; i++)
            {
                string[] props = manifestItems[i].Split('|');
                if (props.Length != 3) continue;
                MetaDataItem metaData = new MetaDataItem()
                {
                    title = props[0],
                    contentType = props[1],
                    sourcePath = props[2]
                };
                media.AddItem(metaData);
            }

            // print everything out.
            foreach (MetaDataItem data in media.GetAll())
            {
                printMetaData(data);
            }
        }

        public static void printMetaData(MetaDataItem item)
        {
            string output = String.Format("Title: {0}\tType: {1}\tSource: {2}\tThumbnail: {3}", 
                item.title, item.contentType, item.sourcePath, item.thumbnailPath);

            Console.WriteLine(output);
            File.AppendAllText(outputLocation, output);
            File.AppendAllText(outputLocation, Environment.NewLine);
        }
    }
}
