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
    internal class ClothesServiceImpl : ClothesService
    {
        ClothesContext _clothesContext;
        UserService _userService;
        public ClothesServiceImpl(ClothesContext context,UserService userService)
        {
            _clothesContext = context;
            _userService = userService;
        }


        public void save(string name, string description, int stock, Category category, string KayitYapanEmail,double price)
        {
            User kayitYapan=_userService.getAdminByEmail(KayitYapanEmail);
            if (kayitYapan == null)
            {
                Console.WriteLine("Buna yetkiniz yok");
            }
            else
            {
                Clothes cloth1 = _clothesContext.getClothesByName(name);
                if (cloth1 != null)
                {
                    Console.WriteLine("Bu isimde bir kıyafet bulunmakta.");
                }
                else
                {
                    Clothes clothes = new Clothes();
                    clothes.Name = name;
                    clothes.Description = description;
                    clothes.Stock = stock;
                    clothes.Category = category;
                    clothes.KayıtYapan = kayitYapan;
                    clothes.price = price;
                    clothes.Id = GenerateId.generateClothesId();
                    _clothesContext.save(clothes);
                }
            }
        }
        public void delete(string adminMail,long clothId)
        {
            User admin=_userService.getAdminByEmail(adminMail);
            Clothes cloth1=_clothesContext.getClothesById(clothId);
            if (admin != null && cloth1 !=null)
            {
                _clothesContext.delete(cloth1);
                Console.WriteLine("Kıyafet silinmiştir.");
            }
            else
            {
                Console.WriteLine("Kıyafet bulunamamıştır.");
            }


        }
        public Clothes getClothesById(long id)
        {
            return _clothesContext.getClothesById(id);
        }
        public void showList()
        {
            List<Clothes> a = _clothesContext.getList();
            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }
        }
        public List<Clothes> getListByCategory(string category)
        {
            return _clothesContext.getListByCategory(category);
        }
        public void showListByCategory(string category)
        {
            _clothesContext.showListByCategory(category);
        }
    }
}
