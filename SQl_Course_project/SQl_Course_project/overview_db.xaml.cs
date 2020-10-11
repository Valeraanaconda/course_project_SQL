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
    /// Логика взаимодействия для overview_db.xaml
    /// </summary>
    public partial class overview_db : Window
    {
        public void fill_apartaments()
        {
            using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
            {
                apartament.Items.Clear();
                string str = "";
                foreach (var item in db.apartment)
                {
                    if (item.state_p == 1) str = "покупка";
                    if (item.state_p == 2) str = "аренда";

                    apartament.Items.Add("площадь:" + item.area_ap + " " + "кол. комнат: " + item.number_of_rooms + " " + "кол.балконов: " + item.number_of_balconies + " " + "цена: " + item.price + " " + "продавец: " + item.owner_ap + " " + "адресс: " + item.address_ap + " " + "кадастровый номер: " + "\t" + item.cadastral_number + "\t сатус: " + str + "\t" + item.ID_apartment);
                }
                str = "";
            }
        }
        public void fill_house()
        {
            using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
            {
                house.Items.Clear();
                string str = "";
                foreach (var item in db.house)
                {
                    if (item.state_h == 1) str = "покупка";
                    if (item.state_h == 2) str = "аренда";
                    house.Items.Add("площадь жилья:" + item.area_h + " " + "площадь участка:" + item.area_plot + " " + "кол. комнат: " + item.number_of_rooms + " " + "кол. этажей: " + item.number_of_floor + " " + "цена: " + item.price + " " + "продавец: " + item.owner_h + " " + "адресс: " + item.address_h + " " + "кадастровый номер: " + item.cadastral_number + " сатус: " + str + " ID: \t" + item.ID_house);
                }
            }
        }
        public void fill_clients()
        {
            client.Items.Clear();
            using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
            {
                foreach (var item in db.client)
                {
                    client.Items.Add("ФИО: " + item.Full_name + " номер паспорта: " + item.passport_ID + " орг.выдачи: " + item.issued_by + " дата рождения: " + item.date_of_birth + "." + item.month_of_birth + "." + item.year_of_birth + " адрес прописки: " + item.place_of_residence+"ID: \t"+item.ID_client);
                }
            }
        }
        public void fill_worker()
        {
            worker.Items.Clear();
            using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
            {
                foreach (var item in db.worker_c)
                {
                    worker.Items.Add("ФИО: " + item.full_name + " должность: " + item.position + " пароль: " + item.password_w+" ID: \t"+item.ID_worker);
                }
            }
        }

        public overview_db()
        {
            InitializeComponent();
            fill_apartaments();
            fill_house();
            fill_clients();
            fill_worker();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Add_apartament w = new Add_apartament();
            w.Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Add_house w = new Add_house();
            w.Show();
            Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Add_customer w = new Add_customer();
            w.Show();
            Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Add_worker w = new Add_worker();
            w.Show();
            Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string[] or = apartament.SelectedItem.ToString().Split('\t');
            using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
            {
                db.Delete_apaetament(Convert.ToInt32(or[1]));
                db.SaveChanges();
                MessageBox.Show("Объект удалён");
                fill_apartaments();
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            string[] or = house.SelectedItem.ToString().Split('\t');
            using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
            {
                db.Delete_house(Convert.ToInt32(or[1]));
                db.SaveChanges();
                MessageBox.Show("Объект удалён");
                fill_house();
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            string[] or = client.SelectedItem.ToString().Split('\t');
            using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
            {
                db.Delete_client(Convert.ToInt32(or[1]));
                db.SaveChanges();
                MessageBox.Show("Объект удалён");
                fill_clients();
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            string[] or = worker.SelectedItem.ToString().Split('\t');
            using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
            {
                db.Delete_worker(Convert.ToInt32(or[1]));
                db.SaveChanges();
                MessageBox.Show("Объект удалён");
                fill_worker();
            }
        }
        private void Apartament_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            del.Visibility = Visibility.Visible;
            del2.Visibility = Visibility.Hidden;
            del3.Visibility = Visibility.Hidden;
            del4.Visibility = Visibility.Hidden;
        }

        private void House_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            del.Visibility = Visibility.Hidden;
            del2.Visibility = Visibility.Visible;
            del3.Visibility = Visibility.Hidden;
            del4.Visibility = Visibility.Hidden;
        }

        private void Client_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            del.Visibility = Visibility.Hidden;
            del2.Visibility = Visibility.Hidden;
            del3.Visibility = Visibility.Visible;
            del4.Visibility = Visibility.Hidden;
        }

        private void Worker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            del.Visibility = Visibility.Hidden;
            del2.Visibility = Visibility.Hidden;
            del3.Visibility = Visibility.Hidden;
            del4.Visibility = Visibility.Visible;
        }

       
    }
}
