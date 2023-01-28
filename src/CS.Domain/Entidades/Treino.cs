namespace CS.Domain.Entidades
{
    public class Treino : EntidadeBase
    {
        public Guid AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; }

        public virtual List<Exercicio> Exercicios { get; set; }

        public DayOfWeek DiaDaSemana { get; set; }
    }
}
