using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.util
{
    internal class GenerateId
    {
        private static int userId = 0;
        private static int adminId = 0;
        private static int clothesId = 0;
        private static int rentId = 0;
        public static int generateUserId()
        {

            userId = userId + 1;
            return userId;

        }
        public static int generateAdminId()
        {

            adminId = adminId + 1;
            return adminId;

        }
        public static int generateClothesId()
        {

            clothesId = clothesId + 1;
            return clothesId;

        }
        public static int generateRentId()
        {

            rentId = rentId + 1;
            return rentId;

        }
    }
}
