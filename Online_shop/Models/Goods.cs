using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_shop.Models
{
    public class Goods
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string PathToPicture { get; set; }

        public List<Categories> Categories { get; set; }
        public List<Orders> Orders { get; set; }

        public Goods()
        {
            Categories = new List<Categories>();
            Orders = new List<Orders>();
        }
    }

    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PathToPicture { get; set; }
        public List<Goods> Goods { get; set; }

        public Categories()
        {
            Goods = new List<Goods>();
        }
    }
}