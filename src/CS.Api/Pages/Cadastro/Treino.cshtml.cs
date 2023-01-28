using CS.Application.Interface;
using CS.Application.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;


namespace CS.Api.Pages.Cadastro
{
    public class TreinoModel : PageModel
    {
        public List<TreinoResponse> Treinos { get; }
        private readonly ITreinoService _treinoService;

        public TreinoModel(ITreinoService treinoService)
        {
            _treinoService = treinoService;
        }

        public async Task<IActionResult> OnGet()
        {
            List<TreinoResponse> treinos = await _treinoService.Obter();
            ViewData["treinos"] = JsonSerializer.Serialize(treinos);

            return Page();
        }
    }
}
