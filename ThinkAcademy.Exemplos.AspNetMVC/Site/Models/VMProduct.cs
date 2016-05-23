using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Site.Models
{
    public class VMProduct
    {
        [Display(Name = "Filtrar Fornecedor")]
        public string SearchSupplier { get; set; }

        [Display(Name = "Fornecedor")]
        [Required]
        public SelectListItem[] Suppliers { get; set; }
    }
}
