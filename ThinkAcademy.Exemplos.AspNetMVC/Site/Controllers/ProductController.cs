using System.Web.Mvc;
using System.Linq;

namespace Site.Controllers
{
    using Models;

    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var model = new VMProduct();

            model.Suppliers = new SelectListItem[]
            {
                new SelectListItem()
                {
                    Text = "Casa de Carne Bom Bife",
                    Value = "1"
                },
                new SelectListItem()
                {
                    Text = "João Porquinho",
                    Value = "2"
                },
                new SelectListItem()
                {
                    Text = "Bife de Ouro",
                    Value = "3"
                },
                new SelectListItem()
                {
                    Text = "Nelore de Prata",
                    Value = "4"
                }
            };

            return View(model);
        }

        public JsonResult FindProvider(string SearchProvider)
        {
            //Dados para caso não encontre nada, estamos listando todos os dados
            var suppliers = new SelectListItem[]
            {
                new SelectListItem()
                {
                    Text = "Casa de Carne Bom Bife",
                    Value = "1"
                },
                new SelectListItem()
                {
                    Text = "João Porquinho",
                    Value = "2"
                },
                new SelectListItem()
                {
                    Text = "Bife de Ouro",
                    Value = "3"
                },
                new SelectListItem()
                {
                    Text = "Nelore de Prata",
                    Value = "4"
                }
            };

            //Sua busca no banco, o simbolo ?? significa que se não encontrar nada irá considerar o objeto que está a frente do simbolo, ou seja, suppliers
            return Json((suppliers).Where(prop => prop.Text.ToUpper().Contains(SearchProvider.ToUpper())).ToArray() ?? suppliers);
        }
    }
}