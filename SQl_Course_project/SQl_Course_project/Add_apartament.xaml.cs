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
    /// Логика взаимодействия для Add_apartament.xaml
    /// </summary>
    public partial class Add_apartament : Window
    {
        public Add_apartament()
        {
            InitializeComponent();
            state.Items.Add("Продажа");
            state.Items.Add("Здача в аренду");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int state_p = 0;
            if (state.SelectedValue.ToString() == "Продажа") state_p = 1;
            if (state.SelectedValue.ToString() == "Здача в аренду") state_p = 2;


            using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
            {
                db.Add_apartment(Convert.ToDouble(area.Text), Convert.ToInt32(rooms.Text), Convert.ToDouble(price.Text),full_name.Text, adress.Text, Convert.ToInt32(balc.Text), Convert.ToInt32(globalTrash.rand.Next(100000000, 999999999)),state_p);
                db.SaveChanges();
                MessageBox.Show("квартира добавленна");
                area.Text = "";
                rooms.Text = "";
                price.Text = "";
                adress.Text = "";
                balc.Text = "";
                full_name.Text = "";

            }
            state_p = 0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            overview_db w = new overview_db();
            w.Show();
            Close();
        }
    }
}
