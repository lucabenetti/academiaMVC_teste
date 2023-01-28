using CS.Application.Model;
using FluentValidation;

namespace CS.Application.Validators
{
    public class TreinoModelValidator : AbstractValidator<TreinoModel>
    {
        public TreinoModelValidator()
        {
            RuleFor(x => x.AlunoId).NotEmpty();
            RuleFor(x => x.ExerciciosId).NotEmpty();
            //RuleFor(x => x.DiaDaSemana).NotEmpty();
        }
    }
}
