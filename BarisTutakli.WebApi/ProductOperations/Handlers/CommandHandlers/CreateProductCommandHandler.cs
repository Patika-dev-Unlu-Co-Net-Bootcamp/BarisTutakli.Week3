using BarisTutakli.WebApi.DbOperations;
using BarisTutakli.WebApi.Models.Concrete;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Common.Base.Concrete;
using WebApi.ProductOperations.Commands.Request;
using WebApi.ProductOperations.Commands.Response;

namespace WebApi.ProductOperations.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler
    {


        public CreateProductCommandRequest Model { get; set; }
        private readonly BaseCreateRepository<Product, ECommerceDbContext> _createRepository;

        public CreateProductCommandHandler(BaseCreateRepository<Product, ECommerceDbContext> baseCreateRepository)
        {
            _createRepository = baseCreateRepository;
        }


        public CreateProductCommandResponse Handle()
        {
            var createdProductId = _createRepository.Create(new Product()
            {
                CategoryId = Model.CategoryId,
                ProductName = Model.ProductName,
                PublishDate = Model.PublishDate,
                CreatedDate = DateTime.Now
            });

            return createdProductId > 0 ? new CreateProductCommandResponse
            {
                IsSuccess = true,
                ProductId = createdProductId
            } : new CreateProductCommandResponse
            {
                IsSuccess = false,
            };
        }
    }
}


