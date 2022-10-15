using CartApp.BLL.Interfaces;
using CartApp.BLL.Models;
using CartApp.DAL.Interfaces;
using CartApp.DAL.Models;
using CartApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.BLL.Services
{
    public class ItemService : IItemService
    {
        public void Dispose() { }

        public List<ItemBLL> GetAllItems()
        {
            using IItemRepository itemRepository = new ItemRepository();
            List<ItemBLL> itemBLLList = new List<ItemBLL>();

            var itemDALList = itemRepository.GetAllItems();

            itemBLLList = itemDALList.
                Select(a =>
                new ItemBLL()
                {
                    ItemId = a.ItemId,
                    Name = a.Name,
                    ImageUrl = a.ImageUrl,
                    Price = a.Price
                }
            ).ToList();

            return itemBLLList;
        }
    }
}
