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
    /// Логика взаимодействия для Add_worker.xaml
    /// </summary>
    public partial class Add_worker : Window
    {
        public Add_worker()
        {
            InitializeComponent();
            pos.Items.Add("Администратор");
            pos.Items.Add("Рабочий");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            overview_db w = new overview_db();
            w.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
            {
                db.Add_worker(pos.SelectedValue.ToString(), Convert.ToInt32(passw.Text), Name.Text);
                db.SaveChanges();
                MessageBox.Show("рабочий добавлен");
                passw.Text = "";
                Name.Text = "";
            }
        }
    }
}
