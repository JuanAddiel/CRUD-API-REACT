using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApi.Core.Application.Interfaces.Repositories
{
    public interface IRepositoryAsync<T>:IRepositoryBase<T> where T : class
    {

    }
    public interface IReadRepositoryAsync<T>:IReadRepositoryBase<T>where T : class { }

}
