using System.Linq;
using System.Runtime.Intrinsics.X86;
using RentalSystem.api;
using RentalSystem.entity;
using RentalSystem.entity.@enum;

namespace RentalSystem
{
    internal class Program
    {

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
            UserController userController = new UserController();
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
                UserController userController = new UserController();
                User user1 = userController.userLogin(input, password);
                if (user1 != null)
                {
                    KullaniciMenu(user1.Id);
                    return;
                }
                else
                {
                    Console.WriteLine("Giriş başarısız. Tekrar deneyiniz.");

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
                        ClothesController clothesController = new ClothesController();
                        clothesController.showList();
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
                                    ClothesController clothesController1 = new ClothesController();
                                    clothesController1.showListByCategory("Elbise"); break;
                                case "2":
                                    ClothesController _clothesController = new ClothesController();
                                    _clothesController.showListByCategory("TakımElbise"); break;
                                case "3":
                                    ClothesController __clothesController = new ClothesController();
                                    __clothesController.showListByCategory("Ceket"); break;
                                case "4":
                                    ClothesController ___clothesController = new ClothesController();
                                    ___clothesController.showListByCategory("Gömlek"); break;
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
                        ClothesController clothesController1 = new ClothesController();
                        clothesController1.showList();
                       
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
                        
                        RentController rentController = new RentController();
                        rentController.requestRent(id, clothId, kiralamaGun);
                        break;
                    case "2":
                        RentController _rentController = new RentController();
                        _rentController.showRequestRentList();
                        break;
                    case "3":
                        RentController rentController1 = new RentController();
                        rentController1.showListByUserId(id);
                        break;
                    case "4":
                        RentController rentController2 = new RentController();
                        rentController2.showListByUserId(id);
                        
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
                        rentController2.returnRents(returnId);
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
                UserController userController = new UserController();
                User admin1 = userController.adminLogin(input, password);
                if (admin1 != null)
                {
                    AdminMenu(admin1.Email);
                    return;
                }
                else
                {
                    Console.WriteLine("Giriş başarısız. Tekrar deneyiniz.");

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
                        ClothesController controller = new ClothesController();
                        controller.save(name, description, stock, kategoriEnum, email, price);
                        break;
                    case "2":
                        ClothesController clothesController = new ClothesController();
                        clothesController.showList();
                       
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
                        RentController rent = new RentController();
                        rent.showRequestRentList();
                        break;
                    case "2":
                        RentController rentController = new RentController();
                        rentController.showRequestRentList();
                        
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
                        RentController rentController1 = new RentController();
                        rentController1.showRequestRentList();
                        
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
                        rentController1.reddetme(redRentId, email);
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
                UserController userController = new UserController();
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
                        UserController userController = new UserController();
                        userController.showUserList();
                        Console.WriteLine("Admin yapmak istediğiniz kullanıcının mailini giriniz.");
                        string userEmail = Console.ReadLine();
                        userController.saveAdmin(email, userEmail);
                        break;
                    case "2":
                        UserController userController1 = new UserController();
                        userController1.showAdminList();
                        Console.WriteLine("Adminliğini almak istediğiniz adminin mailini giriniz.");
                        string adminEmail = Console.ReadLine();
                        userController1.removeAdmin(email, adminEmail);
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
            ClothesController clothesController=new ClothesController();
            clothesController.save("asd", "asdqweasd", 2, Category.Gömlek, "admin", 213.4);
            clothesController.save("Keten", "asdqweasd", 6, Category.Gömlek, "admin", 213.4);

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
    }

}
