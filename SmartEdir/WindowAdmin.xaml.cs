using SmartEdir.AdminUserControl;
using SmartEdir.ChatUserControl;
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
using System.Windows.Shapes;

namespace SmartEdir
{
    /// <summary>
    /// Interaction logic for WindowAdmin.xaml
    /// </summary>
    public partial class WindowAdmin : Window
    {
        public WindowAdmin()
        {
            InitializeComponent();
            GridMember.Children.Clear();
            GridMember.Children.Add(new UserControlMember());
            SetProfileImag();
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
                    GridMember.Children.Add(new UserControlMember());
                    break;
                case 1:
                    GridMember.Children.Clear();
                    GridMember.Children.Add(new UserControlMaterial());
                    break;
                case 2:
                    GridMember.Children.Clear();
                    GridMember.Children.Add(new UserControlMaintenance());
                    break;
                case 3:
                    GridMember.Children.Clear();
                    GridMember.Children.Add(new UserControlEvent());
                    break;
                case 4:
                    GridMember.Children.Clear();
                    GridMember.Children.Add(new UserControlPayment());
                    break;
                case 5:
                    GridMember.Children.Clear();
                    GridMember.Children.Add(new UserControlFacility());
                    break;
                case 6:
                    GridMember.Children.Clear();
                    GridMember.Children.Add(new UserControlChatAdmin());
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
                    TransitioningContentSlideMember.OnApplyTemplate();
                    GridCursourMember.Visibility = Visibility.Visible;
                    break;
                case 1:
                    CollapseOthers(index);
                    TransitioningContentSlideMaterial.OnApplyTemplate();
                    GridCursourMaterial.Visibility = Visibility.Visible;
                    break;
                case 2:
                    CollapseOthers(index);
                    TransitioningContentSlideMaintenance.OnApplyTemplate();
                    GridCursourMaintenance.Visibility = Visibility.Visible;
                    break;
                case 3:
                    CollapseOthers(index);
                    TransitioningContentSlideEvent.OnApplyTemplate();
                    GridCursourEvent.Visibility = Visibility.Visible;
                    break;
                case 4:
                    CollapseOthers(index);
                    TransitioningContentSlidePayment.OnApplyTemplate();
                    GridCursourPayment.Visibility = Visibility.Visible;
                    break;
                case 5:
                    CollapseOthers(index);
                    TransitioningContentSlidefacility.OnApplyTemplate();
                    GridCursourFacility.Visibility = Visibility.Visible;
                    break;
                case 6:
                    CollapseOthers(index);
                    TransitioningContentSlidechat.OnApplyTemplate();
                    GridCursourChat.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }

        private void CollapseOthers(int index)
        {
            GridCursourMember.Visibility = Visibility.Collapsed;
            GridCursourMaterial.Visibility = Visibility.Collapsed;
            GridCursourMaintenance.Visibility = Visibility.Collapsed;
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

        private void AddAccountButton_Click(object sender, RoutedEventArgs e)
        {
            CollapseOthers(0);
            GridMember.Children.Clear();
            GridMember.Children.Add(new UserControlAccount());
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
            GridMember.Children.Add(new UserControlProfile(fullName,email,currentUser.Image));
        }
    }
}
