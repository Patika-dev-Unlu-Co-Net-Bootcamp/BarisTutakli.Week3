using BarisTutakli.WebApi.DbOperations;
using BarisTutakli.WebApi.Models.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Common.Base.Concrete;
using WebApi.ProductOperations.Commands.Request;
using WebApi.ProductOperations.Commands.Response;

namespace WebApi.ProductOperations.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler
    {
        private readonly BaseDeleteRepository<Product, ECommerceDbContext> _baseDeleteRepository;
        private readonly BaseReadRepository<Product, ECommerceDbContext> _baseReadRepository;
        public int ProductId { get; set; }
        public DeleteProductCommandHandler(
            BaseDeleteRepository<Product, ECommerceDbContext> baseCreateRepository,
            BaseReadRepository<Product, ECommerceDbContext> baseReadRepository
            )
        {
            _baseDeleteRepository = baseCreateRepository;
            _baseReadRepository = baseReadRepository;
        }

        public  DeleteProductCommandResponse Handle()
        {
            var deletedProduct = _baseReadRepository.Get(p => p.Id == ProductId);

            if (deletedProduct is not null)
            {
                 _baseDeleteRepository.Delete(deletedProduct);
                return new DeleteProductCommandResponse
                {
                    IsSuccess = true,
                };
            }
            return  new DeleteProductCommandResponse
            {
                IsSuccess = false,
            };

        }

       
    }
}
