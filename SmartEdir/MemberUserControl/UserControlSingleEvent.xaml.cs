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

namespace SmartEdir.MemberUserControl
{
    /// <summary>
    /// Interaction logic for UserControlSingleEvent.xaml
    /// </summary>
    public partial class UserControlSingleEvent : UserControl
    {
        private string date;
        private string address;
        private string detail;
        public UserControlSingleEvent(string date, string address, string detail)
        {
            InitializeComponent();
            this.date = date;
            this.address = address;
            this.detail = detail;
            InitializeDetail();
        }
        private void InitializeDetail() {
            Date.Text = date;
            Address.Text = address;
            Detail.Text = detail;
        }
    }
}
