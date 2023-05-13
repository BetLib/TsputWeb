using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class ApplicationDbContext : DbContext // DbContext - Стандартный класс конфигурации БД
    {
        public DbSet<Product> Products { get; set; } // Список пользователей в БД
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { } // Стандартный конструктор для конфигурации БД
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public"); // использовать схему "public"
            modelBuilder.Entity<Product>
                (b => {
                    b.ToTable("productss"); // DbUser хранится в таблице Users 
                    b.HasKey(u => u.Id); // Db имеет ключ Id 
                    b.Property(product => product.Id).HasColumnName("id"); // 
                    b.Property(product => product.Name).HasColumnName("name"); // 
                    b.Property(product => product.Description).HasColumnName("description"); //
                    b.Property(product => product.Price).HasColumnName("price"); //
                    b.Property(product => product.Isdeleted).HasColumnName("isdeleted"); //
                });
        }
    }
}
