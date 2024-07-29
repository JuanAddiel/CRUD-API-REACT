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

namespace CrudApi.Core.Application.Features.Clients.Commands.DeleteClientCommand
{
    public class DeleteClientCommand:IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Response<int>>
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;

        public DeleteClientCommandHandler(IMapper mapper, IClientRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(client);
            return new Response<int>(client.Id);
        }
    }
}
