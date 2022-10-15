using CartApp.BLL.Models;
using CartApp.BLL.Services;
using System;

namespace CartApp.Test
{
    public class CartAppBLLTest
    {
        [Fact]
        public void ItemService_GetAllItems()
        {
            //Arrange
            ItemService itemService = new();
            //Act
            var itemList =  itemService.GetAllItems();
            //Assert
            Assert.True(itemList.Count > 0);
            Assert.Equal(typeof(List<ItemBLL>), itemList.GetType());
        }

        [Fact]
        public void CartService_AddItemToCart()
        {
            //Arrange
            ItemService itemService = new();
            BLL.Services.CartService cartService = new();
            var cartId = Guid.NewGuid();
            var itemList = itemService.GetAllItems();
            var itemToBeAdded = itemList[0];
            //Act
            cartService.AddItem(cartId, itemToBeAdded.ItemId);
            var updatedCart = cartService.GetAllItems(cartId);
            //Assert
            Assert.True(itemToBeAdded.ItemId == updatedCart[0].Item.ItemId);
        }
    

        [Fact]
        public void CartService_RemoveItem()
        {
            //Arrange
            ItemService itemService = new();
            BLL.Services.CartService cartService = new();
            var cartId = Guid.NewGuid();
            var itemList = itemService.GetAllItems();
            var itemToBeAdded = itemList[0];
            //Act
            cartService.AddItem(cartId, itemToBeAdded.ItemId);
            var updatedCart = cartService.GetAllItems(cartId);
            cartService.RemoveItem(cartId, itemToBeAdded.ItemId);
            updatedCart = cartService.GetAllItems(cartId);
            //Assert
            Assert.True(updatedCart.Count == 0);
        }
    }
}
