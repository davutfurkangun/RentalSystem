using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalSystem.entity;
using RentalSystem.entity.@enum;

namespace RentalSystem.context
{
    internal class UserContext : List
    {
        public void save (User user)
        {
            if (user.Role == Role.ADMIN || user.Role==Role.SUPER)
            {
                admins.Add (user);
            }
            if (user.Role == Role.USER)
            {
                users.Add(user);
            }
        }
        public void remove(User user)
        {
            if (user.Role == Role.ADMIN)
            {
                admins.Remove(user);
            }
            if (user.Role == Role.USER)
            {
                users.Remove(user);
            }
        }
        public User getUserByEmail(string email)
        {
            return users.FirstOrDefault(x => x.Email.Equals(email));
        }
        public User getSuperByEmail(string email)
        {
            return admins.FirstOrDefault(x => x.Email.Equals(email) && x.Role==Role.SUPER);
        }
        public User getAdminByEmail(string email)
        {
            return admins.FirstOrDefault(x => x.Email.Equals(email));
        }
        public User getAdminByUsername(string username)
        {
            return admins.FirstOrDefault(x => x.Email.Equals(username));
        }
        public User getUserByUsername(string username)
        {
            return admins.FirstOrDefault(x => x.Email.Equals(username));
        }
        public User getAdminByUsernameOrEmail(string input)
        {
            return admins.FirstOrDefault(x => x.Username.Equals(input) || x.Email.Equals(input));
        }
        public User getUserByUsernameOrEmail(string input)
        {
            return users.FirstOrDefault(x => x.Username.Equals(input) || x.Email.Equals(input));
        }
        public User getSuperByUsernameOrEmail(string input)
        {
            return admins.FirstOrDefault(x => (x.Username.Equals(input) || x.Email.Equals(input))&& x.Role==Role.SUPER);
        }
        public User getUserById(long id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }
        public List<User> getUserList()
        {
            return users;
        }
        public List<User> getAdminList()
        {
            return admins;
        }

    }
}
