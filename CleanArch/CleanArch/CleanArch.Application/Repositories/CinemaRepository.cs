using CleanArch.Domain.Entity;
using CleanArch.Domain.Interfaces;
using CleanArch.Application;
using CleanArch.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Repositories
{
    public class CinemaRepository : Repository<Cinema>, ICinemaRepository
    {
        public CinemaRepository(CinemaContext context):base(context)
        {

        }
        public Task<Cinema> XXXXXX()
        {
            throw new NotImplementedException();
        }
    }
}
