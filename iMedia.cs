using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Developer_Test
{
    interface iMedia
    {
        IEnumerable<MetaDataItem> GetAll();
        Guid AddItem(MetaDataItem item);
    }
}
