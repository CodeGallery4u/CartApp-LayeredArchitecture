using CartApp.BLL.Models;
using CartApp.DAL.Interfaces;
using CartApp.DAL.Models;
using CartService.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.DAL.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {

        public bool AddItem(int ItemId, Guid cartId)
        {
            using CartAppDbContext dbContext = new();
            //Find item is present in cart
            var cartItem = dbContext.ShoppingCartItems.FirstOrDefault(a => a.ItemId == ItemId && a.CartId == cartId);
            if (cartItem == null)
            {
                var cartItemToBeAdded = new CartItemDAL(cartId, ItemId, 1);
                dbContext.ShoppingCartItems.Add(cartItemToBeAdded);
            }
            else
            {
                cartItem.Quantity += 1;
            }
            dbContext.SaveChanges();
            return true;
        }

        public void Dispose() { }

        public IList<CartItemDAL> GetAllItems(Guid cartId)
        {
            using CartAppDbContext dbContext = new();

            var cartItems = dbContext.ShoppingCartItems.Where(a => a.CartId == cartId).ToList();

            return cartItems;
        }

        public IList<CartItemDAL> RemoveItem(int itemId, Guid cartId)
        {
            using CartAppDbContext dbContext = new();
            var cartItemtoBeRemoved = dbContext.ShoppingCartItems.Single(a => a.CartId == cartId && a.ItemId == itemId);

            dbContext.ShoppingCartItems.Remove(cartItemtoBeRemoved);
            dbContext.SaveChanges();

            return GetAllItems(cartId);
        }
    }
}
