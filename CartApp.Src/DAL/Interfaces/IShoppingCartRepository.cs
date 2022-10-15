using CartApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.DAL.Interfaces
{
    public interface IShoppingCartRepository: IDisposable
    {
        bool AddItem(int itemId, Guid cartId);
        IList<CartItemDAL> RemoveItem(int itemId, Guid cartId);
        IList<CartItemDAL> GetAllItems(Guid cartId);
    }
}
