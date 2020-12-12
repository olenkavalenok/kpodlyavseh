using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KPO_Lab
{
    static class DataBase
    {

        public static string Shop_Name = "Линия";
        public static string Time = "12:00.01";
        public static int Request_Number = 00;

        public static string Addresser = "Talvitie@liniya.ru";
        public static string Message_Text = "";
        public static string Addresser_Provider = "iphonemskopt@gmail.com";
        public static string Message_Text_Provider = "";

        public static string Name_Customer = "ООО Товары Иванова";
        public static string Login_Customer = "admin";
        public static string Password_Customer = "1234";
        public static string Telephone_Customer = "8(800)200-90-02";
        public static string Email_Customer = "Talvitie@liniya.ru";
        public static string NumCard_Customer = "4573 7800 0000 0156";

        public static string Name_Provider = "ООО Быстро и круглосуточно";
        public static string Login_Provider = "ad";
        public static string Password_Provider = "12";
        public static string Telephone_Provider = "8(915)152-38-76";
        public static string Email_Provider = "iphonemskopt@gmail.com";
        public static string NumCard_Provider = "4000 1567 0000 0125";

        public static string[] Product_Name = { "Хлеб", "Гречка", "Рис", "Макароны",
                                                "Масло подсолнечное", "Колбаса докторская",
                                                "Мыло детское", "Салфетки бумажные" };
        public static int[] Product_Price = { 31, 52, 65, 54, 42, 215, 35, 25 };
        public static int[] Product_Demand  = { 432, 205, 192, 317, 123, 279, 156, 194 };
        public static int[] Product_Last_Demand = { 518, 224, 235, 302, 125, 214, 122, 228 };
        public static int[] Product_Count = { 550, 300, 250, 350, 150, 300, 200, 250 };
    }
}