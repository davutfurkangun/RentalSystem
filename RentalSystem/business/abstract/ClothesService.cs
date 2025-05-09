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
        public Clothes getClothesById(long id);
        public void delete(string adminMail, long clothId);
        public void showList();
        public List<Clothes> getListByCategory(string category);
        public void showListByCategory(string category);
    }
}
