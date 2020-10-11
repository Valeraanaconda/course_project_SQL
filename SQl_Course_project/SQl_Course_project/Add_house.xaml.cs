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
    /// Логика взаимодействия для Add_house.xaml
    /// </summary>
    public partial class Add_house : Window
    {
        public Add_house()
        {
            InitializeComponent();
            state_h.Items.Add("продажа");
            state_h.Items.Add("Здача в аренду");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            overview_db w = new overview_db();
            w.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int state_ho = 0;
            if (state_h.SelectedValue.ToString() == "Продажа") state_ho = 1;
            if (state_h.SelectedValue.ToString() == "Здача в аренду") state_ho = 2;
            using (Estate_agancyEntities1 db = new Estate_agancyEntities1())
            {
                db.Add_house(Convert.ToInt32(room.Text),Convert.ToInt32(floor.Text),Convert.ToInt32(area_h.Text),Convert.ToDouble(area_pl.Text),name.Text, addre.Text, Convert.ToInt32(globalTrash.rand.Next(100000000, 999999999)), state_ho,Convert.ToDouble(price.Text));

                db.SaveChanges();
                MessageBox.Show("Дом успешно добавлен");
                room.Text = "";
                floor.Text = "";
                area_h.Text = "";
                area_pl.Text = "";
                name.Text = "";
                addre.Text = "";
                price.Text = "";
            }

        }
    }
}
