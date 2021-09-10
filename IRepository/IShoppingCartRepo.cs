using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_InterfaceProject.IRepository
{
    public interface IShoppingCartRepo
    {
        Task<ShoppingCartItems> AddToCart(Guid sessionId, Guid shoppingCartId);
        Task<bool> RemoveFromCart(Guid sessionId, Guid shoppingCartId);
        Task<List<ShoppingCartItems>> GetShoppingCartItems(Guid shoppingCartId);
        Task<bool> ClearCart(Guid shoppingCartId);
        Task<decimal> GetShoppingCartTotal(Guid shoppingCartId);
    }
}
