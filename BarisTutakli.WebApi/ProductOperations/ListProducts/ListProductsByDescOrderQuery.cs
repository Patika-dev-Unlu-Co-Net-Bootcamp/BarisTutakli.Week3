using BarisTutakli.WebApi.DbOperations;
using BarisTutakli.WebApi.Models.Concrete;
using BarisTutakli.WebApi.ProductOperations.ListProducts.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.ProductOperations.ListProducts
{
    public class ListProductsByDescOrderQuery : ListProductsQuery
    {
        public ListProductsByDescOrderQuery(ECommerceDbContext context) : base(context)
        {

        }

        public override List<Product> Handle()
        {
            List<Product> orderedList = _context.Products.OrderByDescending(p => p.Id).ToList();
            return orderedList;
        }
    }
}
