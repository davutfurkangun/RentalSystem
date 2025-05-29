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
        public void delete(Clothes clothes)
        {
            cloth.Remove(clothes);
        }
        public Clothes getClothesById(long id)
        {
            return cloth.FirstOrDefault(x => x.Id == id);
        }
        public Clothes getClothesByName(string name)
        {
            return cloth.FirstOrDefault(x => x.Name.Equals(name));
        }
        public List<Clothes> getList()
        {
            return cloth;
        }
        public List<Clothes> getListByCategory(string category)  
        {
            Enum.TryParse<Category>(category, out var categoryEnum);
            return cloth.Where(x => x.Category == categoryEnum).ToList();
        }
    }
}
