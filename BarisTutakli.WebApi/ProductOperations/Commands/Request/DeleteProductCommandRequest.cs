using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.ProductOperations.Commands.Response;

namespace WebApi.ProductOperations.Commands.Request
{
    public class DeleteProductCommandRequest
    {
        public int Id { get; set; }
    }
}
