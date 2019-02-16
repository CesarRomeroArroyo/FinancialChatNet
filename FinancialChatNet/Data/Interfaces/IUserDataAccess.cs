using System;
using System.Collections.Generic;
using System.Text;
using Transversal.Models;

namespace Data.Interfaces
{
    public interface IUserDataAccess
    {
        UserModel login(string user, string password);
        List<UserModel> getListUser(string userId);

        bool createUser(string email, string password);


    }
}
