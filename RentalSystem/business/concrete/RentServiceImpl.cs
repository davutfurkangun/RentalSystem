using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalSystem.business.@abstract;
using RentalSystem.context;
using RentalSystem.entity;
using RentalSystem.util;

namespace RentalSystem.business.concrete
{
    internal class RentServiceImpl : RentService
    {
        RentContext _rentContext;
        ClothesService _clothesService;
        UserService _userService;
        public RentServiceImpl(RentContext rentContext,ClothesService clothesService, UserService userService)
        {
            _rentContext = rentContext;
            _clothesService = clothesService;
            _userService = userService;
        }


        public void requestRent(long userId, long clothId, int kiralananGun)
        {
            User user = _userService.getUserById(userId);
            Clothes cloth= _clothesService.getClothesById(clothId);
            if (cloth == null)
            {
                Console.WriteLine("Kıyafet bulunamadı.");
            }
            else if (cloth.Stock <= 0)
            {
                Console.WriteLine("Stoklarımız tükenmiştir. Yeni stoklar için takip ediniz.");
            }
            else
            {
                Rent rent = new Rent();
                rent.rentByUser = user;
                rent.rentClothes = cloth;
                rent.KiralananGun = kiralananGun;
                rent.createdAt = DateTime.Now;
                rent.OnaylandiMi = false;
                rent.İadeEdildiMi = false;
                rent.Id=GenerateId.generateRentId();
                _rentContext.addRequestRent(rent);
                Console.WriteLine("Kiralama talebi oluşturuldu.Admin onayı bekleniyor.");


            }

        }
        public void confirm(long rentId,string email)
        {
            Rent rent=_rentContext.getRequestRentById(rentId);
            if (rent != null)
            {
                Clothes cloth = _clothesService.getClothesById(rent.rentClothes.Id);
                User girisYapan = _userService.getAdminByEmail(email);
                if (girisYapan != null)
                {
                    if (cloth != null && cloth.Stock > 0)
                    {
                        cloth.Stock--;
                        rent.OnaylandiMi = true;
                        update(rent);
                        _rentContext.save(rent);
                        _rentContext.remove(rent);


                    }
                    
                }
                else
                {
                    Console.WriteLine("Yetkiniz bulunmamaktadır.");
                }
            }
            else
            {
                Console.WriteLine("Kiralama bulunamadı.");
            }
        }
        public void returnRents(long rentId)
        {
            Rent rent= _rentContext.getRentById(rentId);
            if (rent != null)
            {
                Clothes cloth = _clothesService.getClothesById(rent.rentClothes.Id);
                if (rent.OnaylandiMi && !rent.İadeEdildiMi && cloth != null)
                {
                    cloth.Stock++;
                    rent.İadeEdildiMi = true;
                    update(rent);

                }
            }
            else
            {
                Console.WriteLine("Kiralama bulunamadı.");
            }
        }
        public void update(Rent rent)
        {
            Rent kiralama = _rentContext.getRentById(rent.Id);
            if (kiralama != null)
            {
                kiralama.OnaylandiMi = rent.OnaylandiMi;
                kiralama.İadeEdildiMi = rent.İadeEdildiMi;
            }
        }
        public void reddetme(long rentId, string email)
        {
            Rent rent = _rentContext.getRequestRentById(rentId);
            if (rent != null)
            {
                Clothes cloth = _clothesService.getClothesById(rent.rentClothes.Id);
                User girisYapan = _userService.getAdminByEmail(email);
                if (girisYapan != null)
                {
                    if (cloth != null && cloth.Stock > 0)
                    {
                        rent.OnaylandiMi = false;
                        update(rent);
                        _rentContext.remove(rent);
                        Console.WriteLine("Sipariş reddedilmiştir. Bekleyen isteklerden silinmiştir.");
                    }
                }
                else
                {
                    Console.WriteLine("Yetkiniz bulunmamaktadır.");
                }
            }
            else
            {
                Console.WriteLine("Kiralama bulunamadı.");
            }
        }
        public List<Rent> getListKullaniciTalepleri(long userId)
        {
            return _rentContext.getListKullaniciTalepleri(userId);
        }
        public List<Rent> getListKullaniciIadesiYapılmamıs(long userId)
        {
            return _rentContext.getListKullaniciIadesiYapılmamıs(userId);
        }
        public List<Rent> getListByUserId(long userId)
        {
            return _rentContext.getListByUserId(userId);
        }
        public List<Rent> getListUnacceptedRents()
        {
            return _rentContext.getListUnacceptedRents().Where(x => !x.OnaylandiMi).ToList();
        }

    }
}
