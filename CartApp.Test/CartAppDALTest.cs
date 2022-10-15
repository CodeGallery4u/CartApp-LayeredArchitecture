using CartApp.DAL.Repositories;

namespace CartApp.Test
{
    public class CartAppDALTest
    {
        [Fact]
        public void ItemRepository_GetItem()
        {
            //arrange
            ItemRepository itemRepository = new();
            //assert
            var item = itemRepository.GetAllItems();
            //act
            Assert.True(item.Any());
        }

        [Fact]
        public void ShoppingCartRepositiry_AddItem()
        {
            //Arrange
            ItemRepository itemRepository = new();
            ShoppingCartRepository shoppingCartRepository = new();
            var cartId = Guid.NewGuid();

            //Act
            var allItems = itemRepository.GetAllItems();
            var firstItem = allItems[1];
            shoppingCartRepository.AddItem(firstItem.ItemId, cartId);

            var secondItem = allItems[2];
            shoppingCartRepository.AddItem(secondItem.ItemId, cartId);

            var cartItem = shoppingCartRepository.GetAllItems(cartId);

            //Assert
            Assert.Contains(cartItem, a =>a.ItemId == firstItem.ItemId);
        }

        [Fact]
        public void ShoppingCartRepositiry_AddItem_Twice_CehckQuantity()
        {
            //Arrange
            ItemRepository itemRepository = new();
            ShoppingCartRepository shoppingCartRepository = new();
            var cartId = Guid.NewGuid();

            //Act
            var allItems = itemRepository.GetAllItems();
            var firstItem = allItems[1];
            shoppingCartRepository.AddItem(firstItem.ItemId, cartId);

            var secondItem = allItems[1];
            shoppingCartRepository.AddItem(secondItem.ItemId, cartId);

            var cartItem = shoppingCartRepository.GetAllItems(cartId);

            //Assert
            Assert.True(cartItem[0].Quantity == 2);
        }

        [Fact]
        public void ShoppingCartRepository_RemoveItemFromCart()
        {
            //Arrange
            ItemRepository itemRepository = new();
            ShoppingCartRepository shoppingCartRepository = new();
            var cartId = Guid.NewGuid();

            //Act
            var allItems = itemRepository.GetAllItems();
            var firstItem = allItems[1];
            shoppingCartRepository.AddItem(firstItem.ItemId, cartId);

            var secondItem = allItems[2];
            shoppingCartRepository.AddItem(secondItem.ItemId, cartId);

            shoppingCartRepository.RemoveItem(secondItem.ItemId, cartId);

            var cartItem = shoppingCartRepository.GetAllItems(cartId);

            //Assert
            Assert.True(cartItem.Count == 1 && cartItem[0].ItemId == firstItem.ItemId);
        }
    }
}