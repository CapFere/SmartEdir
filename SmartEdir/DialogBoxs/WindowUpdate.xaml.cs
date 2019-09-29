using SmartEdir.DBContext;
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

namespace SmartEdir.DialogBoxs
{
    /// <summary>
    /// Interaction logic for WindowUpdate.xaml
    /// </summary>
    public partial class WindowUpdate : Window
    {
        private int previousReciptNumber;
        private int receiptNumber;
        private byte[] imgByteArr;
        private int memberId;
        private string day;
        private string month;
        private int year;
        public WindowUpdate(int previousReciptNumber, int receiptNumber, byte[] imgByteArr, int memberId, string day, string month, int year)
        {
            InitializeComponent();
            this.receiptNumber = receiptNumber;
            this.imgByteArr = imgByteArr;
            this.memberId = memberId;
            this.day = day;
            this.month = month;
            this.year = year;
            this.previousReciptNumber = previousReciptNumber;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            PaymentDBContext.IntitalizeDB();
            PaymentDBContext.Delete(previousReciptNumber);
            PaymentDBContext.IntitalizeDB();
            bool result = PaymentDBContext.Inserst(receiptNumber,imgByteArr,memberId,day,month,year, "NEW");
            if (result)
            {
                WindowSuccess success = new WindowSuccess();
                success.SetContent("Payment Payed Succefully");
                success.Show();
            }
            else {
                WindowError error = new WindowError();
                error.SetContent("Receipt Number Already Exists");
                error.Show();
            }
            this.Hide();
        }
    }
}
