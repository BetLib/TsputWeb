using Microsoft.EntityFrameworkCore;

namespace DataBase.Services.Users
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
            return dbContext.Users.Where(u => !u.Isdeleted).ToArray(); // Получение всех пользователей из БД
        }

        public DbUser? Get(int id) {
            return dbContext.Users.Where(u => !u.Isdeleted).FirstOrDefault(u => u.Id == id);
        }

        DbUser? IUserRepository.Create(DbUser user)
        {
            try
            {
                dbContext.Users.Add(user);//Добавленеи пользователя в ДБ
                dbContext.SaveChanges();// Сохранение изменений
                return user;
            }
            catch (DbUpdateException ex)
            {
                return null;
            }
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
            dbUser.Isdeleted=true; 
            // Сохранение изменений
            dbContext.SaveChanges();
        }
    }
}
