using ServiceStack;
using ServiceBenchmark.Common;

namespace ServiceBenchmark.SvcStack
{

    public class ItemService : Service
    {
        public object Any(ItemRequest request)
        {
            return new ItemResponse
            {
                Item = new Item(request.ItemId, "Made in ServiceStack")
            };
        }
    }
}

