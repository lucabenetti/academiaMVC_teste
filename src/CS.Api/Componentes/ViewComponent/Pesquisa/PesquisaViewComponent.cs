namespace CS.Api.Componentes.ViewComponent.Pesquisa;

using CS.Api.Componentes.Builders;
using Microsoft.AspNetCore.Mvc;

public class PesquisaViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(PesquisaBuilder options)
    {
        PesquisaOptions pesquisaForOptions = options.Build();

        ViewData["id"] = pesquisaForOptions.GetElementId;
        ViewData["name"] = $"{pesquisaForOptions.AspFor}.{pesquisaForOptions.KeyName}";
        ViewData["label"] = pesquisaForOptions.Label;
        ViewData["Tipo"] = pesquisaForOptions.TipoModel;
        ViewData["Action"] = pesquisaForOptions.Action;
        ViewData["Method"] = pesquisaForOptions.Method;
        ViewData["KeyName"] = pesquisaForOptions.KeyName;
        ViewData["ParametrosPesquisa"] = pesquisaForOptions.ParametrosPesquisa;
        ViewData["EhPesquisaServerSide"] = pesquisaForOptions.EhPesquisaServerSide;
        ViewData["FiltrarPor"] = pesquisaForOptions.FiltrarPor;
        ViewData["AoSelecionar"] = pesquisaForOptions.AoSelecionar;
        ViewData["AoApagar"] = pesquisaForOptions.AoApagar;

        return View();
    }
}

