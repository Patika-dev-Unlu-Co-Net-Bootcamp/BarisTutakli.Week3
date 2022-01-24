using BarisTutakli.WebApi.DbOperations;
using BarisTutakli.WebApi.Models.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.ProductOperations.ListProducts.Abstract
{
    public abstract class ListProductsQuery
    {
        public readonly ECommerceDbContext _context;
        public ListProductsQuery(ECommerceDbContext context)
        {
            _context = context;
        }
        public abstract List<Product> Handle();
     
    }
}
