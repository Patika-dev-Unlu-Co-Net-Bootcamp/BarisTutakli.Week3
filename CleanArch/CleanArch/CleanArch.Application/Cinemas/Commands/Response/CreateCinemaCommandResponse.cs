using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Cinemas.Commands.Response
{
    public class CreateCinemaCommandResponse
    {
        public bool IsSucces { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
