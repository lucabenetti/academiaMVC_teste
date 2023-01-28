using CS.Data.Interface;
using CS.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CS.Data.Repository
{
    public class TreinoRepository : RepositorioGenerico<Treino>, ITreinoRepository
    {
        public TreinoRepository(CsDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Treino> ObterPorDiaEAluno(Guid alunoId, DayOfWeek diaDaSemana)
        {
            return await Db.Treino.FirstOrDefaultAsync(x => x.AlunoId == alunoId && x.DiaDaSemana == diaDaSemana);
        }
    }
}
