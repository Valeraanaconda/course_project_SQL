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
using Microsoft.Win32;

using Syncfusion.DocIO.DLS;
using System.ComponentModel;



namespace SQl_Course_project
{
    /// <summary>
    /// Логика взаимодействия для Report_from_deal.xaml
    /// </summary>
    public partial class Report_from_deal : Window
    {

        public void fill_apartaments_deal()
        {
            list.Items.Clear();
            using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
            {
                foreach (var item in db.deal_with_appartment)
                {
                    list.Items.Add($"Квартира: Кадастровый номер: {item.cadastral_number} Площадь квартиры: {item.area_ap} Колличество балконов: {item.number_of_balconies} Колличество комнат: {item.number_of_rooms} Пкупатель: {item.customer} Продавец: {item.saller} Цена: {item.price}");
                }
            }
        }
        public void fill_house_deal()
        {
            list.Items.Clear();
            using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
            {
                foreach (var item in db.deal_with_house)
                {
                    list.Items.Add($"Дом: Кадастровый номер: {item.cadastral_number} Площадь дома: {item.area_h} Количество комнат: {item.number_of_rooms} Количество этажей: {item.number_of_rooms} Покупатель: {item.customer} Продавец: {item.saller} Цена: {item.price}");
                }
            }
        }
        public Report_from_deal()
        {
            InitializeComponent();
            fill_apartaments_deal();
            fill_house_deal();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            Close();
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "Transaktion_report"; // Default file name
            dlg.DefaultExt = ".doc"; // Default file extension
            dlg.Filter = "Text documents (.doc)|*.doc"; // Filter files by extension
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                CreateDocument(filename);
               
               
            }
        }
    }
}
