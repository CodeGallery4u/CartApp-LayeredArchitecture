using CartApp.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.BLL.Interfaces
{
    public interface ICartService
    {
        IList<CartItemsBLL> GetAllItems(Guid cartId);
        IList<CartItemsBLL> AddItem(Guid cartId, int itemId);
        IList<CartItemsBLL> RemoveItem(Guid cartId, int itemId);
    }
}
