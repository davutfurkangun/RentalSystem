using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalSystem.business.@abstract;
using RentalSystem.context;
using RentalSystem.entity;
using RentalSystem.entity.@enum;
using RentalSystem.util;

namespace RentalSystem.business.concrete
{
    internal class UserServiceImpl : UserService
    {
        UserContext _userContext;
        public UserServiceImpl(UserContext userContext)
        {
            _userContext = userContext;
        }


        public void save(string name, string surname, string username, string password, string email, Role role)
        {
            User user1 = _userContext.getUserByEmail(email);
            User user2 = _userContext.getAdminByEmail(email);
            User user3= _userContext.getAdminByUsername(username);
            User user4= _userContext.getUserByUsername(username);
            if (user1 != null || user2 != null || user3 != null || user4 != null)
            {
                Console.WriteLine("Bu e-mail veya kullanıcı adına kayıtlı kullanıcı zaten var.");
            }
            else
            {
                User user = new User();
                user.Name = name;
                user.Surname = surname;
                user.Username = username;
                user.Password = password;
                user.Email = email;
                user.Role = role;
                if (role == Role.ADMIN)
                {
                    user.Id = GenerateId.generateAdminId();
                }
                else
                {
                    user.Id = GenerateId.generateUserId();
                }
                _userContext.save(user);
                Console.WriteLine("Başarılı bir şekilde kayıt oldunuz.");

            }
        }
        public void saveAdmin(string adminEmail,string userEmail)
        {
            User super= _userContext.getSuperByEmail(adminEmail);
            User user = _userContext.getUserByEmail(userEmail);
            if (super != null && user != null)
            {
                _userContext.remove(user);
                user.Role= Role.ADMIN;
                _userContext.save(user);

            }
            else if(user == null)
            {
                Console.WriteLine("Bu maile kayıtlı kullanıcı bulunamadı.");
            }
            else
            {
                Console.WriteLine("Buna yetkiniz yoktur.");
            }

        }
        public void removeAdmin(string superEmail, string adminEmail)
        {
            User super = _userContext.getSuperByEmail(superEmail);
            User admin = _userContext.getAdminByEmail(adminEmail);
            if (super != null && admin !=null)
            {
                _userContext.remove(admin);
                admin.Role = Role.USER;
                _userContext.save(admin);

            }
            else if (admin == null)
            {
                Console.WriteLine("Bu maile kayıtlı admin bulunamadı.");
            }
            else
            {
                Console.WriteLine("Buna yetkiniz yoktur.");
            }

        }
        public User adminLogin(string userNameOrEmail, string password)
        {
            User adminlogin = _userContext.getAdminByUsernameOrEmail(userNameOrEmail);
            if (adminlogin != null && adminlogin.Password.Equals(password))
            {
                Console.WriteLine("Giriş Başarılı");
                return adminlogin;
            }
            else
            {
                return null;
            }
        }
        public User userLogin(string userNameOrEmail, string password)
        {
            User userlogin = _userContext.getUserByUsernameOrEmail(userNameOrEmail);
            if (userlogin != null && userlogin.Password.Equals(password))
            {
                Console.WriteLine("Giriş Başarılı");
                return userlogin;
            }
            else
            {
                return null;
                    //Console.WriteLine("Kullanıcı adı ya da şifre yanlış.");
            }
        }
        public User superLogin(string userNameOrEmail, string password)
        {
            User superlogin = _userContext.getSuperByUsernameOrEmail(userNameOrEmail);
            if (superlogin != null && superlogin.Password.Equals(password))
            {
                Console.WriteLine("Giriş Başarılı");
                return superlogin;
            }
            else
            {
                return null;
                //Console.WriteLine("Kullanıcı adı ya da şifre yanlış.");
            }
        }
        public User getUserByEmail(string email)
        {
            return _userContext.getUserByEmail(email);
        }
        public User getAdminByEmail(string email)
        {
            return _userContext.getAdminByEmail(email);


        }
        public User getUserById(long id)
        {
            return _userContext.getUserById(id);
        }
        public List<User> getUserList()
        {
            return _userContext.getUserList();
        }
        public List<User> getAdminList()
        {
            return _userContext.getAdminList();
        }
    }
}
