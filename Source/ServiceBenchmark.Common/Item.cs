using System;

namespace ServiceBenchmark.Common
{
    public class Item
    {
        public Guid ItemId { get; set; }
        public string Description { get; set; }
        public DateTime ModifiedAt { get; set; }

        public Item(Guid itemId, string description)
        {
            this.ItemId = itemId;
            this.Description = description;
            this.ModifiedAt = DateTime.UtcNow;
        }
    }

    public class ItemRequest
    {
        public Guid ItemId { get; set; }
    }

    public class ItemResponse
    {
        public Item Item { get; set; }
    }
}
