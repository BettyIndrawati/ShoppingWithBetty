using ShoppingWithBetty.DataAccess.Data;
using ShoppingWithBetty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingWithBetty.DataAccess.Repositories
{
    public class CatagoryRepository :Repository<Catagory>, ICatagoryRepository
    {
        private ApplicationDbContext _context;
        public CatagoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context; 
        }

        public void Update(Catagory catagory)
        {
            var catagoryDB = _context.Catagories.FirstOrDefault(s => s.Id == catagory.Id);
            if (catagoryDB != null)
            {
                catagoryDB.Name = catagory.Name;    
                catagoryDB.DisplayOrder = catagory.DisplayOrder;    
            }
        }
    }
}
