﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranSDK.DTO
{
    public class ProductRecipeDTO
    {
        public int ProductRecipeId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Value { get; set; }
    }
}
