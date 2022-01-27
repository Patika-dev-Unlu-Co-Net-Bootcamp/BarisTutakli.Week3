using BarisTutakli.WebApi.Common;
using BarisTutakli.WebApi.DbOperations;
using BarisTutakli.WebApi.Models.Concrete;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Common.Base.Concrete;
using WebApi.ProductOperations.Queries.Request;
using WebApi.ProductOperations.Queries.Response;

namespace WebApi.ProductOperations.Handlers.QueryHandlers
{
    public class GetProductDetailQueryHandler
    {
        private readonly BaseReadRepository<Product, ECommerceDbContext> _readRepository;
        
        public int ProductId { get; set; }
        public GetProductDetailQueryHandler(BaseReadRepository<Product, ECommerceDbContext> baseReadRepository)
        {
            _readRepository = baseReadRepository;
        }
        public GetByIdProductQueryResponse Handle()
        {
            var product = _readRepository.Get(p => p.Id == ProductId);
            if (product is null)
            {
                throw new InvalidOperationException(Messages.NotFound);
            }
            return  new GetByIdProductQueryResponse
            {
                Id = ProductId,
                Category = ((CategoryEnum)product.CategoryId).ToString(),
                CreatedDate = product.CreatedDate,
                ProductName = product.ProductName,
                ModifiedDate = product.ModifiedDate,
                PublishDate = product.PublishDate,
                IsSuccess = true
            };
         
        }

   
    }
}
