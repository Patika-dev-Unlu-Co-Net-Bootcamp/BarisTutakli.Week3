using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entity
{
    public class  Saloon:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
        public byte StartWeek { get; set; }
        public byte EndWeek { get; set; }
    }
}
