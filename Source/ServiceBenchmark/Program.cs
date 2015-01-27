using ServiceBenchmark.Common;
using ServiceStack;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ServiceBenchmark
{
    class Program
    {
        private const int NumberOfRequestsToSend = 10000;

        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start . . .");
            Console.ReadKey();

            TestServiceStack();
            TestWebApi();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit . . .");
            Console.ReadKey();
        }

        private static void ExecuteAction(string description, Action actionToExecute)
        {
            var sw = new Stopwatch();
            Console.Write(description.PadRight(45));
            sw.Start();
            actionToExecute();
            sw.Stop();
            Console.WriteLine(string.Format("{0} ms", sw.ElapsedMilliseconds).PadLeft(15));
        }

        private static void TestServiceStack()
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("ServiceStack");
            Console.WriteLine("------------------------------------------------------------");

            var client = new JsonServiceClient {BaseUri = new Uri("http://localhost:16227/").AbsoluteUri};

            ExecuteAction(NumberOfRequestsToSend + " requests to item/id", () =>
            {
                for (int i = 0; i < NumberOfRequestsToSend; i++)
                {
                    var response = client.Get<ItemResponse>("item/" + Guid.NewGuid());
                    if (response.Item == null)
                        throw new Exception("Item not received.");
                    //Console.WriteLine("ItemID\t\t{0}\nDescription\t{1}\nModifiedAt\t{2}", response.Item.ItemID, response.Item.Description, response.Item.ModifiedAt);
                }
            });
        }

        private static void TestWebApi()
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Web API");
            Console.WriteLine("------------------------------------------------------------");

            var client = new HttpClient {BaseAddress = new Uri("http://localhost:14851/")};

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            ExecuteAction(NumberOfRequestsToSend + " requests to api/item/id", () =>
            {
                for (int i = 0; i < NumberOfRequestsToSend; i++)
                {
                    var response = client.GetAsync("api/item/" + Guid.NewGuid()).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var item = response.Content.ReadAsAsync<Item>().Result;
                        if (item == null)
                            throw new Exception("Item not received.");
                        //Console.WriteLine("ItemID\t\t{0}\nDescription\t{1}\nModifiedAt\t{2}", item.ItemID, item.Description, item.ModifiedAt);
                    }
                    else
                    {
                        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    }
                }
            });
        }
    }
}
