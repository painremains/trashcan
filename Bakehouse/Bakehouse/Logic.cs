using Bakehouse.Models;
using System.Collections.Generic;
using System;

namespace Bakehouse
{
    public class Logic
    {
        public void GetPrice(List<Bakery> products)
        {
            foreach (var item in products)
            {
                Calculate(item);
            }
        }
        private void Calculate(Bakery products)
        {
            var date = (DateTime.Now - products.BakeTime).Hours;
            if (products.Type == "other")
            {
                if (date > 8)
                {
                    products.InStock = false;
                    StockStatusChecker(products);
                }
                else
                {
                    products.CurrentPrice = CalculatePercent(products.Price, date * 2);
                    products.FuturePrice = Math.Round(CalculateFuturePrice(products.Price, products.CurrentPrice, 2), 1);
                    products.InStock = true;
                    StockStatusChecker(products);
                }
            }
            else if (products.Type == "eclair")
            {
                if (date > 5)
                {
                    products.InStock = false;
                    StockStatusChecker(products);
                }
                else
                {
                    if (products.DiscountCounter == 0)
                    {
                        products.Percent = 1;
                        CalcDiscount(0, date, products);
                    }
                    else
                    {
                        CalcDiscount(products.DiscountCounter, date, products);
                    }
                    products.CurrentPrice = CalculatePercent(products.Price, products.Percent);
                    products.FuturePrice = Math.Round(CalculatePercent(products.Price, products.Percent * 2), 1);
                    products.InStock = true;
                    StockStatusChecker(products);
                }
            }
            else if (products.Type == "cheesecake")
            {
                if (date > 6)
                {
                    products.InStock = false;
                    StockStatusChecker(products);
                }
                else
                {
                    products.CurrentPrice = CalculatePercent(products.Price, date, 4);
                    products.FuturePrice = Math.Round(CalculateFuturePrice(products.Price, products.CurrentPrice, 4), 1);
                    products.InStock = true;
                    StockStatusChecker(products);
                }
            }
        }
        private void CalcDiscount(int discountcounter, int date, Bakery products)
        {
            for (int i = discountcounter; i < date; i++)
            {
                products.DiscountCounter++;
                products.Percent = products.Percent * 2;
            }
        }
        private double CalculatePercent(double price, int percent)
        {
            var onepercent = ((price / 100));
            var currentpriceresult = price - onepercent * percent;
            return currentpriceresult;
        }
        private double CalculatePercent(double price, int percent, int multiplier = 0)
        {
            var onepercent = ((price / 100));
            var currentpriceresult = price - onepercent * multiplier * percent;
            return currentpriceresult;
        }
        private double CalculateFuturePrice(double price, double currentPrice, int multiplier = 0)
        {
            var percentage = ((price / 100) * multiplier);
            var futurepriceresult = currentPrice - percentage;
            return futurepriceresult;
        }
        public void FutureHour(List<Bakery> products)
        {
            foreach (var product in products)
            {
                var nexthour = DateTime.Now.Hour - product.BakeTime.Hour;
                product.FutureTime = product.BakeTime.AddHours(nexthour + 1);
            }
        }
        private void StockStatusChecker(Bakery products)
        {
            if (products.InStock) products.InStockStatus = "Есть в наличии";
            else products.InStockStatus = "Нет в наличии";
        }
    }
}
