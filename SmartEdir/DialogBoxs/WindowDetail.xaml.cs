using SmartEdir.DBContext;
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
using System.Windows.Shapes;

namespace SmartEdir.DialogBoxs
{
    /// <summary>
    /// Interaction logic for WindowDetail.xaml
    /// </summary>
    public partial class WindowDetail : Window
    {
        private int memberId;
        private int receiptNumber;
        private byte[] blob;
        private string status;
        public WindowDetail(int memberId, int receiptNumber, byte[] blob,string status)
        {
            InitializeComponent();
            this.memberId = memberId;
            this.receiptNumber = receiptNumber;
            this.blob = blob;
            this.status = status;
            InitializeContent();
        }
        private void InitializeContent() {
            MemberDBContext.IntitalizeDB();
            MemberDBContext member = MemberDBContext.GetMember(memberId);
            FullName.Text = string.Format($"{member.FirstName} {member.MiddleName}");
            ReciptNumber.Text = receiptNumber.ToString();
            MemoryStream stream = new MemoryStream();
            stream.Write(blob, 0, blob.Length);
            stream.Position = 0;

            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();

            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Seek(0, SeekOrigin.Begin);
            bi.StreamSource = ms;
            bi.EndInit();
            Receipt.Source = bi;
            if (status.Equals("APPROVED")) {
                Approve.IsEnabled = false;
            } else if (status.Equals("DECLINED")) {
                Decline.IsEnabled = false;
            }
        }
        private void Approve_Click(object sender, RoutedEventArgs e)
        {
            PaymentDBContext.IntitalizeDB();
            PaymentDBContext.Update(receiptNumber,"APPROVED");
            this.Hide();
        }

        private void Decline_Click(object sender, RoutedEventArgs e)
        {
            PaymentDBContext.IntitalizeDB();
            PaymentDBContext.Update(receiptNumber, "DECLINED");
            this.Hide();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
