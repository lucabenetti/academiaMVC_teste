using CS.Application.Interface;
using CS.Application.Response;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CS.Api.Pages.Cadastro
{
    public class AlunoModel : BaseAuthorizePageModelModel
    {
        public List<AlunoResponse> Alunos { get; }
        private readonly IAlunoService _alunoService;

        public AlunoModel(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        public async Task<IActionResult> OnGet()
        {
            var alunos = await _alunoService.Obter();
            ViewData["alunos"] = JsonSerializer.Serialize(alunos);

            return Page();
        }
    }
}
