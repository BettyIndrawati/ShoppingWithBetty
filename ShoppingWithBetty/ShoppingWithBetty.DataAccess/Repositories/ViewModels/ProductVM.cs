using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingWithBetty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingWithBetty.DataAccess.Repositories.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; } = new Product();
        [ValidateNever]
        public IEnumerable<Product> Products { get; set; }= new List<Product>();
        [ValidateNever]
        public IEnumerable<SelectListItem> Catagories { get; set; }
    }
}
