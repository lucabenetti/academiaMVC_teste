using CS.Application.Validators;

namespace CS.Application.Model
{
    public class TreinoModel : BaseModel
    {
        private readonly TreinoModelValidator _validator;

        public Guid Id { get; set; }
        
        public Guid AlunoId { get; set; }

        public List<Guid> ExerciciosId { get; set; }

        public DayOfWeek DiaDaSemana { get; set; }

        public TreinoModel()
        {
            _validator = new TreinoModelValidator();
        }

        public override async Task<bool> EhValido()
        {
            var result = await _validator.ValidateAsync(this);
            return result.IsValid;
        }

        public override async Task<IEnumerable<string>> ObterErros()
        {
            var result = await _validator.ValidateAsync(this);
            return result.Errors.Select(x => x.ErrorMessage);
        }
    }
}
