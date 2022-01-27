using CleanArch.Domain.Interfaces;
using CleanArch.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICinemaRepository Cinema { get; }

        private readonly CinemaContext _cinemaContext;
        public UnitOfWork(CinemaContext cinemaContext, ICinemaRepository cinemaRepository)
        {
            _cinemaContext = cinemaContext;
            Cinema = cinemaRepository;
        }

        public async Task<int> SaveChanges()
        {
          return await _cinemaContext.SaveChangesAsync();

        }
    }
}
