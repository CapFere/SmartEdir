using Microsoft.Office.Core;
using Microsoft.Win32;
using SmartEdir.DBContext;
using SmartEdir.DialogBoxs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
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

namespace SmartEdir.AdminUserControl
{
    /// <summary>
    /// Interaction logic for UserControlAccount.xaml
    /// </summary>
    public partial class UserControlAccount : UserControl
    {
        private string imageName;
        private byte[] imgByteArrDB;
        private List<UserDBContext> users;
        public UserControlAccount()
        {
            InitializeComponent();
            InitializeDataGrid();
        }
        private void InitializeDataGrid()
        {
            UserDBContext.IntitalizeDB();
            users = UserDBContext.GetUsers();
            AccountDataGrid.Items.Clear();
            foreach (UserDBContext user in users)
            {
                AccountDataGrid.Items.Add(user);
            }
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

            if ((imageName != "" && ValidateAll())|| (imgByteArrDB != null && ValidateAll()))
            {
                foreach (UserDBContext user in users)
                {
                    if (user.Email.Equals(EmailAddress.Text.ToString()))
                    {
                        MemberDBContext.IntitalizeDB();
                        List<MemberDBContext> members = MemberDBContext.GetMembers();
                        var member = members
                            .SingleOrDefault(m => m.Id == int.Parse(MemberId.Text.ToString()));
                        if (member == null)
                        {
                            WindowError error = new WindowError();
                            error.SetContent("Unknown Member Id");
                            error.Show();
                            return;
                        }
                        try {
                            FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);
                            byte[] imgByteArr = new byte[fs.Length];

                            fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));
                            fs.Close();
                            UserDBContext.IntitalizeDB();
                            UserDBContext.Update(EmailAddress.Text.ToString(), Password.Password.ToString(), UserRole.Text.ToString(), imgByteArr, int.Parse(MemberId.Text.ToString()));
                            InitializeDataGrid();
                            ClearAll();
                            WindowSuccess success = new WindowSuccess();
                            success.SetContent("Account Updated Succefully");
                            success.Show();
                        }
                        catch (Exception) {
                            UserDBContext.IntitalizeDB();
                            UserDBContext.Update(EmailAddress.Text.ToString(), Password.Password.ToString(), UserRole.Text.ToString(), imgByteArrDB, int.Parse(MemberId.Text.ToString()));
                            InitializeDataGrid();
                            ClearAll();
                            WindowSuccess success = new WindowSuccess();
                            success.SetContent("Account Updated Succefully");
                            success.Show();
                        }                        
                    }
                }                
            }
            else{
                WindowError error = new WindowError();
                error.SetContent("Empty Filed Or Invalid Input");
                error.Show();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if ((imageName != "" || imgByteArrDB!=null) && IsValidEmail(EmailAddress.Text.ToString()))
            {
                foreach (UserDBContext user in users)
                {
                    if (user.Email.Equals(EmailAddress.Text.ToString())) {
                        UserDBContext.IntitalizeDB();
                        UserDBContext.Delete(EmailAddress.Text.ToString());
                        InitializeDataGrid();
                        ClearAll();
                        WindowSuccess success = new WindowSuccess();
                        success.SetContent("Account Deleted Succefully");
                        success.Show();
                    }
                }                
            }
            else
            {
                WindowError error = new WindowError();
                error.SetContent("Account Is Not Selected");
                error.Show();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MemberDBContext.IntitalizeDB();
            List<MemberDBContext> members = MemberDBContext.GetMembers();
            var member = members
                .SingleOrDefault(m => m.Id == int.Parse(MemberId.Text));
            if (member == null)
            {
                WindowError error = new WindowError();
                error.SetContent("Unknown Member Id");
                error.Show();
                return;
            }
            bool isTrue = false;
            bool already = false;
            try
            {
                if ((imageName != "" && ValidateAll())|| (imgByteArrDB != null && ValidateAll()))
                {
                    foreach (UserDBContext user in users)
                    {
                        if (user.Email.Equals(EmailAddress.Text.ToString()))
                        {
                            isTrue = true;
                        } else if (user.MemberID.Equals(MemberId.Text.ToString())) {
                            already = true;
                        }
                    }
                    if (!isTrue && !already)
                    {

                        FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);
                        byte[] imgByteArr = new byte[fs.Length];

                        fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));
                        fs.Close();

                        UserDBContext.IntitalizeDB();
                        UserDBContext.Inserst(EmailAddress.Text.ToString(), Password.Password.ToString(), UserRole.Text.ToString(), imgByteArr, int.Parse(MemberId.Text));
                        InitializeDataGrid();
                        ClearAll();
                        WindowSuccess success = new WindowSuccess();
                        success.SetContent("Account Created Succefully");
                        success.Show();
                    }
                    else if (already) {
                        WindowError error = new WindowError();
                        error.SetContent("Member Already Has Account");
                        error.Show();
                    }
                    else
                    {
                        WindowError error = new WindowError();
                        error.SetContent("Email Already Exists");
                        error.Show();
                    }
                }                
                else {
                    WindowError error = new WindowError();
                    error.SetContent("Empty Filed Or Invalid Input");
                    error.Show();
                }
            }
            catch (Exception)
            {
                UserDBContext.IntitalizeDB();
                UserDBContext.Inserst(EmailAddress.Text.ToString(), Password.Password.ToString(), UserRole.Text.ToString(), imgByteArrDB, int.Parse(MemberId.Text));
                InitializeDataGrid();
                ClearAll();
                WindowSuccess success = new WindowSuccess();
                success.SetContent("Account Created Succefully");
                success.Show();
            }
        }


        private void SearchText_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                List<UserDBContext> searchUsers = new List<UserDBContext>();
                foreach (UserDBContext user in users)
                {
                    if (user.Email.Contains(SearchText.Text.ToString())) {
                        searchUsers.Add(user);
                    }
                }
                   
                if (searchUsers.Count == 0)
                {
                    AccountDataGrid.Items.Clear();
                }
                else
                {
                    AccountDataGrid.Items.Clear();
                    foreach (UserDBContext user in searchUsers)
                    {
                        AccountDataGrid.Items.Add(user);
                    }
                    
                }
            }
            catch (Exception)
            {
                if (string.IsNullOrEmpty(SearchText.Text.ToString()))
                {
                    InitializeDataGrid();
                }
                else
                {
                    AccountDataGrid.Items.Clear();
                }

            }

        }
        private void EmailAddress_KeyUp(object sender, KeyEventArgs e)
        {
            if (!IsValidEmail(EmailAddress.Text.ToString()))
            {
                EAErr.Text = "Invalid Email Format";
                EAErr.Visibility = Visibility.Visible;
            }
            else {
                EAErr.Visibility = Visibility.Hidden;
            }
        }

        private void Password_KeyUp(object sender, KeyEventArgs e)
        {
            if (Password.Password.ToString().Length < 4) {
                PErr.Text = "Minimum Password Length Is 3";
                PErr.Visibility = Visibility.Visible;
            }
            else {
                PErr.Visibility = Visibility.Hidden;
            }
        }
        private void MemberId_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int.Parse(MemberId.Text.ToString());
                if (MemberId.Text.ToString().Length < 1)
                {
                    MIErr.Text = "Member Id Can't Be Empty";
                    MIErr.Visibility = Visibility.Visible;
                }
                else
                {
                    MIErr.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception)
            {
                MIErr.Text = "Member Id Must Be Number Only";
                MIErr.Visibility = Visibility.Visible;
            }
        }
        public bool IsValidEmail(string email) {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success) {
                return true;
            }
            return false;
        }
        public bool ValidateAll()
        {
            
            if (EAErr.IsVisible || PErr.IsVisible || MIErr.IsVisible || PPErr.IsVisible)
            {
                return false;
            } else if (string.IsNullOrEmpty(EmailAddress.Text.ToString().Trim()) || string.IsNullOrEmpty(Password.Password.ToString().Trim()) || string.IsNullOrEmpty(MemberId.Text.ToString().Trim()) || string.IsNullOrEmpty(imgByteArrDB.ToString())) {
                return false;
            }
            List<MemberDBContext> members = MemberDBContext.GetMembers();
            bool isTrue = true;
            foreach (MemberDBContext member in members)
            {
                if (member.Id == int.Parse(MemberId.Text.ToString()))
                {
                    isTrue = false;
                }
            }
            if (isTrue) {
                WindowError error = new WindowError();
                error.SetContent("Member Id Doesn't Exist");
                error.Show();
                return false;
            }
            return true;
        }
        
        private void AccountDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserDBContext user = ((UserDBContext)AccountDataGrid.SelectedItem);
            if (user != null)
            {
                EmailAddress.Text = user.Email;
                Password.Password = user.Password;
                UserRole.Text = user.Role;
                MemberId.Text = user.MemberID.ToString();
                imgByteArrDB = user.Image;
                byte[] blob = imgByteArrDB;

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

        private void ProfileImageButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                PPErr.Visibility = Visibility.Hidden;
                Microsoft.Win32.FileDialog fileDialog = new OpenFileDialog();
                fileDialog.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fileDialog.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                fileDialog.ShowDialog();
                {
                    imageName = fileDialog.FileName;
                    ImageSourceConverter isc = new ImageSourceConverter();
                    //ProfileImage.SetValue(Image.SourceProperty, isc.ConvertFromString(imageName));
                    ProfileImage.ImageSource = new BitmapImage(new Uri(imageName, UriKind.Relative));
                }
                fileDialog = null;

            }
            catch (Exception)
            {
                PPErr.Text = "Profile Image Is Not Selected";
                PPErr.Visibility = Visibility.Visible;
            }
        }
        public void ClearAll() {
            EmailAddress.Text = "";
            Password.Password = "";
            MemberId.Text = "";
            imageName = "";
        }
    }
}
