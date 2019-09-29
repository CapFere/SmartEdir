using Microsoft.Win32;
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
    /// Interaction logic for UserControlPayment.xaml
    /// </summary>
    public partial class UserControlPayment : UserControl
    {
        private string imageName="";
        public UserControlPayment()
        {
            InitializeComponent();
            fillDayMonthYear();
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            if (imageName == "") {
                RIErr.Text = "Receipt Image Is Not Selected";
                RIErr.Visibility = Visibility.Visible;

            } else if (RNErr.IsVisible || string.IsNullOrEmpty(ReceiptNumber.Text.ToString())) {
                RNErr.Text = "Receipt Number Can't Be Empty";
                RNErr.Visibility = Visibility.Visible;
            }
            else {
                bool isTrue=false;
                bool update = false;
                PaymentDBContext.IntitalizeDB();
                List<PaymentDBContext> payments = PaymentDBContext.GetPayments();
                foreach (PaymentDBContext payment in payments)
                {
                    if (int.Parse(Year.Text.ToString()) == payment.Year && payment.Month.Equals(Month.Text.ToString()) && payment.Status.Equals("APPROVED"))
                    {
                        isTrue = true;
                    }
                    else if(int.Parse(Year.Text.ToString()) == payment.Year && payment.Month.Equals(Month.Text.ToString()))
                    {
                        update = true;
                        FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);
                        byte[] imgByteArr = new byte[fs.Length];
                        fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));
                        fs.Close();
                        StreamReader sr = new StreamReader(@"C:\Users\Public\loginfo.txt");
                        string email = sr.ReadLine();
                        sr.Close();
                        UserDBContext.IntitalizeDB();
                        UserDBContext user = UserDBContext.GetUser(email);
                        WindowUpdate updateWindow = new WindowUpdate(payment.ReceiptNumber,int.Parse(ReceiptNumber.Text.ToString()), imgByteArr, user.MemberID, Day.Text.ToString(), Month.Text.ToString(), int.Parse(Year.Text.ToString()));
                        updateWindow.Show();
                    }
        
                }
                if (!isTrue && !update)
                {
                    FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);
                    byte[] imgByteArr = new byte[fs.Length];

                    fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));
                    fs.Close();
                    StreamReader sr = new StreamReader(@"C:\Users\Public\loginfo.txt");
                    string email = sr.ReadLine();
                    sr.Close();
                    UserDBContext.IntitalizeDB();
                    UserDBContext user = UserDBContext.GetUser(email);
                    PaymentDBContext.IntitalizeDB();
                    bool result = PaymentDBContext.Inserst(int.Parse(ReceiptNumber.Text.ToString()), imgByteArr, user.MemberID, Day.Text.ToString(), Month.Text.ToString(), int.Parse(Year.Text.ToString()), "NEW");
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
                }
                else if(isTrue){
                    WindowError error = new WindowError();
                    error.SetContent("You Already Paid");
                    error.Show();
                }
                
                
            }
        }

        private void fillDayMonthYear() {
            YearDBContext.IntitalizeDB();
            string[] month = {"January","February","March","April","May","June","July","August","September","October","November","December"};
            List<YearDBContext> years = YearDBContext.GetYears();
            foreach (YearDBContext year in years)
            {
                Year.Items.Add(year.Year);
            }
            for (int i = 0; i < month.Length; i++)
            {
                Month.Items.Add(month[i]);
            }
            for (int i = 1; i <= 30; i++)
            {
                Day.Items.Add(i);
            }
        }

        private void ReceiptNumber_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int.Parse(ReceiptNumber.Text.ToString());
                if (ReceiptNumber.Text.ToString().Length < 1)
                {
                    RNErr.Text = "Receipt Number Can't Be Empty";
                    RNErr.Visibility = Visibility.Visible;
                }
                else
                {
                    RNErr.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception)
            {
                RNErr.Text = "Receipt Number Must Be Number Only";
                RNErr.Visibility = Visibility.Visible;
            }
        }
        private void Receipt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RIErr.Visibility = Visibility.Hidden;
                Microsoft.Win32.FileDialog fileDialog = new OpenFileDialog();
                fileDialog.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fileDialog.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                fileDialog.ShowDialog();
                {
                    imageName = fileDialog.FileName;
                    RIErr.Text = fileDialog.SafeFileName;
                    RIErr.Visibility = Visibility.Visible;
                }
                fileDialog = null;

            }
            catch (Exception)
            {
                RIErr.Text = "Receipt Image Is Not Selected";
                RIErr.Visibility = Visibility.Visible;
            }
        }        
    }
}
