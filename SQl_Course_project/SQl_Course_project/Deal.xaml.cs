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

namespace SQl_Course_project
{
    /// <summary>
    /// Логика взаимодействия для Deal.xaml
    /// </summary>
    public partial class Deal : Window
    {
        public void fill_apartaments()
        {
            using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
            {
                list.Items.Clear();
                string str = "";
                foreach (var item in db.apartment)
                {
                    if (item.state_p == 1) str = "покупка";
                    if (item.state_p == 2) str = "аренда";

                    list.Items.Add("площадь: \t" + item.area_ap + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол.балконов: \t" + item.number_of_balconies + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_ap + "\t " + "адресс: \t" + item.address_ap + "\t " + "кадастровый номер: " + "\t" + item.cadastral_number + "\t сатус: " + str);
                }
                str = "";
            }
        }
        public void fill_house()
        {
            using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
            {
                list.Items.Clear();
                string str = "";
                foreach (var item in db.house)
                {
                    if (item.state_h == 1) str = "покупка";
                    if (item.state_h == 2) str = "аренда";
                    list.Items.Add("площадь жилья: \t" + item.area_h + "\t " + "площадь участка: \t" + item.area_plot + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол. этажей: \t" + item.number_of_floor + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_h + " \t" + "адресс: \t" + item.address_h + " \t" + "кадастровый номер: \t" + item.cadastral_number + "\t сатус: " + str + "\t" + item.ID_house);
                }
            }
        }
        public void fill_comboboxes()
        {
            type.Items.Add("Квартира");
            type.Items.Add("Дом");
            op.Items.Add("Покупка");
            op.Items.Add("Аренда");

        }
        public Deal()
        {
            InitializeComponent();
            using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
            {
                foreach (var item in db.client)
                {
                    client.Items.Add(item.Full_name);
                }
            }
            fill_comboboxes();
        }




        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            Close();
        }
        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (type.SelectedValue.ToString() == "Квартира")
            {
                fill_apartaments();
                sort_grid.Visibility = Visibility.Visible;
                sort_grid_h.Visibility = Visibility.Hidden;
            }
            if (type.SelectedValue.ToString() == "Дом")
            {
                fill_house();
                sort_grid_h.Visibility = Visibility.Visible;
                sort_grid.Visibility = Visibility.Hidden;
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (type.SelectedValue.ToString() == "Квартира")
            {
                string[] ord = list.SelectedValue.ToString().Split('\t');
                string key = client.SelectedValue.ToString();
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    var client_ID = db.client.Where(p => p.Full_name == key.ToString()).FirstOrDefault().ID_client;
                    int id = Convert.ToInt32(client_ID);
                    db.Add_deal_with_appartent(Convert.ToInt32(ord[13]), Convert.ToDouble(ord[1]), Convert.ToInt32(ord[5]), Convert.ToInt32(3), client.SelectedValue.ToString(), ord[9], Convert.ToDouble(ord[7]));
                    db.Delete_client(id);
                    db.Delete_apaetament(Convert.ToInt32(ord[13]));
                    db.SaveChanges();
                    MessageBox.Show("add");
                }
                fill_apartaments();
            }
            if (type.SelectedValue.ToString() == "Дом")
            {
                string[] ord = list.SelectedValue.ToString().Split('\t');
                string key = client.SelectedValue.ToString();

                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    var client_ID = db.client.Where(p => p.Full_name == key.ToString()).FirstOrDefault().ID_client;
                    int id = Convert.ToInt32(client_ID);

                    db.Add_deal_with_house(Convert.ToInt32(ord[15]), Convert.ToInt32(ord[5]), Convert.ToInt32(ord[7]), Convert.ToDouble(ord[3]), client.SelectedValue.ToString(), ord[11], Convert.ToDouble(ord[9]));
                    db.Delete_client(id);
                    db.Delete_house(Convert.ToInt32(ord[17]));
                    db.SaveChanges();
                    MessageBox.Show("add");
                }
                fill_house();
            }

        }

      

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            del.Visibility = Visibility.Visible;
        }
        //////тут происходит поиск
        private void Op_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (op.SelectedValue.ToString() == "Покупка" && type.SelectedValue.ToString() == "Квартира")
            {
                list.Items.Clear();
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    foreach (var item in db.apartment.Where(a => a.state_p == 1))
                    {
                        list.Items.Add("площадь: \t" + item.area_ap + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол.балконов: \t" + item.number_of_balconies + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_ap + "\t " + "адресс: \t" + item.address_ap + "\t " + "кадастровый номер: " + "\t" + item.cadastral_number);
                    }
                }
            }
            if (op.SelectedValue.ToString() == "Аренда" && type.SelectedValue.ToString() == "Квартира")
            {
                list.Items.Clear();
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    foreach (var item in db.apartment.Where(a => a.state_p == 2))
                    {
                        list.Items.Add("площадь: \t" + item.area_ap + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол.балконов: \t" + item.number_of_balconies + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_ap + "\t " + "адресс: \t" + item.address_ap + "\t " + "кадастровый номер: " + "\t" + item.cadastral_number);
                    }
                }
            }
            if (op.SelectedValue.ToString() == "Покупка" && type.SelectedValue.ToString() == "Дом")
            {
                list.Items.Clear();
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    foreach (var item in db.house.Where(a => a.state_h == 1))
                    {
                        list.Items.Add("площадь жилья: \t" + item.area_h + "\t " + "площадь участка: \t" + item.area_plot + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол. этажей: \t" + item.number_of_floor + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_h + " \t" + "адресс: \t" + item.address_h + " \t" + "кадастровый номер: \t" + item.cadastral_number);
                    }
                }
            }
            if (op.SelectedValue.ToString() == "Аренда" && type.SelectedValue.ToString() == "Дом")
            {
                list.Items.Clear();
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    foreach (var item in db.house.Where(a => a.state_h == 2))
                    {
                        list.Items.Add("площадь жилья: \t" + item.area_h + "\t " + "площадь участка: \t" + item.area_plot + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол. этажей: \t" + item.number_of_floor + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_h + " \t" + "адресс: \t" + item.address_h + " \t" + "кадастровый номер: \t" + item.cadastral_number);
                    }
                }
            }

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (rom.Text != "")
            {
                int rom_count = Convert.ToInt32(rom.Text);
                list.Items.Clear();
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    foreach (var item in db.house.Where(a => a.number_of_rooms == rom_count))
                    {
                        list.Items.Add("площадь жилья: \t" + item.area_h + "\t " + "площадь участка: \t" + item.area_plot + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол. этажей: \t" + item.number_of_floor + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_h + " \t" + "адресс: \t" + item.address_h + " \t" + "кадастровый номер: \t" + item.cadastral_number);
                    }
                }
                rom.Text = "";
            }
            else { rom.Text = ""; }
            if (flor.Text != "")
            {
                int flor_count = Convert.ToInt32(flor.Text);
                list.Items.Clear();
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    foreach (var item in db.house.Where(a => a.number_of_floor == flor_count))
                    {
                        list.Items.Add("площадь жилья: \t" + item.area_h + "\t " + "площадь участка: \t" + item.area_plot + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол. этажей: \t" + item.number_of_floor + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_h + " \t" + "адресс: \t" + item.address_h + " \t" + "кадастровый номер: \t" + item.cadastral_number);
                    }
                }
                flor.Text = "";
            }
            else { flor.Text = ""; }
            if (p1.Text != "")
            {
                double pl_count = Convert.ToDouble(p1.Text);
                list.Items.Clear();
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    foreach (var item in db.house.Where(a => a.area_h == pl_count))
                    {
                        list.Items.Add("площадь жилья: \t" + item.area_h + "\t " + "площадь участка: \t" + item.area_plot + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол. этажей: \t" + item.number_of_floor + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_h + " \t" + "адресс: \t" + item.address_h + " \t" + "кадастровый номер: \t" + item.cadastral_number);
                    }
                }
                p1.Text = "";
            }
            else { p1.Text = ""; }
            if (p2.Text != "")
            {
                double pl_count = Convert.ToDouble(p2.Text);
                list.Items.Clear();
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    foreach (var item in db.house.Where(a => a.area_plot == pl_count))
                    {
                        list.Items.Add("площадь жилья: \t" + item.area_h + "\t " + "площадь участка: \t" + item.area_plot + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол. этажей: \t" + item.number_of_floor + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_h + " \t" + "адресс: \t" + item.address_h + " \t" + "кадастровый номер: \t" + item.cadastral_number);
                    }
                }
                p2.Text = "";
            }
            else { p2.Text = ""; }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (rom_p.Text != "")
            {
                double pl_count = Convert.ToDouble(rom_p.Text);
                list.Items.Clear();
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    foreach (var item in db.apartment.Where(a => a.number_of_rooms == pl_count))
                    {
                        list.Items.Add("площадь: \t" + item.area_ap + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол.балконов: \t" + item.number_of_balconies + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_ap + "\t " + "адресс: \t" + item.address_ap + "\t " + "кадастровый номер: " + "\t" + item.cadastral_number);
                    }
                }
                rom_p.Text = "";
            }
            else { rom_p.Text = ""; }
            if (b_p.Text != "")
            {
                double pl_count = Convert.ToDouble(b_p.Text);
                list.Items.Clear();
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    foreach (var item in db.apartment.Where(a => a.number_of_balconies == pl_count))
                    {
                        list.Items.Add("площадь: \t" + item.area_ap + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол.балконов: \t" + item.number_of_balconies + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_ap + "\t " + "адресс: \t" + item.address_ap + "\t " + "кадастровый номер: " + "\t" + item.cadastral_number);
                    }
                }
                b_p.Text = "";
            }
            else { b_p.Text = ""; }
        }
        //////////////////////
        

    }
}
