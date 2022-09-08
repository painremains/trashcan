using System;
using System.ComponentModel.DataAnnotations;
using Bakehouse;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bakehouse.Models
{
    public class Bakery
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double CurrentPrice { get; set; }
        public bool InStock { get; set; }
        public string InStockStatus { get; set; }
        public string Type { get; set; }
        public DateTime BakeTime { get; set; }
        public int DiscountCounter { get; set; }
        public int Percent { get; set; }
        public double FuturePrice { get; set; }
        public DateTime FutureTime { get; set; }
    }
}
