using BarisTutakli.WebApi.Common;
using BarisTutakli.WebApi.Common.DataAccess;
using BarisTutakli.WebApi.DbOperations;
using BarisTutakli.WebApi.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
            } : new CreateProductCommandResponse
            {
                IsSuccess = false,
            };

        }
    }
}





//namespace WebApi.ProductOperations.Handlers.CommandHandlers
//{
//    public class CreateProductCommandHandler
//    {

//        private readonly ECommerceDbContext _dbcontext;
//        public CreateProductCommandHandler(ECommerceDbContext context)
//        {
//            _dbcontext = context;

//        }
//        public CreateProductCommandResponse Handle(CreateProductCommandRequest createProductCommandRequest)
//        {
//            var product = _dbcontext.Products.SingleOrDefault(product => product.ProductName == createProductCommandRequest.ProductName);
//            if (product is not null)
//                throw new InvalidOperationException(Messages.AlreadyExist);
//            _dbcontext.Products.Add(new Product()
//            {
//                CategoryId = createProductCommandRequest.CategoryId,
//                ProductName = createProductCommandRequest.ProductName,
//                PublishDate = createProductCommandRequest.PublishDate,
//                CreatedDate = DateTime.Now
//            });
//            _dbcontext.SaveChanges();

//            return new CreateProductCommandResponse
//            {
//                IsSuccess = true,
//            };
//        }
//    }
//}
