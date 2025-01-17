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
using System.Windows.Shapes;

namespace SmartEdir.DialogBoxs
{
    /// <summary>
    /// Interaction logic for WindowConfirmation.xaml
    /// </summary>
    public partial class WindowConfirmation : Window
    {
        public WindowConfirmation()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
