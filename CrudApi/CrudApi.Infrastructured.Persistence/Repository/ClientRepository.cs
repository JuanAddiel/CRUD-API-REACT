using CrudApi.Core.Application.Interfaces.Repositories;
using CrudApi.Core.Domain.Entities;
using CrudApi.Infrastructured.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApi.Infrastructured.Persistence.Repository
{
    public class ClientRepository : MyRepositoryAsync<Client>, IClientRepository
    {
        private readonly ApplicationContext _context;
        public ClientRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
