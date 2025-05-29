using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalSystem.entity;
using RentalSystem.entity.@enum;

namespace RentalSystem.business.@abstract
{
    internal interface ClothesService
    {
        public void save(string name, string description, int stock, Category category,string kayitYapanEmail,double price);
        public void delete(string adminMail, long clothId);
        public Clothes getClothesById(long id);
        public List<Clothes> getListByCategory(string category);
        public List<Clothes> getList();
    }
}
