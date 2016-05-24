using Site.Models;
using System.Web.Mvc;
namespace Site.Controllers
{
    public class ProductModelDropDownController : Controller
    {
        private IConnection connection;
        private DalSuppliers dal;
        public ProductModelDropDownController()
        {
            connection = new Connection();
            dal = new DalSuppliers(connection);
        }

        //Válido o Verb GET (Padrão)
        [HttpGet()]
        public ActionResult Create()
        {
            //Model padrão da página
            Local model = new Local() { Id = 1, Description = "Local 1", SupplierId = 3 };
            //DropDownList com Identificação do SupplierId = 3
            ViewData["SupplierId"] = new SelectList(dal.All(), "Id", "Name", model.SupplierId);            

            return View(model);
        }
    }
}