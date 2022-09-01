using AutoMapper;
using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;
using PruebaGeeksHubs.Domain.Entities;
using PruebaGeeksHubs.Domain.Repositories;

namespace PruebaGeeksHubs.Application.Features.Categorias.Commands.UpdateCategoria
{
    public class UpdateCategoriaCommandHandler : IRequestHandler<UpdateCategoriaCommand, CategoriaResponseDTO>
    {
        private readonly ICategoriasRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCategoriaCommandHandler(ICategoriasRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoriaResponseDTO> Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
        {
            Categorium categoria = await _repository.GetCategoriaById<Categorium>(request.CategoriaId, cancellationToken);

            if (categoria == null) return null;

            categoria.Nombre = request.Data.Nombre ?? categoria.Nombre;
            categoria.Descripcion = request.Data.Descripcion ?? categoria.Descripcion;

            var response = _mapper.Map<CategoriaResponseDTO>(await _repository.UpdateCategoria(categoria, cancellationToken));

            return await Task.FromResult(response);
        }
    }
}
