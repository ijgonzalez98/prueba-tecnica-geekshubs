using AutoMapper;
using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;
using PruebaGeeksHubs.Domain.Entities;
using PruebaGeeksHubs.Domain.Repositories;

namespace PruebaGeeksHubs.Application.Features.Categorias.Queries.GetCategoriaById
{
    public class GetCategoriaByIdQueryHandler : IRequestHandler<GetCategoriaByIdQuery, CategoriaResponseDTO>
    {
        private readonly ICategoriasRepository _repository;
        private readonly IMapper _mapper;

        public GetCategoriaByIdQueryHandler(ICategoriasRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoriaResponseDTO> Handle(GetCategoriaByIdQuery request, CancellationToken cancellationToken)
        {
            Categorium categoria = await _repository.GetCategoriaById(request.CategoriaId, cancellationToken);

            if (categoria == null) throw new Exception("La categoría indicada no existe.");

            var response = _mapper.Map<CategoriaResponseDTO>(categoria);

            return await Task.FromResult(response);
        }
    }
}
