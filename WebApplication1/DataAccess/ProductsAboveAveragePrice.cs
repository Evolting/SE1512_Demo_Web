﻿using System;
using System.Collections.Generic;

namespace WebApplication1.DataAccess
{
    public partial class ProductsAboveAveragePrice
    {
        public string ProductName { get; set; } = null!;
        public decimal? UnitPrice { get; set; }
    }
}
