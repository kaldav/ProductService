﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Contracts
{
    public class Product
    {
        public int id { get; set; }
        public int Price { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
