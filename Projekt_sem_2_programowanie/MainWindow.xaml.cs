﻿using System;
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
        }

        public void  clearData()
        {
            name_txt.Clear();
            age_txt.Clear();
            gender_txt.Clear();
            city_txt.Clear();
        }
        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            clearData();
        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}