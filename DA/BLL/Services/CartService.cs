using CartApp.BLL.Interfaces;
using CartApp.BLL.Models;
using CartApp.DAL.Interfaces;
using CartApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.BLL.Services
{
    public class CartService : ICartService
    {
        public IList<CartItemsBLL> AddItem(Guid cartId, int itemId)
        {
            using IShoppingCartRepository shoppingCartRepository = new ShoppingCartRepository();
            using IItemService itemService = new ItemService();

            shoppingCartRepository.AddItem(itemId, cartId);
            var result = GenerateBLLCartItem(cartId, shoppingCartRepository, itemService);
            return result;
        }

        public IList<CartItemsBLL> GetAllItems(Guid cartId)
        {
            using IShoppingCartRepository shoppingCartRepository = new ShoppingCartRepository();
            using IItemService itemService = new ItemService();
            var result = GenerateBLLCartItem(cartId, shoppingCartRepository, itemService);
            return result;
        }

        public IList<CartItemsBLL> RemoveItem(Guid cartId, int itemId)
        {
            using IShoppingCartRepository shoppingCartRepository = new ShoppingCartRepository();
            using IItemService itemService = new ItemService();

            shoppingCartRepository.RemoveItem(itemId, cartId);
            var result = GenerateBLLCartItem(cartId, shoppingCartRepository, itemService);
            return result;
        }

        private List<CartItemsBLL> GenerateBLLCartItem(Guid cartId, IShoppingCartRepository shoppingCartRepository, IItemService itemService)
        {
            List<CartItemsBLL> result = new();
            var cartItemDAL = shoppingCartRepository.GetAllItems(cartId);
            var allItems = itemService.GetAllItems();
            foreach (var item in cartItemDAL)
            {
                result.Add(new CartItemsBLL() { Item = allItems.Single(a => a.ItemId == item.ItemId), Quantity = item.Quantity });
            }
            return result;
        }
    }
}
