using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalSystem.business.@abstract;
using RentalSystem.business.concrete;
using RentalSystem.context;
using RentalSystem.entity;
using RentalSystem.entity.@enum;

namespace RentalSystem.api
{
    internal class UserController
    {
        UserService _userService;
        public UserController()
        {
            _userService = new UserServiceImpl(new UserContext());
        }
        public void save(string name, string surname, string username, string password, string email, Role role)
        {
            _userService.save(name,surname, username, password, email, role);
        }
        public User adminLogin(string userNameOrEmail, string password)
        {
           return _userService.adminLogin(userNameOrEmail, password);
        }
        public User userLogin(string userNameOrEmail, string password)
        {
            return _userService.userLogin(userNameOrEmail, password);
        }
        public User getUserByEmail(string email)
        {
            return _userService.getUserByEmail(email);
        }
        public User getAdminByEmail(string email)
        {
            return _userService.getAdminByEmail(email);
        }
        public User getUserById(long id)
        {
            return _userService.getUserById(id);
        }
        public void saveAdmin(string adminEmail, string userEmail)
        {
            _userService.saveAdmin(adminEmail, userEmail);
        }
        public void removeAdmin(string superEmail, string adminEmail)
        {
            _userService.removeAdmin(superEmail, adminEmail);
        }
        public User superLogin(string userNameOrEmail, string password)
        {
           return _userService.superLogin(userNameOrEmail, password);
        }
        public void showUserList()
        {
            _userService.showUserList();
        }
        public void showAdminList()
        {
            _userService.showAdminList();
        }
    }
}
