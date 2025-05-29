using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalSystem.business.@abstract;
using RentalSystem.business.concrete;
using RentalSystem.context;
using RentalSystem.entity;

namespace RentalSystem.api
{
    internal class RentController
    {
        RentService _rentService;
        public RentController()
        {
            _rentService = new RentServiceImpl(new RentContext(),new ClothesServiceImpl(new ClothesContext(),new UserServiceImpl(new UserContext())),new UserServiceImpl(new UserContext()));
        }
       
        
        public void confirm(long rentId, string email)
        {
            _rentService.confirm(rentId, email);
        }
        public void returnRents(long rentId)
        {
            _rentService.returnRents(rentId);
        }
        public void reddetme(long rentId, string email)
        {
            _rentService.reddetme(rentId, email);
        }
        public void requestRent(long userId, long clothId, int kiralananGun)
        {
            _rentService.requestRent(userId, clothId, kiralananGun);
        }
        public List<Rent> getListByUserId(long userId)
        {
            return _rentService.getListByUserId(userId);
        }
        public List<Rent> getListUnacceptedRents()
        {
            return _rentService.getListUnacceptedRents();
        }
        public List<Rent> getListKullaniciTalepleri(long userId)
        {
            return _rentService.getListKullaniciTalepleri(userId);
        }
        public List<Rent> getListKullaniciIadesiYapılmamıs(long userId)
        {
            return _rentService.getListKullaniciIadesiYapılmamıs(userId);
        }

    }
}
