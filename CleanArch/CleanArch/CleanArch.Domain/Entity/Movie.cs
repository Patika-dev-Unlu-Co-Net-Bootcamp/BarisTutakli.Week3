using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entity
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public long Length { get; set; }
        public string Description { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<Saloon> Saloons { get; set; }
    }
}
