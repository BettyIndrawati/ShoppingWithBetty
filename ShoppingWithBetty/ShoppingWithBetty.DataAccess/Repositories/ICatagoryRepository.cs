using ShoppingWithBetty.Models;

namespace ShoppingWithBetty.DataAccess.Repositories
{
    public interface ICatagoryRepository : IRepository<Catagory>
    {
        void Update(Catagory catagory);
    }
}
