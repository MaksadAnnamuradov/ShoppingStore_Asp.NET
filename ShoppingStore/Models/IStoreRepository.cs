using ShoppingStore.Models;
using System.Linq;

namespace ShoppingStore.Models
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
    }
}
