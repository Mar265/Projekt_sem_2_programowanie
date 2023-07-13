﻿using System;
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

        public bool isValid()
        {
            if (name_txt.Text == string.Empty)
            { 
                MessageBox.Show("Name is required","Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (age_txt.Text == string.Empty)
            {
                MessageBox.Show("Name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (gender_txt.Text == string.Empty)
            {
                MessageBox.Show("Name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (city_txt.Text == string.Empty)
            {
                MessageBox.Show("Name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            if(isValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Person Values (@Name,@Age,@Gender,@City)"), con;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name",name_txt.Text);
                cmd.Parameters.AddWithValue("@Age",age_txt.Text);
                cmd.Parameters.AddWithValue("@Gender",gender_txt.Text);
                cmd.Parameters.AddWithValue("@City",city_txt.Text);
            }
        }

       
    }
}
