using Ardalis.Specification.EntityFrameworkCore;
using CrudApi.Core.Application.Interfaces.Repositories;
using CrudApi.Infrastructured.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApi.Infrastructured.Persistence.Repository
{
    public class MyRepositoryAsync<T>: RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly ApplicationContext _context;

        public MyRepositoryAsync(ApplicationContext context): base(context)
        {
            _context = context;
        }
    }
}
