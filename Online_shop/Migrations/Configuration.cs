namespace Online_shop.Migrations
{
    using Online_shop.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Online_shop.Data.Online_shopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Online_shop.Data.Online_shopContext context)
        {
            /*Goods g1 = new Goods { Id = 4, Name = "Рюкзак Химико Тога", Description = "", PathToPicture = "../../Files/10.jpg", Price = 2000 };
            Goods g2 = new Goods { Id = 5, Name = "Рюкзак Мидория Узуку", Description = "", PathToPicture = "../../Files/13.jpg", Price = 1000 };
            Goods g3 = new Goods { Id = 6, Name = "Футболка Моя геройская академия", Description = "", PathToPicture = "../../Files/14.jpg", Price = 3000 };
            Goods g4 = new Goods { Id = 7, Name = "Подушки", Description = "", PathToPicture = "../../Files/9.jpg", Price = 6000 };
            Goods g5 = new Goods { Id = 8, Name = "Рюкзаки", Description = "", PathToPicture = "../../Files/5.jpg", Price = 4000 };

            context.Goods.Add(g1);
            context.Goods.Add(g2);
            context.Goods.Add(g3);
            context.Goods.Add(g4);
            context.Goods.Add(g5);

            Categories c1 = new Categories { Id = 3, Name = "Футболки", PathToPicture = "../../Files/1.jpg", Goods = new List<Goods> { g1, g2, g3 } };
            Categories c2 = new Categories { Id = 4, Name = "Светильники", PathToPicture = "../../Files/1.jpg", Goods = new List<Goods> { g4, g1, g5 } };
            Categories c3 = new Categories { Id = 5, Name = "Рюкзаки", PathToPicture = "../../Files/1.jpg", Goods = new List<Goods> { g3, g1, g4 } };

            context.Categories.Add(c1);
            context.Categories.Add(c2);
            context.Categories.Add(c3);

            base.Seed(context);*/
        }
    }
}
