using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalSystem.entity.@enum;

namespace RentalSystem.entity
{
    internal class Clothes : BaseLongEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public Category Category { get; set; }
        public User KayıtYapan {  get; set; }
        public double price { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Ürün Adı: {Name}, Açıklama: {Description}, Stok: {Stock}, Kategori: {Category}" +
                   
                   
                   $" Fiyat: {price:C2}";
        }
    }
}
