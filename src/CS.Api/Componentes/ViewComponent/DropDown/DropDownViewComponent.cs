namespace CS.Api.Componentes.ViewComponent.DropDown;

using CS.Api.Componentes.Builders;
using CS.Api.Componentes.Utilidades;
using Microsoft.AspNetCore.Mvc;


public class DropDownViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(DropDownBuilder options) => ObtenhaViewComponent(options);

        public IViewComponentResult ObtenhaViewComponent(DropDownBuilder options)
        {
            DropDownOptions dropdownOptions = options.Build();

            ViewBag.id = dropdownOptions.GetElementId;
            ViewBag.name = dropdownOptions.AspFor;
            ViewBag.defaultSelectMessage = dropdownOptions.DefaultSelectMessage;
            ViewBag.classList = string.Join(" ", dropdownOptions.ClassList);
            ViewBag.itens = dropdownOptions.TipoEnumerador is not null
                ? UtilidadesComponentes.ObtenhaValoresEnum(dropdownOptions.TipoEnumerador)
                : dropdownOptions.Itens ?? "";
            ViewBag.aoSelecionar = dropdownOptions.AoSelecionar;
            ViewBag.label = dropdownOptions.Label;

            return View();
        }
    }

