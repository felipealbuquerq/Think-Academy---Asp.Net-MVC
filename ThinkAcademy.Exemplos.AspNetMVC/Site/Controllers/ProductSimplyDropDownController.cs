using System.Linq;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class ProductSimplyDropDownController : Controller
    {
        //Variavel Local
        private object[] lista = null;
        
        //Construtor
        public ProductSimplyDropDownController()
        {
            lista = new object[]
            {
                new {Id = 3, Name = "Bife de Ouro"},
                new {Id = 1, Name = "Casa de Carne Bom Bife"},                
                new {Id = 2, Name = "João Porquinho"},                
                new {Id = 4, Name = "Nelore de Prata"}
            };
        }

        //Válido o Verb GET (Padrão)
        [HttpGet()]
        public ActionResult Index()
        {
            //Form simples rápida para criar um DropDownList na tela...
            //Essa forma também ilustra um carregamento de itens da base de dados...
            ViewData["Suppliers"] = new SelectList(lista, "Id", "Name");
            return View();
        }

        //Válido o Verb Post
        [HttpPost()]
        public JsonResult Filter(string name)
        {
            //Verifica Modo Ajax ...
            if (Request.IsAjaxRequest())
            {
                //Se não for passado nada carrega lista sem filtro...
                if (string.IsNullOrEmpty(name))
                    return Json(lista);

                //Se houver dados filtra-los ...
                return Json(lista.Where(d => string.Format("{0}",
                    d.GetType()
                    .GetProperty("Name")
                    .GetValue(d))
                    .ToLower()
                    .Contains(name.ToLower())).ToArray(),
                    JsonRequestBehavior.DenyGet);
            }
            return null;
        }
    }
}