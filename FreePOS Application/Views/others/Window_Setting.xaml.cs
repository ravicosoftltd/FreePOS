using BusinessBook.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessBook.bll;

namespace BusinessBook.Views.others
{
    /// <summary>
    /// Interaction logic for Window_Setting.xaml
    /// </summary>
    public partial class Window_Setting : Window
    {
        public Window_Setting()
        {
            InitializeComponent();
            tb_PageWidth.Text = Convert.ToString(AppSetting.PrinterPageWidth) ;
            tb_MarginLeft.Text = Convert.ToString(AppSetting.PrinterMarginLeft);
            tb_Title.Text = AppSetting.Title;
            tb_SubTitle.Text = AppSetting.SubTitle;
            tb_Footer.Text = AppSetting.Footer;
            tb_Reciptlineheight.Text = Convert.ToString(AppSetting.ReciptlineHeight);
            BarcodeMode_cb.IsChecked = AppSetting.BarcodeMode;
        }

        private void btn_Save(object sender, RoutedEventArgs e)
        {
            try
            {
                int pageWidth = Convert.ToInt32(tb_PageWidth.Text);
                int marginLeft = Convert.ToInt32(tb_MarginLeft.Text);
                string title = tb_Title.Text;
                string subTitle = tb_SubTitle.Text;
                string footer = tb_Footer.Text;
                int Reciptlineheight = Convert.ToInt32(tb_Reciptlineheight.Text);
                bool barcodeModel = (bool)BarcodeMode_cb.IsChecked;
                AppSetting.saveSettings(pageWidth, marginLeft, title, subTitle, footer, Reciptlineheight, barcodeModel);
                MessageBox.Show("Saved, Restart application to apply setting","Success");
                
            }
            catch
            {

            }
        }

        private void BarcodeMode_cb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
