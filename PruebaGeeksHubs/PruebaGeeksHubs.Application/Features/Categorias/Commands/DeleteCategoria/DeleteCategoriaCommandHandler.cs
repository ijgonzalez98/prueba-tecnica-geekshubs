using MediatR;
using PruebaGeeksHubs.Domain.Repositories;

namespace PruebaGeeksHubs.Application.Features.Categorias.Commands.DeleteCategoria
{
    public class DeleteCategoriaCommandHandler : IRequestHandler<DeleteCategoriaCommand, bool>
    {
        private readonly ICategoriasRepository _repository;

        public DeleteCategoriaCommandHandler(ICategoriasRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteCategoriaCommand request, CancellationToken cancellationToken)
        {
            var response = await _repository.DeleteCategoria(request.CategoriaId, cancellationToken);

            return await Task.FromResult(response);
        }
    }
}
