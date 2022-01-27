using CleanArch.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface ICinemaRepository : IRepository<Cinema>
    {
        Task<Cinema> XXXXXX();
    }
}
