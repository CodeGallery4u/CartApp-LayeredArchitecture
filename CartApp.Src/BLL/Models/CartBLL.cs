using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.BLL.Models
{
    public class CartBLL
    {
        public Guid CartId { get; private set; }
        public CartBLL(Guid guid)
        {
            CartId = guid;
        }

        public IList<CartItemsBLL> Items { get; set; }
    }
}
