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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;



namespace Projekt_sem_2_programowanie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 



    //Okno główne pozwala nam zarządzać pracownikami
    // oraz wyświetla wszystkich pracowników
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadGrid();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-Q063QP0;Initial Catalog=DB_2023_07;Integrated Security=True;Encrypt=False");

        public void  clearData()
        {
            name_txt.Clear();
            age_txt.Clear();
            gender_txt.Clear();
            city_txt.Clear();
            search_txt.Clear();
            position_txt.Clear();
        }

        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("select * from Person ", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }
        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            clearData();
        }
        //Sprawdzenie czy żadne pole nie jest puste
        public bool isValid()
        {
            if (name_txt.Text == string.Empty)
            { 
                MessageBox.Show("Name is required","Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (age_txt.Text == string.Empty)
            {
                MessageBox.Show("Age is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (gender_txt.Text == string.Empty)
            {
                MessageBox.Show("Gender is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (city_txt.Text == string.Empty)
            {
                MessageBox.Show("City is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (position_txt.Text== string.Empty)
            {
                MessageBox.Show("Position is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
          
            return true;
        }
        //Potwierdzenie Operacji
        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
           try
            {
                if (isValid())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Person Values (@Name,@Age,@Gender,@City,@Position)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Name", name_txt.Text);
                    cmd.Parameters.AddWithValue("@Age", age_txt.Text);
                    cmd.Parameters.AddWithValue("@Gender", gender_txt.Text);
                    cmd.Parameters.AddWithValue("@City", city_txt.Text);
                    cmd.Parameters.AddWithValue("@Position", position_txt.Text);
                   

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    LoadGrid();
                    MessageBox.Show("Successfully registered", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearData();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Usunięcie rejestru (pracownika)
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Person where ID = "+ search_txt.Text+" ", con);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been deleted","Deleted", MessageBoxButton.OK,MessageBoxImage.Information);
                con.Close() ;
                clearData();
                LoadGrid();
                con.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Not Deleted"+ex.Message);
            }
            finally
            {
                con.Close();
            }

        }
        //zamiana rejestru (danych pracownika) 
        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update Person set Name = @Name, Age = @Age, Gender = @Gender, City = @City, Position = @Position ", con);
            cmd.Parameters.AddWithValue("@Name", name_txt.Text);
            cmd.Parameters.AddWithValue("@Age", age_txt.Text);
            cmd.Parameters.AddWithValue("@Gender", gender_txt.Text);
            cmd.Parameters.AddWithValue("@City", city_txt.Text);
            cmd.Parameters.AddWithValue("@Position", position_txt.Text);
           
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been updated successfully", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch( SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                clearData();
                LoadGrid();
                
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

    }
}
