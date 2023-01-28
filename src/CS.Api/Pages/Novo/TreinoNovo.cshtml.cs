using CS.Application.Interface;
using CS.Application.Response;
using CS.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CS.Api.Pages.Novo
{
    public class TreinoNovoModel : PageModel
    {
        public AlunoResponse Aluno { get; }
        public List<ExercicioResponse> Exercicios { get; }

        public EnumDiaSemana DiaSemana { get; }

        private readonly IExercicioService _exercicioService;
        private readonly ITreinoService _treinoService;

        public TreinoNovoModel(IExercicioService exercicioService, ITreinoService treinoService)
        {
            _exercicioService = exercicioService;
            _treinoService = treinoService;
        }

        public async Task<IActionResult> OnGet(string id)
        {
            List<ExercicioResponse> exercicios = await _exercicioService.Obter();
            ViewData["exercicios"] = exercicios;

            if (id is null)
            {
                return Page();
            }

            ViewData["treino"] = await _treinoService.ObterPorId(Guid.Parse(id));

            return Page();
        }
    }
}
