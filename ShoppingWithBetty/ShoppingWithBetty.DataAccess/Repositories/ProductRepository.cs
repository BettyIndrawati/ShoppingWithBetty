using ShoppingWithBetty.DataAccess.Data;
using ShoppingWithBetty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingWithBetty.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Product product)
        {
            var productDB = _context.Products.FirstOrDefault(s => s.Id == product.Id);
            if (productDB != null)
            {
                productDB.Name = product.Name;
                productDB.Description = product.Description;
                productDB.Price = product.Price;
                if (productDB.ImageUrl != null)
                {
                   productDB.ImageUrl = product.ImageUrl;
                }

            }
        }
    }
}
