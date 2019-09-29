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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartEdir.DialogBoxs
{
    /// <summary>
    /// Interaction logic for UserControlDeclined.xaml
    /// </summary>
    public partial class UserControlDeclined : UserControl
    {
        private string name;
        private string day;
        private string month;
        private int year;
        public UserControlDeclined(string name, string day, string month, int year)
        {
            InitializeComponent();
            this.name = name;
            this.day = day;
            this.month = month;
            this.year = year;
            InitializeContents();
        }
        private void InitializeContents()
        {
            FullName.Text = name.ToString();
            Info.Text = string.Format($"The Payment You've Made On {month}, {day} {year} Is Declined");
        }
    }
}
