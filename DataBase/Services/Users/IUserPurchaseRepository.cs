﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Services.Users
{
    public interface IUserPurchaseRepository

    {
        public UserPurchase[] Get(int userId);

        void Create(UserPurchase userpurchase);
    }
}
