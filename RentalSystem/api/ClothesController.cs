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
    internal class ClothesController
    {
        ClothesService _clothesService;
        public ClothesController()
        {
            _clothesService = new ClothesServiceImpl(new ClothesContext(),new UserServiceImpl(new UserContext()));
        }


        public void save(string name, string description, int stock, Category category,string kayitYapanEmail,double price)
        {
            _clothesService.save(name, description, stock, category, kayitYapanEmail,price);
        }
        public void delete(string adminMail, long clothId)
        {
            _clothesService.delete(adminMail, clothId);
        }
        public Clothes getClothesById(long id)
        {
            return _clothesService.getClothesById(id);
        }
        public List<Clothes> getListByCategory(string category)
        {
            return _clothesService.getListByCategory(category);
        }
        public List<Clothes> getList()
        {
            return _clothesService.getList();
        }
    }
}
