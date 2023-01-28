using CS.Application.Model;
using CS.Application.Response;

namespace CS.Application.Interface
{
    public interface ITreinoService
    {
        Task<Guid?> Adicionar(TreinoModel model);
        Task Remover(RemoverEntidadeModel model);
        Task Atualizar(TreinoModel model);
        Task<TreinoResponse> ObterPorId(Guid id);
        Task<List<TreinoResponse>> Obter();
        Task<TreinoResponse> ObterPorDia(Guid alunoId);
    }
}
