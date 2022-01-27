using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure
{
    public interface IUnitOfWork
    {
        public ICinemaRepository Cinema { get; }

        Task<int> SaveChanges();
    }
}
