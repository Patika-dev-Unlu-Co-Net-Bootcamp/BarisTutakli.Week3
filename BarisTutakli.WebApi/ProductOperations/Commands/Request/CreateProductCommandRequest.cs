using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.ProductOperations.Commands.Response;

namespace WebApi.ProductOperations.Commands.Request
{
    public class CreateProductCommandRequest
    {
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
