using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.DAL.Models
{
    public class CartItemDAL
    {
        [Key]
        public Guid CartId { get; private set; }
        public int Quantity { get; set; }
        public int ItemId { get; set; }

        public CartItemDAL(Guid cartId, int itemId, int quantity)
        {
            CartId = cartId;
            Quantity = quantity;
            ItemId = itemId;    
        }

        public IList<ItemDAL> ItemDAL { get; set; }
    }
}
