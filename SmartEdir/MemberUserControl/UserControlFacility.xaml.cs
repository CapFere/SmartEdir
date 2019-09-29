using SmartEdir.DBContext;
using SmartEdir.DialogBoxs;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for UserControlFacility.xaml
    /// </summary>
    public partial class UserControlFacility : UserControl
    {
        public UserControlFacility()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateAll())
            {
                StreamReader sr = new StreamReader(@"C:\Users\Public\loginfo.txt");
                string email = sr.ReadLine();
                sr.Close();
                UserDBContext.IntitalizeDB();
                UserDBContext user = UserDBContext.GetUser(email);
                RequestDBContext.IntitalizeDB();
                bool result = RequestDBContext.Inserst(user.MemberID, PhoneNumber.Text.ToString(), Date.Text.ToString(), Subject.Text.ToString(), Body.Text.ToString());
                if (result)
                {
                    ClearAll();
                    WindowSuccess success = new WindowSuccess();
                    success.SetContent("Request Submited Succefully");
                    success.Show();
                }
            }
            else {
                WindowError error = new WindowError();
                error.SetContent("Empty Filed Or Invaid Input");
                error.Show();
            }
        }

        private void Body_KeyUp(object sender, KeyEventArgs e)
        {
            if (Body.Text.ToString().Length < 1)
            {
                BErr.Text = "Request Body Can't Be Empty";
                BErr.Visibility = Visibility.Visible;
            }
            else if (Body.Text.ToString().Length >= 300)
            {
                BErr.Text = "Request Body Is Maximum Of 300 Letters";
                BErr.Visibility = Visibility.Visible;
            }
            else
            {
                BErr.Visibility = Visibility.Hidden;
            }
        }

        private void Subject_KeyUp(object sender, KeyEventArgs e)
        {
            if (Subject.Text.ToString().Length < 1)
            {
                SUErr.Text = "Subject Can't Be Empty";
                SUErr.Visibility = Visibility.Visible;
            }
            else if (Subject.Text.ToString().Length >= 40)
            {
                SUErr.Text = "Subject Is Maximum Of 40 Letters";
                SUErr.Visibility = Visibility.Visible;
            }
            else
            {
                SUErr.Visibility = Visibility.Hidden;
            }
        }
        private void Date_KeyUp(object sender, KeyEventArgs e)
        {
            if (!validateDate(Date.Text.ToString()))
            {
                DErr.Text = "Invalid Date Format";
                DErr.Visibility = Visibility.Visible;
            }
            else
            {
                DErr.Visibility = Visibility.Hidden;
            }
        }
        private void PhoneNumber_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                long.Parse(PhoneNumber.Text.ToString());
                if (PhoneNumber.Text.ToString().Length < 1)
                {
                    PNErr.Text = "Phone Number Can't Be Empty";
                    PNErr.Visibility = Visibility.Visible;
                }
                else if (PhoneNumber.Text.ToString().Trim().Length < 10)
                {
                    PNErr.Text = "Phone Number Is Minmum Of 10 Digits";
                    PNErr.Visibility = Visibility.Visible;
                }
                else
                {
                    PNErr.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception)
            {
                PNErr.Text = "Phone Number Must Be Number Only";
                PNErr.Visibility = Visibility.Visible;
            }
        }
        public bool validateDate(string date)
        {
            DateTime dt;

            bool isValid = DateTime.TryParseExact(
                date,
                "MM/dd/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dt);
            return isValid;

        }
        public bool ValidateAll()
        {
            if (PNErr.IsVisible || SUErr.IsVisible || BErr.IsVisible || DErr.IsVisible)
            {
                return false;
            } else if (string.IsNullOrEmpty(PhoneNumber.Text.ToString().Trim()) || string.IsNullOrEmpty(Date.Text.ToString().Trim()) || string.IsNullOrEmpty(Subject.Text.ToString().Trim()) || string.IsNullOrEmpty(Body.Text.ToString().Trim())) {
                return false;
            }
            return true;
        }

        public void ClearAll() {
            PhoneNumber.Text = "";
            Date.Text = "";
            Subject.Text = "";
            Body.Text = "";
        }

        private void Date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DErr.Visibility = Visibility.Hidden;
        }
    }
}
