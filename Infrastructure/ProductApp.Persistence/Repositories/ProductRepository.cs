﻿using ProductApp.Application.Repositories;
using ProductApp.Domain.Entities;
using ProductApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Persistence.Repositories
{
    public class ProductRepository:Repository<Product>,IProductRepository
    {
        public ProductRepository(ProductContext context):base(context) 
        {
            
        }
    }
}
