﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
