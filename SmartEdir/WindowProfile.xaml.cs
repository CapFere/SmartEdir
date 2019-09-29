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

namespace SmartEdir
{
    /// <summary>
    /// Interaction logic for WindowProfile.xaml
    /// </summary>
    public partial class WindowProfile : Window
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
        public WindowProfile(string fullName, string email, byte[] image)
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

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
