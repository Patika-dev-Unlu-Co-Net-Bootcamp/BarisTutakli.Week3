using CleanArch.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Cinemas.Commands.Request
{
    public class CreateCinemaCommandRequest
    {
        public string Name { get; set; }
        public ICollection<Saloon> Saloons { get; set; }
        public string Address { get; set; }
    }
}
