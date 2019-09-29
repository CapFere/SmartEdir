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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartEdir
{
    /// <summary>
    /// Interaction logic for UserControlProfile.xaml
    /// </summary>
    public partial class UserControlProfile : UserControl
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
        public UserControlProfile(string fullName, string email, byte[] image)
        {
            InitializeComponent();
            FullName = fullName;
            Email = email;
            Image = image;
            ImitializeProfile();
        }
        private void ImitializeProfile()
        {
            MemoryStream stream = new MemoryStream();
            stream.Write(Image, 0, Image.Length);
            stream.Write(Image, 0, Image.Length);
            stream.Position = 0;

            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();

            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Seek(0, SeekOrigin.Begin);
            bi.StreamSource = ms;
            bi.EndInit();

            FullNameText.Text = FullName;
            EmailText.Text = Email;
            ProfileImage.ImageSource = bi;
        }

        private void DialogHost_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {

        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            string passwrod = Password.Password.ToString().Trim();
            string confirm = ConfirmPassword.Password.ToString().Trim();
            if (string.IsNullOrEmpty(passwrod))
            {
                Error.Visibility = Visibility.Visible;
                Error.Text = "Password Can't Be Empty";
            }
            else if (passwrod.Length < 4)
            {
                Error.Visibility = Visibility.Visible;
                Error.Text = "Password Must Be At Least 4 letter";
            }
            else if (!passwrod.Equals(confirm)) {
                Error.Visibility = Visibility.Visible;
                Error.Text = "Password Must Match";
            }
            else {
                Error.Visibility = Visibility.Collapsed;
                ResetButton.Command = MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand;
                StreamReader sr = new StreamReader(@"C:\Users\Public\loginfo.txt");
                string email = sr.ReadLine().Trim();
                sr.Close();
                UserDBContext.IntitalizeDB();
                UserDBContext.Update(email, passwrod);
            }
        }
    }
}
