using BarisTutakli.WebApi.Common;
using BarisTutakli.WebApi.DbOperations;
using BarisTutakli.WebApi.Models.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Common.Base.Concrete;
using WebApi.ProductOperations.Queries.Request;
using WebApi.ProductOperations.Queries.Response;

namespace WebApi.ProductOperations.Handlers.QueryHandlers
{
    public class GetProductsQueryHandler
    {
        private readonly BaseReadAllRepository<Product, ECommerceDbContext> _readAllRepository;
        public GetProductsQueryHandler(BaseReadAllRepository<Product, ECommerceDbContext> baseReadAllRepository)
        {
            _readAllRepository = baseReadAllRepository;
        }
        public  List<GetAllProductQueryResponse> Handle()
        {
            var  result = _readAllRepository.GetAll();
            if (result is null)
            {
                throw new InvalidOperationException(Messages.NotFound);
            }
            List<GetAllProductQueryResponse> products = new List<GetAllProductQueryResponse>();

            foreach (var product in result)
            {
                products.Add(new GetAllProductQueryResponse
                {
                    Id = product.Id,
                    Category = ((CategoryEnum)product.CategoryId).ToString(),
                    CreatedDate = product.CreatedDate,
                    ProductName = product.ProductName,
                    ModifiedDate = product.ModifiedDate,
                    PublishDate = product.PublishDate,
                    IsSuccess = true
                });
            }
            return products;


        }

      
    }
}
