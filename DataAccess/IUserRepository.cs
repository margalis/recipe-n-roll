using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IUserRepository
    {

        public  User_Account GetUserInfo(int ID);
        public  object LoginInformation(string mail, string password);
        //hly vor not ok
        public int RegisteringProccessA(User_Account ua);
    }
}
