using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Services.Users
{
    public class UserPurchaseRepository: IUserPurchaseRepository
    {
        private readonly ApplicationDbContext dbContext;

        public UserPurchaseRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

       

        public UserPurchase[] Get(int userId)
        {
            //dbContext.UserPurchases.OrderBy(purchase => purchase.UserId) Сортировка по возрастанию по UserId
            //dbContext.UserPurchases.OrderByDescending(purchase => purchase.UserId) Сортировка по убыванию
            //dbContext.UserPurchases.First(purchase => purchase.UserId == userId) Первый по userId, если нет, то ошибка
            //dbContext.UserPurchases.FirstOrDefault(purchase => purchase.UserId == userId) Первый по userId, если нет, то null
            //List<Product> a = dbContext.UserPurchases
            //    .Where(p => p.UserId == userId)
            //    .Select(p =>  p.Product)
            //    .ToList();

            return dbContext.UserPurchases
                .Where(purchase => purchase.UserId == userId)
                .ToArray();
        }


        void IUserPurchaseRepository.Create(UserPurchase userpurchase)
        {
            dbContext.UserPurchases.Add(userpurchase);
            dbContext.SaveChanges();
        }
    }
}
