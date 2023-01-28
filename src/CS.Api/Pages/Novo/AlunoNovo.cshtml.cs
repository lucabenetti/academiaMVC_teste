using CS.Application.Interface;
using CS.Application.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS.Api.Pages.Novo
{
    public class AlunoNovoModel : PageModel
    {
        private readonly IAlunoService _alunoService;

        public AlunoNovoModel(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        public async Task<IActionResult> OnGet(string id)
        {
            if (id is null)
            {
                return Page();
            }

            ViewData["aluno"] = await _alunoService.ObterPorId(Guid.Parse(id));
            return Page();
        }
    }
}
