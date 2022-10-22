using ShoppingWithBetty.Models;

namespace ShoppingWithBetty.DataAccess.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
    }
}
