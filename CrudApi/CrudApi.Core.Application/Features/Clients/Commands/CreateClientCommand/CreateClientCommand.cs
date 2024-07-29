using AutoMapper;
using CrudApi.Core.Application.Interfaces.Repositories;
using CrudApi.Core.Application.Wrappers;
using CrudApi.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApi.Core.Application.Features.Clients.Commands.CreateClientCommand
{
    public class CreateClientCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Direction { get; set; }
    }
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Response<int>>
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;

        public CreateClientCommandHandler(IMapper mapper, IClientRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<int>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var newRegister = _mapper.Map<Client>(request);
            var data = await _repository.AddAsync(newRegister);
            return new Response<int>(data.Id);
        }
    }
}
