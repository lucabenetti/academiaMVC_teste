using CS.Application.Model;
using CS.Application.Response;
using CS.Core.Notificador;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using CS.Application.Interface;

namespace CS.Api.Controllers
{
    [Route("[controller]")]
    public class TreinoController : BaseController
    {
        private readonly ITreinoService _treinoService;

        public TreinoController(ITreinoService treinoService, INotificador notificador) : base(notificador)
        {
            _treinoService = treinoService;
        }

        [HttpPost, Authorize(Roles = "admin,professor")]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Response<Guid?>))]
        public async Task<IActionResult> Adicionar([FromBody] TreinoModel model)
        {
            Guid? response = await _treinoService.Adicionar(model);
            return CustomResponse(response);
        }

        [HttpDelete, Authorize(Roles = "admin,professor")]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Response<bool>))]
        public async Task<IActionResult> Remover([FromBody] RemoverEntidadeModel model)
        {
            await _treinoService.Remover(model);
            return CustomResponse(true);
        }

        [HttpPut, Authorize(Roles = "admin,professor")]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Response<bool>))]
        public async Task<IActionResult> Atualizar([FromBody] TreinoModel model)
        {
            await _treinoService.Atualizar(model);
            return CustomResponse(true);
        }

        [HttpGet("id"), Authorize(Roles = "admin,professor")]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Response<TreinoResponse>))]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            TreinoResponse response = await _treinoService.ObterPorId(id);
            return CustomResponse(response);
        }

        [HttpGet, Authorize(Roles = "admin,professor")]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Response<List<TreinoResponse>>))]
        public async Task<IActionResult> Obter()
        {
            List<TreinoResponse> response = await _treinoService.Obter();
            return CustomResponse(response);
        }

        [HttpGet("por-dia"), Authorize(Roles = "admin,aluno")]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Response<TreinoResponse>))]
        public async Task<IActionResult> ObterPorDia(Guid alunoId)
        {
            if (Equals(alunoId, default(Guid)))
            {
                string claimId = User.ObtenhaClaim("idAluno");
                alunoId = Guid.Parse(claimId);
            }

            TreinoResponse response = await _treinoService.ObterPorDia(alunoId);
            return CustomResponse(response);
        }
    }
}
