﻿namespace ProductSearch.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public int Price { get; set; }
        public DateTime MfgDate { get; set; }
        public string Category { get; set; }
    }

}
