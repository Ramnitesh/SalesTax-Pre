using System;
using System.Collections.Generic;
using System.Text;

namespace Makkajai_SalesTax.Models
{
    class MSalesItem
    {
        public int ItemId { get; set; }
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public string Price { get; set; }
        public bool IsImported { get; set; }
        public int NumberOfItem { get; set; }
    }
}
