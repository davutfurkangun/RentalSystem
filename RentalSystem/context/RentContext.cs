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
        public void remove(Rent rent)
        {
            requestRents.Remove(rent);
        }
        public void addRequestRent(Rent rent)
        {
            requestRents.Add(rent);
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
        public Rent getRequestRentById(long id)
        {
            return requestRents.FirstOrDefault(x => x.Id == id);
        }
        public Rent getRentById(long id)
        {
            return rents.FirstOrDefault(x => x.Id == id);
        }
        public List<Rent> getList()
        {
            return rents;
        }
        public List<Rent> getListUnacceptedRents()
        {
            return requestRents;
        }
        public List<Rent> getListByUserId(long userId)
        {
            return rents.Where(x => x.rentByUser.Id == userId).ToList();
        }
        public List<Rent> getListKullaniciTalepleri(long userId)
        {
            return requestRents.Where(x => x.rentByUser.Id == userId && x.OnaylandiMi == false).ToList();
        }
        public List<Rent> getListKullaniciIadesiYapılmamıs(long userId)
        {
            return rents.Where(x => x.rentByUser.Id == userId && x.İadeEdildiMi == false).ToList();
        }
      
        



    }
}
