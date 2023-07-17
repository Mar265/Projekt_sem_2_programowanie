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
using Microsoft.Data.SqlClient;
using System.Data;

namespace Projekt_sem_2_programowanie
{
    /// <summary>
    /// Logika interakcji dla klasy Window3.xaml
    /// </summary>
    /// 
    //Okno nr 3 służące do zgłaszania awarii dla danych maszyn 
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            LoadGrid();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-Q063QP0;Initial Catalog=DB_2023_07;Integrated Security=True;Encrypt=False");
        private void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Awarie", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGrid.ItemsSource = dt.DefaultView;
        }

        //Sprawdzenie czy żadne pole nie jest puste
        public bool isValid()
        {
            if (WtryskarkaText.Text == string.Empty)
            {
                MessageBox.Show("Wtryskarka is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (PersonName.Text == string.Empty)
            {
                MessageBox.Show("PersonName is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (KosztAwarii.Text == string.Empty)
            {
                MessageBox.Show("KosztAwarii is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            return true;
        }
        //Potwierdzenie Operacji
        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isValid())
                {

                    SqlCommand cmd = new SqlCommand("INSERT INTO Awarie (nrMaszyny, Person_Name, KosztAwarii) VALUES (@nrMaszyny, @Person_Name, @KosztAwarii)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nrMaszyny", WtryskarkaText.Text);
                    cmd.Parameters.AddWithValue("@Person_Name", PersonName.Text);
                    cmd.Parameters.AddWithValue("@KosztAwarii", KosztAwarii.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    LoadGrid();
                    MessageBox.Show("New Record Inserted Successfully");

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
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
        private void btnOpenWindow2_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
            foreach (Window window in Application.Current.Windows)
            {
                if (window != window2)
                {
                    window.Close();
                }
            }
        }
    }
}
