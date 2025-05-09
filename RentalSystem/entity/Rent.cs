using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.entity
{
    internal class Rent : BaseLongEntity
    {
        public User rentByUser { get; set; }
        public Clothes rentClothes { get; set; }
        public DateTime? createdAt { get; set; }
        public int KiralananGun { get; set; }
        public bool OnaylandiMi {  get; set; }
        public bool İadeEdildiMi { get; set; }

        public override string ToString()
        {
            return base.ToString()+$"Kiralayan Kullanıcı: {rentByUser.Name}, " +
                   $"Kiralık Kıyafet: {rentClothes.Name}, " +
                   $"Oluşturulma Tarihi: {(createdAt.HasValue ? createdAt.Value.ToString("dd.MM.yyyy HH:mm") : "Belirtilmemiş")}, " +
                   $"Kiralanan Gün: {KiralananGun}, " +
                   $"Onay Durumu: {(OnaylandiMi ? "Onaylandı" : "Onay Bekliyor")}, " +
                   $"İade Durumu: {(İadeEdildiMi ? "İade Edildi" : "İade Edilmedi")}";
        }

    }
}
