﻿namespace AdamS.StoreTemp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal OrderTotal { get; set; }
    }
}