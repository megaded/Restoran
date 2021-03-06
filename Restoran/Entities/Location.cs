﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran
{
    /// <summary>
    /// Локация
    /// </summary>
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MarketId { get; set; }
        public virtual Market Market { get; set; }
        public virtual ICollection<ProductStorage> Products { get; set; }
        public virtual ICollection<Order> Orders { get; set; }   
        public virtual ICollection<Recipe> Recipes { get; set; }  
        public virtual ICollection<ProductDisposal> ProductDisposal { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public Location()
        {
            Products = new List<ProductStorage>();
            Orders = new List<Order>();
            Recipes = new List<Recipe>();
            ProductDisposal = new List<ProductDisposal>();
            Invoices = new List<Invoice>();
        }
    }
}
