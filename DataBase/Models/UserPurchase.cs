using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class UserPurchase
    {
        public int Id { get; set; } 
        public string UserId { get; set; }
        public string ProductId { get; set; }

        public decimal Price { get; set; }



    }
}
