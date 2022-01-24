using BarisTutakli.WebApi.Common.Entities;
using System;

namespace BarisTutakli.WebApi.Models.Concrete
{
    public class Product:BaseEntity
    {
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public  DateTime PublishDate { get; set; }


    }
}
