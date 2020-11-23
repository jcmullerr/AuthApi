using System.Reflection.Metadata;
using System.Collections.Generic;
using AuthApi.Models;
using System.Linq;

namespace AuthApi.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username,string password)
        {
            var users = new List<User>();
            users.Add(new User {Id = 1 , Username = "robin" , Password = "123" ,Role = "employee"});
            users.Add(new User {Id = 2 , Username = "batman" , Password = "456" ,Role = "manager"});
            return users.FirstOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}