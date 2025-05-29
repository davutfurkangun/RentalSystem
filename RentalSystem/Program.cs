using System.Linq;
using System.Runtime.Intrinsics.X86;
using RentalSystem.api;
using RentalSystem.context;
using RentalSystem.entity;
using RentalSystem.entity.@enum;

namespace RentalSystem
{
    internal class Program
    {  
        static ClothesController clothesController = new ClothesController();
        static UserController userController = new UserController();
        static RentController rentController = new RentController();
        static void Main(string[] args)
        {
            
            
            superEkle();
            adminekle();
            kıyafetekle();
            kullanıcıekle();

            Console.Clear();
            while (true)
            {
                Console.WriteLine("1) Kayıt Ol\n2) Kullanıcı Girişi\n3) Admin Girişi\n4) SuperAdmin Girişi\n5) Çıkış");
                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        KayitOl();
                        break;
                    case "2":
                        KullaniciGirisi();
                        break;
                    case "3":
                        AdminGirisi();
                        break;
                    case "4":
                        SuperGirisi();
                        break;
                    case "5":
                        Console.WriteLine("Çıkış yapıldı.");
                        return;
                    default:
                        Console.WriteLine("Hatalı giriş!!");
                        break;


                }
            }
        }



        static void KayitOl()
        {
            Console.WriteLine("Kayıt olmak için bekleyiniz...");
            Console.WriteLine("-----------------");
            Console.WriteLine("Adınızı giriniz.");
            string name=Console.ReadLine();
            Console.WriteLine("Soyadınızı giriniz.");
            string surname=Console.ReadLine();
            Console.WriteLine("Username giriniz.");
            string username=Console.ReadLine();
            Console.WriteLine("Email adresinizi giriniz.");
            string email = Console.ReadLine().ToLower();
            Console.WriteLine("Şifre giriniz.");
            string password=Console.ReadLine();
            userController.save(name, surname, username, password, email, Role.USER);

        }
        static void KullaniciGirisi()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Kullanıcı adı veya E-mail:");
                string input = Console.ReadLine();
                Console.WriteLine("Şifre: ");
                string password = Console.ReadLine();
                User user1 = userController.userLogin(input, password);
                if (user1 != null)
                {
                    KullaniciMenu(user1.Id);
                    return;
                }
                else
                {
                    Console.WriteLine("Giriş başarısız. Tekrar deneyiniz.");
                    return;
                }
            }
        }
        static void KullaniciMenu(long id)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("1)Kıyafet Menüsü");
                Console.WriteLine("2)Kiralama Menüsü");
                Console.WriteLine("3) Ana Menü");
                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        KıyafetMenusu(id);
                        break;
                    case "2":
                        KiralamaMenusu(id);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim yaptınız. Lütfen 1, 2 ya da 3'ü tuşlayınız.");
                        break;
                }

            }

        }
        static void KıyafetMenusu(long id)
        {
            while (true)
            {
                Console.WriteLine("1)Tüm kıyafetler");
                Console.WriteLine("2)Kategoriye göre kıyafetler");
                Console.WriteLine("3)Üst Menü");
                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        showList(clothesController.getList());
                        break;
                    case "2":
                        while (true)
                        {
                            Console.WriteLine("1) Elbise");
                            Console.WriteLine("2) TakımElbise");
                            Console.WriteLine("3) Ceket");
                            Console.WriteLine("4) Gömlek");
                            Console.WriteLine("5) Üst Menü");
                            Console.WriteLine("Bir kategori seçiniz.");
                            string secim2 = Console.ReadLine();
                            switch (secim2)
                            {
                                case "1":
                                    showList(clothesController.getListByCategory("Elbise"));
                                    break;
                                case "2":
                                    showList(clothesController.getListByCategory("TakımElbise"));
                                    break;
                                case "3":
                                    showList(clothesController.getListByCategory("Ceket"));
                                    break;
                                case "4":
                                    showList(clothesController.getListByCategory("Gömlek"));
                                    break;
                                case "5":
                                    return;
                                default:
                                    Console.WriteLine("Geçersiz seçim yaptınız. Lütfen 1, 2, 3, 4 ya da 5'i tuşlayınız.");
                                    break;

                            }
                        }

                    case "3":
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim yaptınız. Lütfen 1, 2 ya da 3'ü tuşlayınız.");
                        break;

                }
            }
        }
        static void KiralamaMenusu(long id)
        {
            while (true)
            {
                Console.WriteLine("1) Kıyafet Kirala");
                Console.WriteLine("2) Kiralama Taleplerim");
                Console.WriteLine("3) Yapılan Kiralamalar");
                Console.WriteLine("4) Kiralama iadesi");
                Console.WriteLine("5) Üst Menü");
                string secim = Console.ReadLine();
                switch (secim) 
                {
                    case "1":

                        showList(clothesController.getList());
                        long clothId;
                        while (true)
                        {
                            Console.WriteLine("Kiralamak istediğiniz kıyafetin ID'si: ");
                            string input = Console.ReadLine();
                            try
                            {
                                clothId = Convert.ToInt64(input);
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Geçersiz ID girdiniz. Lütfen sadece rakam kullanınız.");
                            }
                        }
                        int kiralamaGun;
                        while (true)
                        {
                            Console.WriteLine("Kaç gün kiralamak istersiniz? ");
                            string input = Console.ReadLine();
                            try
                            {
                                kiralamaGun = Convert.ToInt32(input);
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Geçersiz gün sayısı girdiniz. Lütfen sadece rakam kullanınız.");
                            }
                        }
                        rentController.requestRent(id, clothId, kiralamaGun);
                        break;
                    case "2":
                        showList(rentController.getListKullaniciTalepleri(id));
                        break;
                    case "3":
                        showList(rentController.getListByUserId(id));
                        break;
                    case "4":
                        showList(rentController.getListKullaniciIadesiYapılmamıs(id));
                      
                        long returnId;
                        while (true)
                        {
                            Console.WriteLine("İade etmek istediğiniz kiralamanın ID'sini giriniz. ");
                            string input = Console.ReadLine();
                            try
                            {
                                returnId = Convert.ToInt64(input);
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Geçersiz ID girdiniz. Lütfen sadece rakam kullanınız.");
                            }
                        }
                        rentController.returnRents(returnId);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim yaptınız. Lütfen 1, 2, 3, 4 ya da 5'i tuşlayınız.");
                        break;
                }
            }
        }
        static void AdminGirisi()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Kullanıcı adı veya E-mail:");
                string input = Console.ReadLine();
                Console.WriteLine("Şifre: ");
                string password = Console.ReadLine();
                User admin1 = userController.adminLogin(input, password);
                if (admin1 != null)
                {
                    AdminMenu(admin1.Email);
                    return;
                }
                else
                {
                    Console.WriteLine("Giriş başarısız. Tekrar deneyiniz.");
                    return;
                }

            }

        }
        static void AdminMenu(string email)
        {
            Console.Clear();
            while (true)
            {

                Console.WriteLine("1) Kıyafet Menüsü");
                Console.WriteLine("2) Kiralama Menüsü");
                Console.WriteLine("3) Ana Menü");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        AdminKiyafetMenusu(email);
                        break;
                        
                    case "2":
                        AdminKiralamaMenusu(email);
                        break;
                        
                    case "3": 
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim yaptınız. Lütfen 1, 2 ya da 3'ü tuşlayınız.");
                        break;
                }
            }
        }
        static void AdminKiyafetMenusu(string email)
        {
            while (true)
            {
                Console.WriteLine("1) Kıyafet Ekle");
                Console.WriteLine("2) Kıyafet Sil");
                Console.WriteLine("3) Üst Menü");
                string secim = Console.ReadLine();
                switch (secim) 
                {
                    case "1":
                        Console.WriteLine("Kıyafetin adını giriniz: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Kıyafetin açıklamasını giriniz: ");
                        string description = Console.ReadLine();
                        int stock;
                        while (true)
                        {
                            Console.WriteLine("Kıyafetten kaç adet stoğa girmek isterseniz? ");
                            try
                            {
                                stock = Convert.ToInt32(Console.ReadLine());
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                            }
                        }
                        
                        Category kategoriEnum;
                        while (true)
                        {
                            Console.WriteLine("Bir kategori seçiniz (Elbise,TakımElbise,Ceket,Gömlek): ");
                            string giris = Console.ReadLine();

                            if (Enum.TryParse<Category>(giris, out kategoriEnum))
                            {
                                break;
                            }

                            Console.WriteLine("Geçersiz kategori girdiniz. Lütfen belirtilen kategorilerden birini yazınız.");
                        }
                        
                        double price;
                        while (true)
                        {
                            Console.WriteLine("Kıyafetin fiyatını giriniz: ");
                            try
                            {
                                price = Convert.ToDouble(Console.ReadLine());
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Geçersiz fiyat girdiniz. Lütfen sadece sayı kullanınız (örn: 199.99).");
                            }
                        }
                        
                        clothesController.save(name, description, stock, kategoriEnum, email, price);
                        break;
                    case "2":
                        showList(clothesController.getList());
                       
                        long clothId;
                        while (true)
                        {
                            Console.WriteLine("Silmek istediğiniz Kıyafet ID'sini giriniz: ");
                            string input = Console.ReadLine();
                            try
                            {
                                clothId = Convert.ToInt64(input);
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Geçersiz ID girdiniz. Lütfen sadece rakam kullanınız.");
                            }
                        }

                        clothesController.delete(email, clothId);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim yaptınız. Lütfen 1, 2 ya da 3'ü tuşlayınız.");
                        break;
                }
            }
        }
        static void AdminKiralamaMenusu(string email)
        {
            while (true)
            {
                Console.WriteLine("1) Bekleyen Talepler");
                Console.WriteLine("2) Talep Onaylama");
                Console.WriteLine("3) Talep Reddetme");
                Console.WriteLine("4) Üst Menü");
                string secim = Console.ReadLine();
                switch (secim) 
                {
                    case "1":
                        showList(rentController.getListUnacceptedRents());
                        break;
                    case "2":
                        showList(rentController.getListUnacceptedRents());

                        long rentId;
                        while (true)
                        {
                            Console.WriteLine("Onaylamak istediğiniz kiralamanın id'sini giriniz. ");
                            string input = Console.ReadLine();
                            try
                            {
                                rentId = Convert.ToInt64(input);
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Geçersiz ID girdiniz. Lütfen sadece rakam kullanınız.");
                            }
                        }
                        rentController.confirm(rentId, email);
                        break;
                    case "3":
                        showList(rentController.getListUnacceptedRents());

                        long redRentId;
                        while (true)
                        {
                            Console.WriteLine("Reddetmek istediğiniz kiralamanın id'sini giriniz. ");
                            string input = Console.ReadLine();
                            try
                            {
                                redRentId = Convert.ToInt64(input);
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Geçersiz ID girdiniz. Lütfen sadece rakam kullanınız.");
                            }
                        }
                        rentController.reddetme(redRentId, email);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim yaptınız. Lütfen 1, 2, 3 ya da 4'ü tuşlayınız.");
                        break;

                }
            }
        }
        static void SuperGirisi()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Kullanıcı adı veya E-mail:");
                string input = Console.ReadLine();
                Console.WriteLine("Şifre: ");
                string password = Console.ReadLine();
                User super = userController.superLogin(input, password);
                if (super != null)
                {
                    SuperMenu(super.Email);
                    return;
                }
                else
                {
                    Console.WriteLine("Giriş başarısız. Tekrar deneyiniz.");

                }

            }

        }
        static void SuperMenu(string email)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("1)Admin ekleme");
                Console.WriteLine("2)Admin silme");
                Console.WriteLine("3)Ana Menü");
                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        showList(userController.getUserList());
                        Console.WriteLine("Admin yapmak istediğiniz kullanıcının mailini giriniz.");
                        string userEmail = Console.ReadLine();
                        userController.saveAdmin(email, userEmail);
                        break;
                    case "2":
                        showList(userController.getAdminList());
                        Console.WriteLine("Adminliğini almak istediğiniz adminin mailini giriniz.");
                        string adminEmail = Console.ReadLine();
                        userController.removeAdmin(email, adminEmail);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim yaptınız. Lütfen 1, 2 ya da 3'ü tuşlayınız.");
                        break;
                }
            }
        }


        static void kıyafetekle()
        {
            clothesController.save("Keten Gömlek", "Yazlık, nefes alan kumaş", 10, Category.Gömlek, "admin", 199.99);
            clothesController.save("Şifon Elbise", "Hafif yapılı, yazlık elbise", 5, Category.Elbise, "admin", 349.50);
            clothesController.save("Deri Ceket", "Hakiki deri, siyah ceket", 3, Category.Ceket, "admin", 899.00);
            clothesController.save("Smokin Takım", "Özel günler için takım elbise", 2, Category.TakımElbise, "admin", 1299.99);
            clothesController.save("Kareli Gömlek", "Pamuklu, günlük kullanım için uygun", 8, Category.Gömlek, "admin", 159.75);
            clothesController.save("Kanvas Ceket", "Su geçirmez, açık hava etkinlikleri için", 4, Category.Ceket, "admin", 679.20);
            clothesController.save("Saten Elbise", "Gece davetleri için şık elbise", 6, Category.Elbise, "admin", 749.99);
            clothesController.save("Lacivert Takım", "İş ortamı için klasik takım elbise", 5, Category.TakımElbise, "admin", 1149.00);
            clothesController.save("Oduncu Gömlek", "Kışlık, kalın kumaşlı gömlek", 7, Category.Gömlek, "admin", 189.00);
            clothesController.save("Kadife Elbise", "Kış ayları için sıcak tutan elbise", 3, Category.Elbise, "admin", 399.90);
        }
        static void superEkle()
        {
            UserController userController=new UserController();
            userController.save("Davut", "Gün", "dfurkang", "1234", "dfg@gmail.com", Role.SUPER);
        }
        static void adminekle()
        {
            UserController userController=new UserController();
            userController.save("asdqwe","sadqesd","asdqweasd","12345", "admin",Role.ADMIN);
        }
        static void kullanıcıekle()
        {
            UserController userController = new UserController();
            userController.save("asdqwe", "sadqesd", "asdqweasd", "12345", "user", Role.USER);
        }
        static void showList(List<Clothes> clothes)
        {
            for (int i = 0; i < clothes.Count; i++)
            {
                Console.WriteLine(clothes[i]);
            }
        }
        static void showList(List<Rent> rents)
        {
            for (int i = 0; i < rents.Count; i++)
            {
                Console.WriteLine(rents[i]);
            }
        }
        static void showList(List<User> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine(users[i]);
            }
        }
    }

}
