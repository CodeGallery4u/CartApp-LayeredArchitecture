using CartApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.DAL.Interfaces
{
    internal interface IItemRepository : IDisposable
    {
        List<ItemDAL> GetAllItems();
    }
}
