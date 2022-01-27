using BarisTutakli.WebApi.DbOperations;
using BarisTutakli.WebApi.Models.Concrete;
using System;
using WebApi.Common.Base.Concrete;
using WebApi.ProductOperations.Commands.Request;
using WebApi.ProductOperations.Commands.Response;

namespace WebApi.ProductOperations.Handlers.CommandHandlers
{
    public class UpdateProductCommandHandler
    {
        private readonly BaseReadRepository<Product, ECommerceDbContext> _baseReadRepository;
        private readonly BaseUpdateRepository<Product, ECommerceDbContext> _baseUpdateRepository;
        public int ProductId { get; set; }
        public UpdateProductCommandRequest Model { get; set; }
     
        public UpdateProductCommandHandler(
            BaseUpdateRepository<Product, ECommerceDbContext> baseUpdateRepository,
            BaseReadRepository<Product, ECommerceDbContext> baseReadRepository
            )
        {
            _baseUpdateRepository = baseUpdateRepository;
            _baseReadRepository = baseReadRepository;
        }

        public UpdateProductCommandResponse Handle()
        {
           
            var product = _baseReadRepository.Get(p => p.Id == ProductId);

            if (product is not null)
            {
                product.CategoryId = Model.CategoryId;
                product.ProductName = Model.ProductName;
                product.PublishDate = Model.PublishDate;
                product.ModifiedDate = DateTime.Now;
                _baseUpdateRepository.Update(product);


                return new UpdateProductCommandResponse
                {
                     Id=ProductId,
                    IsSuccess = true,
                    ModifiedDate= product.ModifiedDate,                   
                };
            }
            return new UpdateProductCommandResponse
            {
                IsSuccess = false,
            };

        }
    }
}
