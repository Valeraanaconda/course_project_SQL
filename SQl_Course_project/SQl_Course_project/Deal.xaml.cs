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
                    list.Items.Add("площадь жилья: \t" + item.area_h + "\t " + "площадь участка: \t" + item.area_plot + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол. этажей: \t" + item.number_of_floor + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_h + " \t" + "адресс: \t" + item.address_h + " \t" + "кадастровый номер: \t" + item.cadastral_number + "\t сатус: " + str);
                }
            }
        }
        public void fill_comboboxes()
        {
            type.Items.Add("Квартира");
            type.Items.Add("Дом");
            kv.Items.Add("Макс.");
            kv.Items.Add("Мин.");
            pl.Items.Add("Макс.");
            pl.Items.Add("Мин.");
            bol.Items.Add("Макс.");
            bol.Items.Add("Мин.");
            pr.Items.Add("Макс.");
            pr.Items.Add("Мин.");

            kv_h.Items.Add("Макс.");
            kv_h.Items.Add("Мин.");
            fl_h.Items.Add("Макс.");
            fl_h.Items.Add("Мин.");
            pl_h.Items.Add("Макс.");
            pl_h.Items.Add("Мин.");
            pl_pt_h.Items.Add("Макс.");
            pl_pt_h.Items.Add("Мин.");
            pr_h.Items.Add("Макс.");
            pr_h.Items.Add("Мин.");
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
            else if (type.SelectedValue.ToString() == "Дом")
            {
                fill_house();
                sort_grid_h.Visibility = Visibility.Visible;
                sort_grid.Visibility = Visibility.Hidden;
            }

        }

        private void Type_d(object sender, SelectionChangedEventArgs e)
        {
            if (kv.SelectedValue.ToString() == "Макс." && type.SelectedValue.ToString() == "Квартира")
            {
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    list.Items.Clear();
                    string str = "";
                    var rooms_h = db.apartment.OrderByDescending(r => r.number_of_rooms);
                    foreach (var item in rooms_h)
                    {
                        if (item.state_p == 1) str = "покупка";
                        if (item.state_p == 2) str = "аренда";

                        list.Items.Add("площадь: \t" + item.area_ap + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол.балконов: \t" + item.number_of_balconies + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_ap + "\t " + "адресс: \t" + item.address_ap + "\t " + "кадастровый номер: " + "\t" + item.cadastral_number + "\t сатус: " + str);
                    }
                    str = "";
                }
            }
            if (kv.SelectedValue.ToString() == "Мин." && type.SelectedValue.ToString() == "Квартира")
            {
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {

                    list.Items.Clear();
                    string str = "";
                    var rooms_l = db.apartment.OrderBy(r => r.number_of_rooms);
                    foreach (var item1 in rooms_l)
                    {
                        if (item1.state_p == 1) str = "покупка";
                        if (item1.state_p == 2) str = "аренда";

                        list.Items.Add("площадь: \t" + item1.area_ap + "\t " + "кол. комнат: \t" + item1.number_of_rooms + "\t " + "кол.балконов: \t" + item1.number_of_balconies + "\t " + "цена: \t" + item1.price + "\t " + "продавец: \t" + item1.owner_ap + "\t " + "адресс: \t" + item1.address_ap + "\t " + "кадастровый номер: " + "\t" + item1.cadastral_number + "\t сатус: " + str);
                    }
                    str = "";

                }
            }
        }

        private void Pl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pl.SelectedValue.ToString() == "Макс." && type.SelectedValue.ToString() == "Квартира")
            {
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    list.Items.Clear();
                    string str = "";
                    var plo_h = db.apartment.OrderByDescending(r => r.area_ap);
                    foreach (var item in plo_h)
                    {
                        if (item.state_p == 1) str = "покупка";
                        if (item.state_p == 2) str = "аренда";

                        list.Items.Add("площадь: \t" + item.area_ap + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол.балконов: \t" + item.number_of_balconies + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_ap + "\t " + "адресс: \t" + item.address_ap + "\t " + "кадастровый номер: " + "\t" + item.cadastral_number + "\t сатус: " + str);
                    }
                    str = "";
                }
            }
            if (pl.SelectedValue.ToString() == "Мин." && type.SelectedValue.ToString() == "Квартира")
            {
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {

                    list.Items.Clear();
                    string str = "";
                    var plo_l = db.apartment.OrderBy(r => r.area_ap);
                    foreach (var item1 in plo_l)
                    {
                        if (item1.state_p == 1) str = "покупка";
                        if (item1.state_p == 2) str = "аренда";

                        list.Items.Add("площадь: \t" + item1.area_ap + "\t " + "кол. комнат: \t" + item1.number_of_rooms + "\t " + "кол.балконов: \t" + item1.number_of_balconies + "\t " + "цена: \t" + item1.price + "\t " + "продавец: \t" + item1.owner_ap + "\t " + "адресс: \t" + item1.address_ap + "\t " + "кадастровый номер: " + "\t" + item1.cadastral_number + "\t сатус: " + str);
                    }
                    str = "";

                }
            }
        }

        private void Bol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bol.SelectedValue.ToString() == "Макс." && type.SelectedValue.ToString() == "Квартира")
            {
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    list.Items.Clear();
                    string str = "";
                    var bol_h = db.apartment.OrderByDescending(r => r.number_of_balconies);
                    foreach (var item in bol_h)
                    {
                        if (item.state_p == 1) str = "покупка";
                        if (item.state_p == 2) str = "аренда";

                        list.Items.Add("площадь: \t" + item.area_ap + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол.балконов: \t" + item.number_of_balconies + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_ap + "\t " + "адресс: \t" + item.address_ap + "\t " + "кадастровый номер: " + "\t" + item.cadastral_number + "\t сатус: " + str);
                    }
                    str = "";
                }
            }
            if (bol.SelectedValue.ToString() == "Мин." && type.SelectedValue.ToString() == "Квартира")
            {
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {

                    list.Items.Clear();
                    string str = "";
                    var bol_l = db.apartment.OrderBy(r => r.number_of_balconies);
                    foreach (var item1 in bol_l)
                    {
                        if (item1.state_p == 1) str = "покупка";
                        if (item1.state_p == 2) str = "аренда";

                        list.Items.Add("площадь: \t" + item1.area_ap + "\t " + "кол. комнат: \t" + item1.number_of_rooms + "\t " + "кол.балконов: \t" + item1.number_of_balconies + "\t " + "цена: \t" + item1.price + "\t " + "продавец: \t" + item1.owner_ap + "\t " + "адресс: \t" + item1.address_ap + "\t " + "кадастровый номер: " + "\t" + item1.cadastral_number + "\t сатус: " + str);
                    }
                    str = "";

                }
            }
        }

        private void Pr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pr.SelectedValue.ToString() == "Макс." && type.SelectedValue.ToString() == "Квартира")
            {
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    list.Items.Clear();
                    string str = "";
                    var pr_h = db.apartment.OrderByDescending(r => r.price);
                    foreach (var item in pr_h)
                    {
                        if (item.state_p == 1) str = "покупка";
                        if (item.state_p == 2) str = "аренда";

                        list.Items.Add("площадь: \t" + item.area_ap + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол.балконов: \t" + item.number_of_balconies + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_ap + "\t " + "адресс: \t" + item.address_ap + "\t " + "кадастровый номер: " + "\t" + item.cadastral_number + "\t сатус: " + str);
                    }
                    str = "";
                }
            }
            if (pr.SelectedValue.ToString() == "Мин." && type.SelectedValue.ToString() == "Квартира")
            {
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {

                    list.Items.Clear();
                    string str = "";
                    var pr_l = db.apartment.OrderBy(r => r.price);
                    foreach (var item1 in pr_l)
                    {
                        if (item1.state_p == 1) str = "покупка";
                        if (item1.state_p == 2) str = "аренда";

                        list.Items.Add("площадь: \t" + item1.area_ap + "\t " + "кол. комнат: \t" + item1.number_of_rooms + "\t " + "кол.балконов: \t" + item1.number_of_balconies + "\t " + "цена: \t" + item1.price + "\t " + "продавец: \t" + item1.owner_ap + "\t " + "адресс: \t" + item1.address_ap + "\t " + "кадастровый номер: " + "\t" + item1.cadastral_number + "\t сатус: " + str);
                    }
                    str = "";
                }

            }
        }

        private void Fl_h_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fl_h.SelectedValue.ToString() == "Макс." && type.SelectedValue.ToString() == "Дом")
            {
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    list.Items.Clear();
                    string str = "";

                    var rooms_h = db.house.OrderByDescending(r => r.number_of_floor);
                    foreach (var item in rooms_h)
                    {
                        if (item.state_h == 1) str = "покупка";
                        if (item.state_h == 2) str = "аренда";
                        list.Items.Add("площадь жилья: \t" + item.area_h + "\t " + "площадь участка: \t" + item.area_plot + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол. этажей: \t" + item.number_of_floor + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_h + " \t" + "адресс: \t" + item.address_h + " \t" + "кадастровый номер: \t" + item.cadastral_number + "\t сатус: " + str);
                    }
                    str = "";
                }
            }
            if (fl_h.SelectedValue.ToString() == "Мин." && type.SelectedValue.ToString() == "Дом")
            {

                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    list.Items.Clear();
                    string str = "";

                    var rooms_h = db.house.OrderBy(r => r.number_of_floor);
                    foreach (var item in rooms_h)
                    {
                        if (item.state_h == 1) str = "покупка";
                        if (item.state_h == 2) str = "аренда";
                        list.Items.Add("площадь жилья: \t" + item.area_h + "\t " + "площадь участка: \t" + item.area_plot + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол. этажей: \t" + item.number_of_floor + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_h + " \t" + "адресс: \t" + item.address_h + " \t" + "кадастровый номер: \t" + item.cadastral_number + "\t сатус: " + str);
                    }
                    str = "";
                }

            }
        }

        private void Type_h(object sender, SelectionChangedEventArgs e)
        {
            if (kv_h.SelectedValue.ToString() == "Макс." && type.SelectedValue.ToString() == "Дом")
            {
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    list.Items.Clear();
                    string str = "";

                    var rooms_h = db.house.OrderByDescending(r => r.number_of_rooms);
                    foreach (var item in rooms_h)
                    {
                        if (item.state_h == 1) str = "покупка";
                        if (item.state_h == 2) str = "аренда";
                        list.Items.Add("площадь жилья: \t" + item.area_h + "\t " + "площадь участка: \t" + item.area_plot + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол. этажей: \t" + item.number_of_floor + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_h + " \t" + "адресс: \t" + item.address_h + " \t" + "кадастровый номер: \t" + item.cadastral_number + "\t сатус: " + str);
                    }
                    str = "";
                }
            }
            if (kv_h.SelectedValue.ToString() == "Мин." && type.SelectedValue.ToString() == "Дом")
            {

                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    list.Items.Clear();
                    string str = "";

                    var rooms_h = db.house.OrderBy(r => r.number_of_rooms);
                    foreach (var item in rooms_h)
                    {
                        if (item.state_h == 1) str = "покупка";
                        if (item.state_h == 2) str = "аренда";
                        list.Items.Add("площадь жилья: \t" + item.area_h + "\t " + "площадь участка: \t" + item.area_plot + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол. этажей: \t" + item.number_of_floor + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_h + " \t" + "адресс: \t" + item.address_h + " \t" + "кадастровый номер: \t" + item.cadastral_number + "\t сатус: " + str);
                    }
                    str = "";
                }

            }
        }

        private void Pl_SelectionChange_h(object sender, SelectionChangedEventArgs e)
        {
            if (pl_h.SelectedValue.ToString() == "Макс." && type.SelectedValue.ToString() == "Дом")
            {
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    list.Items.Clear();
                    string str = "";

                    var rooms_h = db.house.OrderByDescending(r => r.area_h);
                    foreach (var item in rooms_h)
                    {
                        if (item.state_h == 1) str = "покупка";
                        if (item.state_h == 2) str = "аренда";
                        list.Items.Add("площадь жилья: \t" + item.area_h + "\t " + "площадь участка: \t" + item.area_plot + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол. этажей: \t" + item.number_of_floor + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_h + " \t" + "адресс: \t" + item.address_h + " \t" + "кадастровый номер: \t" + item.cadastral_number + "\t сатус: " + str);
                    }
                    str = "";
                }
            }
            if (pl_h.SelectedValue.ToString() == "Мин." && type.SelectedValue.ToString() == "Дом")
            {

                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    list.Items.Clear();
                    string str = "";

                    var rooms_h = db.house.OrderBy(r => r.area_h);
                    foreach (var item in rooms_h)
                    {
                        if (item.state_h == 1) str = "покупка";
                        if (item.state_h == 2) str = "аренда";
                        list.Items.Add("площадь жилья: \t" + item.area_h + "\t " + "площадь участка: \t" + item.area_plot + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол. этажей: \t" + item.number_of_floor + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_h + " \t" + "адресс: \t" + item.address_h + " \t" + "кадастровый номер: \t" + item.cadastral_number + "\t сатус: " + str);
                    }
                    str = "";
                }
            }
        }
        private void Pl_pt_h_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pl_pt_h.SelectedValue.ToString() == "Макс." && type.SelectedValue.ToString() == "Дом")
            {
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    list.Items.Clear();
                    string str = "";

                    var rooms_h = db.house.OrderByDescending(r => r.area_plot);
                    foreach (var item in rooms_h)
                    {
                        if (item.state_h == 1) str = "покупка";
                        if (item.state_h == 2) str = "аренда";
                        list.Items.Add("площадь жилья: \t" + item.area_h + "\t " + "площадь участка: \t" + item.area_plot + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол. этажей: \t" + item.number_of_floor + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_h + " \t" + "адресс: \t" + item.address_h + " \t" + "кадастровый номер: \t" + item.cadastral_number + "\t сатус: " + str);
                    }
                    str = "";
                }
            }
            if (pl_pt_h.SelectedValue.ToString() == "Мин." && type.SelectedValue.ToString() == "Дом")
            {

                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    list.Items.Clear();
                    string str = "";

                    var rooms_h = db.house.OrderBy(r => r.area_plot);
                    foreach (var item in rooms_h)
                    {
                        if (item.state_h == 1) str = "покупка";
                        if (item.state_h == 2) str = "аренда";
                        list.Items.Add("площадь жилья: \t" + item.area_h + "\t " + "площадь участка: \t" + item.area_plot + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол. этажей: \t" + item.number_of_floor + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_h + " \t" + "адресс: \t" + item.address_h + " \t" + "кадастровый номер: \t" + item.cadastral_number + "\t сатус: " + str);
                    }
                    str = "";
                }
            }
        }

        private void Pr_h_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pr_h.SelectedValue.ToString() == "Макс." && type.SelectedValue.ToString() == "Дом")
            {
                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    list.Items.Clear();
                    string str = "";

                    var rooms_h = db.house.OrderByDescending(r => r.price);
                    foreach (var item in rooms_h)
                    {
                        if (item.state_h == 1) str = "покупка";
                        if (item.state_h == 2) str = "аренда";
                        list.Items.Add("площадь жилья: \t" + item.area_h + "\t " + "площадь участка: \t" + item.area_plot + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол. этажей: \t" + item.number_of_floor + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_h + " \t" + "адресс: \t" + item.address_h + " \t" + "кадастровый номер: \t" + item.cadastral_number + "\t сатус: " + str);
                    }
                    str = "";
                }
            }
            if (pr_h.SelectedValue.ToString() == "Мин." && type.SelectedValue.ToString() == "Дом")
            {

                using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
                {
                    list.Items.Clear();
                    string str = "";

                    var rooms_h = db.house.OrderBy(r => r.price);
                    foreach (var item in rooms_h)
                    {
                        if (item.state_h == 1) str = "покупка";
                        if (item.state_h == 2) str = "аренда";
                        list.Items.Add("площадь жилья: \t" + item.area_h + "\t " + "площадь участка: \t" + item.area_plot + "\t " + "кол. комнат: \t" + item.number_of_rooms + "\t " + "кол. этажей: \t" + item.number_of_floor + "\t " + "цена: \t" + item.price + "\t " + "продавец: \t" + item.owner_h + " \t" + "адресс: \t" + item.address_h + " \t" + "кадастровый номер: \t" + item.cadastral_number + "\t сатус: " + str);
                    }
                    str = "";
                }
            }
        }
    }
}
