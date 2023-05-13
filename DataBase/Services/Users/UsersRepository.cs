﻿namespace DataBase.Services.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;//Конфигурация БД, созданная ранее подключается через конструктор сервиса

        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        DbUser[] IUserRepository.Get()
        {
            return dbContext.Users.ToArray(); // Получение всех пользователей из БД
        }

        public DbUser? Get(int id) {
            return dbContext.Users.Find(id);
        }

        void IUserRepository.Create(DbUser user)
        {
            dbContext.Users.Add(user);//Добавленеи пользователя в ДБ
            dbContext.SaveChanges();// Сохранение изменений
        }


        public void Update(DbUser user)
        {
            //Получение текущего значения для пользователя по id
            DbUser? dbUser = Get(user.Id);
            //Если пользователь не найден, выход из функции
            if (dbUser == null)
            {
                return;
            }
            //Обновление данных пользователя
            dbUser.Login = user.Login;
           
            dbUser.UserName = user.UserName;

            dbContext.SaveChanges();// Сохранение изменений
        }

        public void Delete(int id) 
        {
            //Получение текущего значения для пользователя по id
            DbUser? dbUser = Get(id); 
            //Если пользователь не найден, выход из функции
            if (dbUser == null) 
            { 
                return;
            } 


            // Удаление пользователя из БД
            dbContext.Remove(dbUser); 
            // Сохранение изменений
            dbContext.SaveChanges();
        }

    }
}
