using CS.Application.Interface;
using CS.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CS.Api.Pages.Novo
{
    public class ExercicioNovoModel : PageModel
    {
        [Display(Name = "Tipo de exercício")]
        public EnumTipoExercicio TipoExercicio { get; }

        [Display(Name = "Grupo corporal")]
        public EnumGrupoExercicio GrupoExercicio { get; }

        private readonly IExercicioService _exercicioService;

        public ExercicioNovoModel(IExercicioService exercicioService)
        {
            _exercicioService = exercicioService;
        }

        public async Task<IActionResult> OnGet(string id)
        {
            if (id is null)
            {
                return Page();
            }

            ViewData["exercicio"] = await _exercicioService.ObterPorId(Guid.Parse(id));
            return Page();
        }
    }
}
