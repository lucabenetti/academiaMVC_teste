using CS.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CS.Api.Pages.Novo
{
    public class ProfessorNovoModel : BaseAuthorizePageModelModel
    {
        private readonly IProfessorService _professorService;

        public ProfessorNovoModel(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        public async Task<IActionResult> OnGet(string id)
        {
            if (id is null)
            {
                return Page();
            }

            ViewData["professor"] = await _professorService.ObterPorId(Guid.Parse(id));
            return Page();
        }
    }
}
