using Site.Models;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class ProductSQLiteDropDownController : Controller
    {
        private IConnection connection;
        private DalSuppliers dal;
        public ProductSQLiteDropDownController()
        {
            connection = new Connection();
            dal = new DalSuppliers(connection);
        }

        //Válido o Verb GET (Padrão)
        [HttpGet()]
        public ActionResult Index()
        {
            ViewData["Suppliers"] = new SelectList(dal.All(), "Id", "Name");
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
                    return Json(dal.All());

                //Se houver dados filtra-los ...
                return Json(dal.All(name), JsonRequestBehavior.DenyGet);
            }
            return null;
        }
    }
}