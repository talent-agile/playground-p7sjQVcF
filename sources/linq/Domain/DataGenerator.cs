using System;
using System.Linq;

namespace Linq.Domain
{
    static class DataGenerator
    {
        public static Data GenerateData()
        {
            var data = new Data();
            data.Products = new Product[]
            {
                new Product()
                {
                    Category = Category.Computer,
                    Name = "Surface Book",
                    Price = 2000
                },
                new Product()
                {
                    Category = Category.Computer,
                    Name = "Mac book Pro",
                    Price = 2300
                },
                new Product()
                {
                    Category = Category.Computer,
                    Name = "Dell Latitude 14",
                    Price = 1300
                },
                new Product()
                {
                    Category = Category.Computer,
                    Name = "Dell XPS 15",
                    Price = 1800
                },
                new Product()
                {
                    Category = Category.Tablet,
                    Name = "iPad Mini",
                    Price = 300
                },
                new Product()
                {
                    Category = Category.Tablet,
                    Name = "iPad",
                    Price = 500
                },
                new Product()
                {
                    Category = Category.Tablet,
                    Name = "iPad Pro",
                    Price = 900
                },
                new Product()
                {
                    Category = Category.Phone,
                    Name = "iPhone 7",
                    Price = 900
                },
                new Product()
                {
                    Category = Category.Phone,
                    Name = "iPhone 7s",
                    Price = 1100
                },
                new Product()
                {
                    Category = Category.Phone,
                    Name = "Galaxy s8",
                    Price = 1100
                },
                new Product()
                {
                    Category = Category.Phone,
                    Name = "Galaxy s8+",
                    Price = 1100
                },
                new Product()
                {
                    Category = Category.Phone,
                    Name = "Nexus",
                    Price = 1000
                },
            };

            GeneratedData(data);


            return data;
        }

        private const int AccountCount = 500;
        private const int OrderCount = 100000;
        private const int MaxItemsCount = 5;

        private static int[] GetRandomUniqueSequence(Random random, int maxValue, int count)
        {
            var result = new int[count];

            for (var index = 0; index < count; index++)
            {
                do
                {
                    result[index] = random.Next(maxValue);
                }
                while (result.Take(index).Contains(result[index]));

            }
            return result;
        }

        private static void GeneratedData(Data data)
        {
            var regionList = new string[]
            {
                "FR",
                "UK",
                "ES",
                "US",
                "GE",
                "BE"
            };
            var random = new Random(42);
            data.Accounts = new Account[AccountCount];

            for (var i = 0;
                i < AccountCount;
                ++i)
            {
                var region = regionList[random.Next(regionList.Length)];
                data.Accounts[i] = new Account
                {
                    Id = i,
                    Region = region
                };
            }
            data.Orders = new Order[OrderCount];

            for (var orderIndex = 0; orderIndex < OrderCount; ++orderIndex)
            {

                var accountId = random.Next(AccountCount);
                var itemCount = Math.Max(1, random.Next(MaxItemsCount));

                var year = 2015 + random.Next(2);
                var month = random.Next(12) + 1;
                var order = new Order
                {
                    Account = data.Accounts[accountId],
                    Items = new OrderItem[itemCount],
                    Date = new Date(year, month)
                };

                data.Orders[orderIndex] = order;


                var productIds = GetRandomUniqueSequence(random, data.Products.Length, itemCount);

                for (var itemIndex = 0; itemIndex < itemCount; itemIndex++)
                {
                    order.Items[itemIndex] = new OrderItem
                    {
                        Product = data.Products[productIds[itemIndex]],
                        Count = Math.Max(1, random.Next(3))
                    };
                }

                order.Price = order.Items.Select(item => item.Product.Price * item.Count).Sum();

            }


        }
    }
}