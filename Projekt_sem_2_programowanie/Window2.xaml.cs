using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using Microsoft.Data.SqlClient;

namespace Projekt_sem_2_programowanie
{
    /// <summary>
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    /// 

    //Okno nr 2 Pozwala nam przejrzeć stan maszyn jakie są na wyposażeniu np.: zakładu
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            DataGrid_SelectionChanged();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-Q063QP0;Initial Catalog=DB_2023_07;Integrated Security=True;Encrypt=False");
        private void btnOpenWindow1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window1 = new MainWindow();
            window1.Show();
            foreach (Window window in Application.Current.Windows)
            {
                if (window != window1)
                {
                    window.Close();
                }
            }
        }

        private void btnOpenWindow3_Click(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new Window3();
            window3.Show();
            foreach (Window window in Application.Current.Windows)
            {
                if (window != window3)
                {
                    window.Close();
                }
            }
        }

        public void DataGrid_SelectionChanged()
        {
            SqlCommand cmd = new SqlCommand("select * from Wtryskarki ", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid2.ItemsSource = dt.DefaultView;
        }
    }
}
