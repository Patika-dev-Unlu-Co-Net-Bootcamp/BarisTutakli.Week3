using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ProductOperations.Commands.Response
{
    public class UpdateProductCommandResponse
    {
        public bool IsSuccess { get; set; }
        public int Id { get; set; } 
        public DateTime ModifiedDate { get; set; }

    }
}
