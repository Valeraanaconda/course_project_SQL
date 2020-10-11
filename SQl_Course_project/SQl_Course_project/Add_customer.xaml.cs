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
    /// Логика взаимодействия для Add_customer.xaml
    /// </summary>
    public partial class Add_customer : Window
    {
        public Add_customer()
        {
            InitializeComponent();
        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
            {
                db.Add_client(name.Text, ps_n.Text, is_by.Text, Convert.ToInt32(year.Text), Convert.ToInt32(day.Text), Convert.ToInt32(mouth.Text), pl_of_res.Text);
                db.SaveChanges();
                MessageBox.Show("Клиент добавлен");
                name.Text = "";
                ps_n.Text = "";
                year.Text = "";
                day.Text = "";
                mouth.Text = "";
                pl_of_res.Text = "";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            overview_db w = new overview_db();
            w.Show();
            Close();
        }
    }
}
