using CartApp.BLL.Models;
using CartApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.BLL.Interfaces
{
    public interface IItemService: IDisposable
    {
        List<ItemBLL> GetAllItems();
    }
}
