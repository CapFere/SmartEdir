using SmartEdir.DBContext;
using SmartEdir.DialogBoxs;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for UserControlNotification.xaml
    /// </summary>
    public partial class UserControlNotification : UserControl
    {
        public UserControlNotification()
        {
            InitializeComponent();
            InitializeNotification();
        }

        private void InitializeNotification()
        {
            StreamReader sr = new StreamReader(@"C:\Users\Public\loginfo.txt");
            string email = sr.ReadLine();
            sr.Close();
            UserDBContext.IntitalizeDB();
            UserDBContext user = UserDBContext.GetUser(email);
            MemberDBContext.IntitalizeDB();
            MemberDBContext member = MemberDBContext.GetMember(user.MemberID);
            string fullName = string.Format($"{member.FirstName} {member.MiddleName}");
            PaymentDBContext.IntitalizeDB();
            List<PaymentDBContext> payments = PaymentDBContext.GetPayments();
            foreach (PaymentDBContext payment in payments)
            {
                if (payment.Status.Equals("APPROVED")) {
                    NotificationPannel.Children.Add(new UserControlApproved(fullName, payment.Day, payment.Month, payment.Year));
                }
                else if(payment.Status.Equals("DECLINED")) {
                    NotificationPannel.Children.Add(new UserControlDeclined(fullName, payment.Day, payment.Month, payment.Year));
                }
                
            }
            
        }
    }
}
