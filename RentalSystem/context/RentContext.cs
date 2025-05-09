using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RentalSystem.entity;

namespace RentalSystem.context
{
    internal class RentContext : List
    {
        public void save(Rent rent)
        {
            rents.Add(rent);
        }
        public List<Rent> getList()
        {
            return rents;
        }
        public List<Rent> getListUnacceptedRents()
        {
            return requestRents;
        }
        public Rent getRequestRentById(long id)
        {
            return requestRents.FirstOrDefault(x => x.Id == id);
        }
        public void addRequestRent(Rent rent)
        {
            requestRents.Add(rent);
        }
        public List<Rent> getListByUserId(long userId)
        {
            return rents.Where(x => x.rentByUser.Id == userId).ToList();
        }
        public Rent getRentById(long id)
        {
            return rents.FirstOrDefault(x => x.Id == id);
        }
        public void showRentList(List<Rent> a)
        {
            a = getList();
            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }
        }
        public void showRequestRentList(List<Rent> a)
        {
            a = getListUnacceptedRents();
            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }
        }
        public void remove(Rent rent)
        {
            requestRents.Remove(rent);
        }
       



    }
}
