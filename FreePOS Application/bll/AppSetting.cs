using BusinessBook.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBook.bll
{
    public class AppSetting
    {
        public static int PrinterPageWidth = Settings.Default.PrinterPageWidth;
        public static int PrinterMarginLeft = Settings.Default.PrinterMarginLeft;
        public static String Title = Settings.Default.Title;
        public static String SubTitle = Settings.Default.SubTitle;
        public static String Footer = Settings.Default.Footer;
        public static int ReciptlineHeight = Settings.Default.ReciptlineHeight;
        public static bool BarcodeMode = Settings.Default.BarcodeMode;
        //database setting
        public static string DatabaseServer = Settings.Default.DatabaseServer;
        public static string DatabaseName = Settings.Default.DatabaseName;
        public static string DatabaseUsername = Settings.Default.DatabaseUsername;
        public static string DatabasePassword = Settings.Default.DatabasePassword;

        public static void saveSettings(
            int pageWidth, 
            int magrinLeft, 
            String title, 
            String subTitle, 
            String footer, 
            int reciptlineheight,
            bool barcodeMode
            )
        {
            Settings.Default.PrinterPageWidth = pageWidth;
            PrinterPageWidth = pageWidth;
            Settings.Default.PrinterMarginLeft = magrinLeft;
            PrinterMarginLeft = magrinLeft;
            Settings.Default.Title = title;
            Title = title;
            Settings.Default.SubTitle = subTitle;
            SubTitle = subTitle;
            Settings.Default.Footer = footer;
            Footer = footer;
            Settings.Default.ReciptlineHeight = reciptlineheight;
            ReciptlineHeight = reciptlineheight;
            Settings.Default.BarcodeMode = barcodeMode;
            BarcodeMode = barcodeMode;
            Settings.Default.Save();
        }

        public static void saveDatabaseSettings(
            string server,
            string database,
            string user,
            string password
            )
        {
            Settings.Default.DatabaseServer = server;
            DatabaseServer = server;

            Settings.Default.DatabaseName = database;
            DatabaseName = database;

            Settings.Default.DatabaseUsername = user;
            DatabaseUsername = user;

            Settings.Default.DatabasePassword = password;
            DatabasePassword = password;

            Settings.Default.Save();

        }
    }
}
