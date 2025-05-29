using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalSystem.entity;

namespace RentalSystem.business.@abstract
{
    internal interface RentService
    {
        public void confirm(long rentId, string email);
        public void returnRents(long rentId);
        public void reddetme(long rentId, string email);
        public void requestRent(long userId, long clothId, int kiralananGun);
        public List<Rent> getListByUserId(long userId);
        public List<Rent> getListUnacceptedRents();
        public List<Rent> getListKullaniciTalepleri(long userId);
        public List<Rent> getListKullaniciIadesiYapılmamıs(long userId);
    }
}
