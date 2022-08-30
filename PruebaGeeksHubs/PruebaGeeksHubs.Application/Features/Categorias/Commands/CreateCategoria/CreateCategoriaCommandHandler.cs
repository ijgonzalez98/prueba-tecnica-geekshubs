using AutoMapper;
using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;
using PruebaGeeksHubs.Domain.Entities;
using PruebaGeeksHubs.Domain.Repositories;

namespace PruebaGeeksHubs.Application.Features.Categorias.Commands.CreateCategoria
{
    public class CreateCategoriaCommandHandler : IRequestHandler<CreateCategoriaCommand, CategoriaResponseDTO>
    {
        private readonly ICategoriasRepository _repository;
        private readonly IMapper _mapper;

        public CreateCategoriaCommandHandler(ICategoriasRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoriaResponseDTO> Handle(CreateCategoriaCommand request, CancellationToken cancellationToken)
        {
            Categorium categoria = new()
            {
                Nombre = request.Nombre,
                Descripcion = request.Descripcion
            };

            var response = _mapper.Map<CategoriaResponseDTO>(await _repository.CreateCategoria(categoria, cancellationToken));

            return await Task.FromResult(response);
        }
    }
}
