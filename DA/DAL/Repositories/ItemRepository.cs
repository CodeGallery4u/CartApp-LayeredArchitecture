using CartApp.DAL.Interfaces;
using CartApp.DAL.Models;
using CartService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.DAL.Repositories
{
    public class ItemRepository : IItemRepository
    {
        public void Dispose(){}

        public List<ItemDAL> GetAllItems()
        {
            using (var db = new CartAppDbContext())
            {
                return db.Items.ToList();
            }
        }
    }
}
