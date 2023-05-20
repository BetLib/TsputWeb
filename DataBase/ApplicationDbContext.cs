
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class ApplicationDbContext : DbContext // DbContext - Стандартный класс конфигурации БД
    {
        public DbSet<DbUser> Users { get; set; } // Список пользователей в БД
        public DbSet<Product> Products { get; set; } // Список пользователей в БД
        public DbSet<UserPurchase> UserPurchases { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { } // Стандартный конструктор для конфигурации БД
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public"); // использовать схему "public"
            modelBuilder.Entity<DbUser>
                (b => {
                    b.ToTable("users"); // DbUser хранится в таблице Users 
                    b.HasKey(u => u.Id); // DbUser имеет ключ Id 
                    b.Property(user => user.Id).HasColumnName("id"); // Свойство Id хранится в колонке "id"
                    b.Property(user => user.Login).HasColumnName("login"); // Свойство Login хранится в колонке "login"
                    b.Property(user => user.UserName).HasColumnName("name"); // Свойство Name хранится в колонке "name"
                    b.Property(user => user.Isdeleted).HasColumnName("isdeleted"); // Свойство Name хранится в колонке "name"
                    b.Property(user => user.Password).HasColumnName("password"); // Свойство Name хранится в колонке "name"
                });
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
            modelBuilder.Entity<UserPurchase>
            (b => {
                b.ToTable("userpurchase"); // DbUser хранится в таблице Users 
                b.HasKey(u => u.Id); // Db имеет ключ Id 
                b.Property(userpurchase => userpurchase.Id).HasColumnName("id"); // 
                b.Property(userpurchase => userpurchase.UserId).HasColumnName("userid"); // 
                b.Property(userpurchase => userpurchase.ProductId).HasColumnName("productid"); //
                b.Property(userpurchase => userpurchase.Price).HasColumnName("price"); //
              
            });
        }
    }
}
