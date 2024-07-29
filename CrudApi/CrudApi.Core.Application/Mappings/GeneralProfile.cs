using AutoMapper;
using CrudApi.Core.Application.Features.Clients.Commands.CreateClientCommand;
using CrudApi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApi.Core.Application.Mapping
{
    public class GeneralProfile:Profile
    {
        public GeneralProfile()
        {
            #region Client
            CreateMap<CreateClientCommand, Client>();
            #endregion
        }
    }
}
