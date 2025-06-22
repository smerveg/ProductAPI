using ProductApp.Application.Repositories;
using ProductApp.Domain.Entities;
using ProductApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductContext context) : base(context)
        {
        }
    }
}
