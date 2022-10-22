namespace ShoppingWithBetty.DataAccess.Repositories
{
    public interface IUnitOfRole
    {
        ICatagoryRepository Catagory { get; } 
        IProductRepository Product { get; }
        void Save();
    }
}
