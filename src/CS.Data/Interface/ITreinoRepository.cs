using CS.Domain.Entidades;

namespace CS.Data.Interface
{
    public interface ITreinoRepository : IRepository<Treino>
    {
        Task<Treino> ObterPorDiaEAluno(Guid alunoId, DayOfWeek diaDaSemana);
    }
}
