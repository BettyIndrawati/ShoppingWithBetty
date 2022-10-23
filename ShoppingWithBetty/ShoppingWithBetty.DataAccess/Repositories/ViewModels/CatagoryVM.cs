using ShoppingWithBetty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingWithBetty.DataAccess.Repositories.ViewModels
{
    public class CatagoryVM
    {
        public Catagory Catagory { get; set; } = new Catagory();
        public IEnumerable<Catagory> catagories { get; set; }= new List<Catagory>();
    }
}
