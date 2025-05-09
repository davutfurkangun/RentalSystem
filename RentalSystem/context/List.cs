using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalSystem.entity;

namespace RentalSystem.context
{
    internal class List
    {
        protected static List<User> users = new List<User>();
        protected static List<User> admins = new List<User>();
        protected static List<Clothes> cloth = new List<Clothes>();
        protected static List<Rent> rents = new List<Rent>();
        protected static List<Rent> requestRents = new List<Rent>();
    }
}
