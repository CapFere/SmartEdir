using SmartEdir.ChatUserControl;
using SmartEdir.DBContext;
using SmartEdir.DialogBoxs;
using SmartEdir.MemberUserControl;
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
    /// Interaction logic for WindowMember.xaml
    /// </summary>
    public partial class WindowMember : Window
    {
        public WindowMember()
        {
            InitializeComponent();
            SetProfileImag();
            checkNewNotification();
            GridMember.Children.Clear();
            GridMember.Children.Add(new UserControlPayment());
            
        }

        private void checkNewNotification()
        {
            try
            {
                int counter = 0;
                StreamReader sr = new StreamReader(@"C:\Users\Public\loginfo.txt");
                string email = sr.ReadLine();
                sr.Close();
                UserDBContext.IntitalizeDB();
                UserDBContext user = UserDBContext.GetUser(email);
                PaymentDBContext.IntitalizeDB();
                List<PaymentDBContext> payments = PaymentDBContext.GetPayments();
                foreach (PaymentDBContext payment in payments)
                {
                    if (payment.MemberId == user.MemberID && payment.Seen.Equals("NO") && !payment.Status.Equals("NEW"))
                    {
                        counter++;
                    }
                }
                if (counter != 0)
                {
                    NewNotification.Badge = counter.ToString();
                }
                else {
                    NewNotification.Badge = "";
                }
                
            }
            catch (Exception) {

            }
        }

        private void SetProfileImag()
        {
            try
            {
                UserDBContext.IntitalizeDB();
                List<UserDBContext> users = UserDBContext.GetUsers();
                StreamReader sr = new StreamReader(@"C:\Users\Public\loginfo.txt");
                string email = sr.ReadLine();
                foreach (UserDBContext user in users)
                {
                    if (user.Email.Equals(email.Trim()))
                    {
                        byte[] blob = user.Image;

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
                        ProfileImage.ImageSource = bi;
                    }
                }
            }
            catch (Exception) { }
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            WindowConfirmation confirmation = new WindowConfirmation();
            confirmation.Show();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
            CI.Foreground = Brushes.White;
            MI.Foreground = Brushes.White;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            CI.Foreground = Brushes.Gray;
            MI.Foreground = Brushes.Gray;
        }


        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);
            switch (index)
            {
                case 0:
                    GridMember.Children.Clear();
                    GridMember.Children.Add(new UserControlPayment());
                    break;
                case 1:
                    GridMember.Children.Clear();
                    GridMember.Children.Add(new UserControlEvent());
                    break;
                case 2:
                    GridMember.Children.Clear();
                    GridMember.Children.Add(new MemberUserControl.UserControlFacility());
                    break;
                case 3:
                    GridMember.Children.Clear();
                    GridMember.Children.Add(new UserControlChat());
                    break;
                default:
                    break;
            }

        }
        private void MoveCursorMenu(int index)
        {
            switch (index)
            {
                case 0:
                    CollapseOthers(index);
                    TransitioningContentSlidePayment.OnApplyTemplate();
                    GridCursourPayment.Visibility = Visibility.Visible;
                    break;
                case 1:
                    CollapseOthers(index);
                    TransitioningContentSlideEvent.OnApplyTemplate();
                    GridCursourEvent.Visibility = Visibility.Visible;
                   
                    break;
                case 2:
                    CollapseOthers(index);
                    TransitioningContentSlidefacility.OnApplyTemplate();
                    GridCursourFacility.Visibility = Visibility.Visible;
                    break;
                case 3:
                    CollapseOthers(index);
                    TransitioningContentSlidecaht.OnApplyTemplate();
                    GridCursourChat.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }

        private void CollapseOthers(int index)
        {
            GridCursourEvent.Visibility = Visibility.Collapsed;
            GridCursourPayment.Visibility = Visibility.Collapsed;
            GridCursourFacility.Visibility = Visibility.Collapsed;
            GridCursourChat.Visibility = Visibility.Collapsed;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(@"C:\Users\Public\loginfo.txt", "");
            this.Hide();
            new MainWindow().Show();

        }

        private void Notification_Click(object sender, RoutedEventArgs e)
        {
            CollapseOthers(2);
            GridMember.Children.Clear();
            GridMember.Children.Add(new UserControlNotification());
            try
            {
                StreamReader sr = new StreamReader(@"C:\Users\Public\loginfo.txt");
                string email = sr.ReadLine();
                sr.Close();
                UserDBContext.IntitalizeDB();
                UserDBContext user = UserDBContext.GetUser(email);
                PaymentDBContext.IntitalizeDB();
                List<PaymentDBContext> payments = PaymentDBContext.GetPayments();
                foreach (PaymentDBContext payment in payments)
                {
                    if (payment.MemberId == user.MemberID && payment.Seen.Equals("NO") && !payment.Status.Equals("NEW"))
                    {
                        PaymentDBContext.IntitalizeDB();
                        PaymentDBContext.Update(payment.ReceiptNumber);
                    }
                }
                NewNotification.Badge = "";
            }
            catch (Exception)
            {

            }
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {

            StreamReader sr = new StreamReader(@"C:\Users\Public\loginfo.txt");
            string email = sr.ReadLine().Trim();
            sr.Close();
            UserDBContext.IntitalizeDB();
            UserDBContext currentUser = UserDBContext.GetUser(email);
            MemberDBContext.IntitalizeDB();
            MemberDBContext member = MemberDBContext.GetMember(currentUser.MemberID);
            string fullName = string.Format($"{member.FirstName} {member.MiddleName}");
            CollapseOthers(0);
            GridMember.Children.Clear();
            GridMember.Children.Add(new UserControlProfile(fullName, email, currentUser.Image));
        }
    }
}
