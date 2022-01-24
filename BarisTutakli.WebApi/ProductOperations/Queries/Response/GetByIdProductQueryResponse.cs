using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ProductOperations.Queries.Response
{
    public class GetByIdProductQueryResponse
    {

        public int Id { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Category { get; set; }
        public string ProductName { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
