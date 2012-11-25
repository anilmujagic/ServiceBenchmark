using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceBenchmark.Common
{
    public class Item
    {
        public Guid ItemID { get; set; }
        public string Description { get; set; }
        public DateTime ModifiedAt { get; set; }

        public Item(Guid itemID, string description)
        {
            this.ItemID = itemID;
            this.Description = description;
            this.ModifiedAt = DateTime.UtcNow;
        }
    }

    public class ItemRequest
    {
        public Guid ItemID { get; set; }
    }

    public class ItemResponse
    {
        public Item Item { get; set; }
    }
}
