using Online_shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Online_shop.Data
{
    public class Online_shopContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Online_shopContext() : base("name=Online_shopContext")
        {
        }

        public System.Data.Entity.DbSet<Online_shop.Models.Goods> Goods { get; set; }

        public System.Data.Entity.DbSet<Online_shop.Models.Users> Users { get; set; }

        public System.Data.Entity.DbSet<Online_shop.Models.Categories> Categories { get; set; }

        public System.Data.Entity.DbSet<Online_shop.Models.Orders> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goods>()
                .HasMany(c => c.Categories)
                .WithMany(s => s.Goods)
                .Map(t => t.MapLeftKey("GoodsId")
                .MapRightKey("CategoryId")
                .ToTable("GoodsCategory"));

            modelBuilder.Entity<Goods>()
                .HasMany(c => c.Orders)
                .WithMany(s => s.Goods)
                .Map(t => t.MapLeftKey("GoodsId")
                .MapRightKey("OrderId")
                .ToTable("GoodsOrder"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
