﻿using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class ApplicationDbContext : DbContext // DbContext - Стандартный класс конфигурации БД
    {
        public DbSet<DbUser> Users { get; set; } // Список пользователей в БД
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { } // Стандартный конструктор для конфигурации БД
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.HasDefaultSchema("public"); // использовать схему "public"
            modelBuilder.Entity<DbUser>
                (b => { b.ToTable("users"); // DbUser хранится в таблице Users 
                    b.HasKey(u => u.Id); // DbUser имеет ключ Id 
                b.Property(user => user.Id).HasColumnName("id"); // Свойство Id хранится в колонке "id"
                b.Property(user => user.Login).HasColumnName("login"); // Свойство Login хранится в колонке "login"
                b.Property(user => user.UserName).HasColumnName("name"); // Свойство Name хранится в колонке "name"
                });
        } 
    }
}