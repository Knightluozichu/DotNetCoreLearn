using System.Linq;

namespace SportsStore.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private StoreDbContext context;
        public IQueryable<Product> Products => context.Products;

        public EFStoreRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        void IStoreRepository.SaveProduct(Product p)
        {
            context.SaveChanges();
        }

        void IStoreRepository.CreateProduct(Product p)
        {
            context.Add(p);
            context.SaveChanges();
        }

        void IStoreRepository.DeleteProduct(Product p)
        {
            context.Remove(p);
            context.SaveChanges();
        }
    }
}