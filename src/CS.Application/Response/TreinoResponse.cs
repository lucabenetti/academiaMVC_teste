namespace CS.Application.Response
{
    public class TreinoResponse
    {
        public Guid Id { get; set; }

        public AlunoResponse Aluno { get; set; }

        public IEnumerable<ExercicioResponse> Exercicios { get; set; }

        public DayOfWeek DiaDaSemana { get; set; }
    }
}