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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SQl_Course_project
{
    class globalTrash
    {
        public static Random rand = new Random();
        public static bool user_status = false;

        public static bool isreg = false;
    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            pos.Items.Add("Рабочий");
            pos.Items.Add("Администратор");
            if(globalTrash.isreg == true) isInside(globalTrash.user_status);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            overview_db w = new overview_db();
            w.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Deal w = new Deal();
            w.Show();
            Close();
        }

        private void Pos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void isInside(bool pos)
        {
            if (globalTrash.user_status == true)
            {
                reg.Visibility = Visibility.Hidden;
                buttons.Visibility = Visibility.Visible;
            }
            else
            {
                reg.Visibility = Visibility.Hidden;
                buttons.Visibility = Visibility.Visible;
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
            {
                foreach (var item in db.worker_c)
                {
                    if (pos.SelectedValue.ToString() == "Рабочий" && item.password_w == Convert.ToInt32(password.Text))
                    {
                        MessageBox.Show($"Добрый день! \n{item.full_name}\nХорошего рабочего дня");
                        reg.Visibility = Visibility.Hidden;
                        buttons.Visibility = Visibility.Visible;
                        globalTrash.isreg = true;
                        break;

                    }
                    if (pos.SelectedValue.ToString() == "Администратор" && item.password_w == Convert.ToInt32(password.Text))
                    {
                        MessageBox.Show($"Добрый день! \n {item.full_name} \n Хорошего рабочего дня");
                        globalTrash.user_status = true;
                        globalTrash.isreg = true;
                        reg.Visibility = Visibility.Hidden;
                        buttons.Visibility = Visibility.Visible;
                        break;
                    }
                }
                
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Report_from_deal w = new Report_from_deal();
            w.Show();
            Close();
        }
    }
}
