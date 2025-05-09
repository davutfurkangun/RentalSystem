using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalSystem.entity.@enum;

namespace RentalSystem.entity
{
    internal class User : BaseLongEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }

        public override string ToString()
        {
            return base.ToString()+$"Name: {Name}, Surname: {Surname}, Username: {Username}, Email: {Email}, Role: {Role}";
        }

    }
}
