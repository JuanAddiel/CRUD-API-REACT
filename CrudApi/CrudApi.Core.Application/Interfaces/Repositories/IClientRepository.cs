using CrudApi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApi.Core.Application.Interfaces.Repositories
{
    public interface IClientRepository:IRepositoryAsync<Client>
    {
    }
}
