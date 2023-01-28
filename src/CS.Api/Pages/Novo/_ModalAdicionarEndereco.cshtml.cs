using CS.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS.Api.Pages.Novo
{
    public class _ModalAdicionarEndereco : PageModel
    {
        public EnumeradorEstado Estado { get; set; }
    }
}
