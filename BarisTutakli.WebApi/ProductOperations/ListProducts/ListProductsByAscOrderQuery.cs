namespace BarisTutakli.WebApi.ProductOperations.ListProducts
{
    using BarisTutakli.WebApi.DbOperations;
    using BarisTutakli.WebApi.Models.Concrete;
    using BarisTutakli.WebApi.ProductOperations.ListProducts.Abstract;
    using System.Collections.Generic;
    using System.Linq;

    public class ListProductsByAscOrderQuery : ListProductsQuery
    {

        //////////////// Bu kısım daha sonra düzenlenecek ///////////
        
        public ListProductsByAscOrderQuery(ECommerceDbContext context) : base(context)
        {
        }

        public override List<Product> Handle()
        {
            List<Product> orderedList = _context.Products.OrderBy(p => p.Id).ToList();
            return orderedList;
        }
    }
}
