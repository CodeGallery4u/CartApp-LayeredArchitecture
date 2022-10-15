using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApp.DAL.Models
{
    public class ItemDAL
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public IList<CartItemDAL> CartItemDAL { get; set; }
    }
}
