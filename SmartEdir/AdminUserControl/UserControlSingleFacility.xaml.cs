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

namespace SmartEdir.AdminUserControl
{
    /// <summary>
    /// Interaction logic for UserControlSingleFacility.xaml
    /// </summary>
    public partial class UserControlSingleFacility : UserControl
    {
        private string name;
        private string phone;
        private string date;
        private string subject;
        private string body;
        public UserControlSingleFacility(string name, string phone, string date, string subject, string body)
        {
            InitializeComponent();
            this.name = name;
            this.phone = phone;
            this.date = date;
            this.subject = subject;
            this.body = body;
            InitializeFacility();
        }

        private void InitializeFacility()
        {
            FullName.Text = name;
            Phone.Text = phone;
            Date.Text = date;
            Subject.Text = subject;
            Body.Text = body;

        }
    }
}
