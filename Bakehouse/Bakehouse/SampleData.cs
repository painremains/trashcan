using System;
using System.Linq;
using Bakehouse.Models;
using Bakehouse;

namespace Bakehouse
{
    public static class SampleData
    {
        public static void Initialize(BakeContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Bakery
                    {
                        Name = "Круассан",
                        Price = 90,
                        Type = "other",
                        BakeTime = DateTime.Now - TimeSpan.FromHours(1),
                    },
                    new Bakery
                    {
                        Name = "Круассан",
                        Price = 90,
                        Type = "other",
                        BakeTime = DateTime.Now - TimeSpan.FromHours(9),
                    },
                    new Bakery
                    {
                        Name = "Крендель",
                        Price = 50,
                        Type = "other",
                        BakeTime = DateTime.Now - TimeSpan.FromHours(1),
                    },
                    new Bakery
                    {
                        Name = "Багет",
                        Price = 140,
                        Type = "other",
                        BakeTime = DateTime.Now - TimeSpan.FromHours(1),
                    },
                    new Bakery
                    {
                        Name = "Сметанник",
                        Price = 250,
                        Type = "cheesecake",
                        BakeTime = DateTime.Now - TimeSpan.FromHours(2),
                    },
                    new Bakery
                    {
                        Name = "Сметанник",
                        Price = 250,
                        Type = "cheesecake",
                        BakeTime = DateTime.Now - TimeSpan.FromHours(7),
                    },
                    new Bakery
                    {
                        Name = "Батон",
                        Price = 40,
                        Type = "other",
                        BakeTime = DateTime.Now - TimeSpan.FromHours(1),
                    },
                    new Bakery
                    {
                        Name = "Эклер",
                        Price = 70,
                        Type = "eclair",
                        BakeTime = DateTime.Now - TimeSpan.FromHours(2),
                        DiscountCounter = 1,
                        Percent = 2,
                    },
                    new Bakery
                    {
                        Name = "Эклер",
                        Price = 70,
                        Type = "eclair",
                        BakeTime = DateTime.Now - TimeSpan.FromHours(6),
                        DiscountCounter = 1,
                        Percent=2,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}