using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_shop.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public List<Goods> Goods { get; set; }
        public Users User { get; set; }

        public Orders() 
        {
            Goods= new List<Goods>();
        }
    }
}