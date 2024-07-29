using CrudApi.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApi.Core.Domain.Entities
{
    public class Client:AuditableBaseEntity
    {
        private int _age;
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Direction { get; set; }
        public int Age
        {
            get
            {
                if(this._age <= 0)
                {
                    return _age = new DateTime(DateTime.Now.Subtract(this.BirthDate).Ticks).Year - 1;
                }
                return _age;
            }
        }
    }
}
