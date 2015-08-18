using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Developer_Test
{
    class MetaDataItem
    {
        public Guid itemId { get; set; }
        public string title { get; set; }
        public string sourcePath { get; set; }
        public string contentType { get; set; }
        public string thumbnailPath { get; set; }
    }
}
