using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalSystem.entity;
using RentalSystem.entity.@enum;

namespace RentalSystem.business.@abstract
{
    internal interface UserService
    {
        public void save(string name,string surname,string username,string password,string email, Role role);
        public void saveAdmin(string adminEmail, string userEmail);
        public void removeAdmin(string superEmail, string adminEmail);
        public User userLogin(string userNameOrEmail,string password);
        public User adminLogin(string userNameOrEmail, string password);
        public User getUserByEmail(string email);
        public User getAdminByEmail(string email);
        public User getUserById(long id);
        public User superLogin(string userNameOrEmail, string password);
        public List<User> getUserList();
        public List<User> getAdminList();

    }
}
