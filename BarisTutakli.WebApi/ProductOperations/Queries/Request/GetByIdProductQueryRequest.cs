﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.ProductOperations.Queries.Response;

namespace WebApi.ProductOperations.Queries.Request
{
    public class GetByIdProductQueryRequest
    {
        public int Id { get; set; }
    }
}
