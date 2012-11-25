using System;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;
using ServiceStack.Configuration;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.WebHost.Endpoints;
using ServiceBenchmark.Common;

namespace ServiceBenchmark.SvcStack
{
    #region Item Service

    public class ItemService : ServiceBase<ItemRequest>
    {
        protected override object Run(ItemRequest request)
        {
            return new ItemResponse
            {
                Item = new Item(request.ItemID, "Made in ServiceStack")
            };
        }
    }

    #endregion
}
