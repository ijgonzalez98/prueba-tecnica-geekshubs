using AutoMapper;
using MediatR;
using PruebaGeeksHubs.Application.DTOs.Responses;
using PruebaGeeksHubs.Domain.Entities;
using PruebaGeeksHubs.Domain.Repositories;

namespace PruebaGeeksHubs.Application.Features.Categorias.Queries.GetAllCategorias
{
    public class GetAllCategoriasQueryHandler : IRequestHandler<GetAllCategoriasQuery, List<CategoriaResponseDTO>>
    {
        private readonly ICategoriasRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCategoriasQueryHandler(ICategoriasRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoriaResponseDTO>> Handle(GetAllCategoriasQuery request, CancellationToken cancellationToken)
        {
            List<Categorium> categorias = await _repository.GetAllCategorias(cancellationToken);

            List<CategoriaResponseDTO> response = new();
            categorias.ForEach(c => response.Add(_mapper.Map<CategoriaResponseDTO>(c)));

            return await Task.FromResult(response);
        }
    }
}
