using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Services
{
    public interface IUserDataService
    {
        //UserModel GetUserById(int id);
        // List<UserModel> SearchProducts(string SearchTerm);
        int InsertEmail(string email);

        UserModel GetUserByEmail(string email);
        string GetUserRole(string email);
        List<UserModel> GetAllUsers();
        UserModel GetUserById(int id);
        int Update(UserModel user);
        List<string> GetAllDevs();
        int UpdateRole(UserModel user);
    }
}
