using CS.Application.Interface;
using CS.Application.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CS.Api.Pages.Cadastro
{
    public class ExercicioModel : PageModel
    {
        public List<ExercicioResponse> Exercicios { get; }

        private readonly IExercicioService _exercicioService;

        public ExercicioModel(IExercicioService exercicioService)
        {
            _exercicioService = exercicioService;
        }

        public async Task<IActionResult> OnGet()
        {
            var alunos = await _exercicioService.Obter();
            ViewData["exercicios"] = JsonSerializer.Serialize(alunos);

            return Page();
        }
    }
}
