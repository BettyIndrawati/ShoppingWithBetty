using Microsoft.EntityFrameworkCore;
using ShoppingWithBetty.DataAccess.Data;
using ShoppingWithBetty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingWithBetty.DataAccess.Repositories
{
    public class UnitOfRole : IUnitOfRole
    {
        private ApplicationDbContext _context;

        public ICatagoryRepository Catagory { get; private set; }
        public IProductRepository Product { get; private set; }

        public UnitOfRole(ApplicationDbContext context)
        {
            _context = context;
            Catagory = new CatagoryRepository(context);
            Product = new ProductRepository(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
   
    
}

