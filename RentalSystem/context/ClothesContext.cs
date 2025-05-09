using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalSystem.entity;
using RentalSystem.entity.@enum;

namespace RentalSystem.context
{
    internal class ClothesContext : List
    {
        public void save(Clothes clothes)
        {
            cloth.Add(clothes);
        }
        public Clothes getClothesById(long id)
        {
            return cloth.FirstOrDefault(x => x.Id == id);
        }
        public Clothes getClothesByName(string name)
        {
            return cloth.FirstOrDefault(x => x.Name.Equals(name));
        }
        public void delete(Clothes clothes)
        {
            cloth.Remove(clothes);
        }
        public List<Clothes> getList()
        {
            return cloth;
        }
        public void showList()
        {
            for (int i = 0; i < getList().Count; i++)
            {
                Console.WriteLine(getList()[i]);
            }
        }
        public List<Clothes> getListByCategory(string category)  
        {
            Enum.TryParse<Category>(category, out var categoryEnum);
            return cloth.Where(x => x.Category == categoryEnum).ToList();
        }
        public void showListByCategory(string category)
        {
            List<Clothes> a = getListByCategory(category);
            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }
        }
    }
}
