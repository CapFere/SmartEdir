
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            checkIfLoggedIn();
        }

        private void checkIfLoggedIn()
        {
            try
            {
                StreamReader sr = new StreamReader(@"C:\Users\Public\loginfo.txt");
                string email = sr.ReadLine();
                string role = sr.ReadLine();
                sr.Close();
                if (role != null && role.Trim().Equals("Admin"))
                {
                    this.Hide();
                    new WindowAdmin().Show();
                }
                else if (role != null && role.Trim().Equals("Member"))
                {
                    this.Hide();
                    new WindowMember().Show();
                }
            }
            catch (Exception) {}
       
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailText.Text.ToString().Trim();
            string password = PasswordText.Password.ToString().Trim();
            UserDBContext.IntitalizeDB();
            List<UserDBContext> users = UserDBContext.GetUsers();
            int count = 0;
            foreach (UserDBContext user in users)
            {
                if (user.Email.Equals(email))
                {
                    count++;
                    if (user.Password.Equals(password))
                    {
                        try {
                            //SessionDBContext.IntitalizeSqlDB();
                            //SessionDBContext.Inserst(EmailText.Text.ToString(),user.Role);
                            File.WriteAllText(@"C:\Users\Public\loginfo.txt",string.Format("{0} \n {1}",EmailText.Text.ToString(),user.Role));
                        } catch (Exception) { }
                        if (user.Role.Equals("Admin"))
                        {                     
                            this.Hide();
                            new WindowAdmin().Show();
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                            new WindowMember().Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        PasswordErr.Text = "Invalid Passwrod";
                        PasswordErr.Visibility = Visibility.Visible;
                        EmailErr.Visibility = Visibility.Collapsed;
                        break;
                    }
                }
            }

            if (count == 0)
            {
                EmailErr.Text = "This Email Account Doesnot Exist";
                EmailErr.Visibility = Visibility.Visible;
                PasswordErr.Visibility = Visibility.Collapsed;
            }

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
