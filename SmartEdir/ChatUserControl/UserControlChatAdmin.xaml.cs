using MaterialDesignThemes.Wpf;
using SmartEdir.AdminUserControl;
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
using System.Windows.Threading;

namespace SmartEdir.ChatUserControl
{
    /// <summary>
    /// Interaction logic for UserControlChatAdmin.xaml
    /// </summary>
    public partial class UserControlChatAdmin : UserControl
    {
        public DispatcherTimer dispatcherTimer;
        List<UserDBContext> users;
        private bool isSelected = false;
        private bool profileIsClicked = false;
        public UserControlChatAdmin()
        {
            InitializeComponent();
            InitializeListView();
        }
        private void InitializeListView(int index = -1)
        {
            ListViewMenu.Items.Clear();
            StreamReader sr = new StreamReader(@"C:\Users\Public\loginfo.txt");
            string email = sr.ReadLine().Trim();
            sr.Close();
            UserDBContext.IntitalizeDB();
            users = UserDBContext.GetUsers();
            foreach (UserDBContext user in users)
            {
                if (user.Email.Equals(email))
                {
                    continue;
                }
                int newChat = 0;
                string newChatString = "";
                ChatDBContext.IntitalizeDB();
                List<ChatDBContext> chats = ChatDBContext.GetChats();
                foreach (ChatDBContext chat in chats)
                {
                    if (chat.Sender.Equals(user.Email) && chat.Receiver.Equals(email) && chat.Seen.Equals("NO"))
                    {
                        newChat++;
                    }

                }
                if (newChat > 0)
                {
                    newChatString = newChat.ToString();
                }
                MemberDBContext.IntitalizeDB();
                MemberDBContext member = MemberDBContext.GetMember(user.MemberID);
                string fullName = string.Format($"{member.FirstName} {member.MiddleName}");
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
                ListViewMenu.Items.Add(new User(user.Email, fullName, bi,newChatString));
                newChatString = "";
            }
            if (index != -1) {
                ListViewMenu.SelectedIndex = index;
            }            
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User user = (User)ListViewMenu.SelectedItem;
            if (user != null && !profileIsClicked)
            {
                isSelected = true;
                IntitializeConversation();
            } else if (user != null && profileIsClicked) {
                profileIsClicked = false;
                UserDBContext.IntitalizeDB();
                UserDBContext currentUser = UserDBContext.GetUser(user.Email);
                MemberDBContext.IntitalizeDB();
                MemberDBContext member = MemberDBContext.GetMember(currentUser.MemberID);
                string fullName = string.Format($"{member.FirstName} {member.MiddleName}");
                WindowProfile profile = new WindowProfile(fullName,user.Email,currentUser.Image);
                profile.Topmost = true;
                profile.Show();
            }
        }

        private void Send_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            string message = Message.Text.ToString();
            if (!string.IsNullOrEmpty(message) && isSelected)
            {
                User user = (User)ListViewMenu.SelectedItem;
                StreamReader sr = new StreamReader(@"C:\Users\Public\loginfo.txt");
                string email = sr.ReadLine().Trim();
                sr.Close();
                ChatDBContext.IntitalizeDB();
                ChatDBContext.Inserst(email, user.Email, message);
                Message.Text = "";
                IntitializeConversation();
            }
        }

        private void IntitializeConversation()
        {

            User user = (User)ListViewMenu.SelectedItem;
            StackPannelMain.Children.Clear();
            StreamReader sr = new StreamReader(@"C:\Users\Public\loginfo.txt");
            string email = sr.ReadLine().Trim();
            sr.Close();
            ChatDBContext.IntitalizeDB();
            List<ChatDBContext> chats = ChatDBContext.GetChats();
            foreach (ChatDBContext chat in chats)
            {
                if (chat.Sender.Equals(email) && chat.Receiver.Equals(user.Email))
                {
                    StackPannelMain.Children.Add(new UserControlMessageBubble("R", chat.Message));
                }
                else if (chat.Sender.Equals(user.Email) && chat.Receiver.Equals(email))
                {
                    StackPannelMain.Children.Add(new UserControlMessageBubble("L", chat.Message));
                    ChatDBContext.IntitalizeDB();
                    ChatDBContext.Update(user.Email, email);
                }
            }
        }       
        private void SearchText_KeyUp(object sender, KeyEventArgs e)
        {
            isSelected = false;
            StackPannelMain.Children.Clear();
            StackPannelMain.Children.Add(new UserControlPlaceHolder());
            string searchText = SearchText.Text.ToString();
            if (string.IsNullOrEmpty(searchText))
            {
                InitializeListView();
            }
            ListViewMenu.Items.Clear();
            StreamReader sr = new StreamReader(@"C:\Users\Public\loginfo.txt");
            string email = sr.ReadLine().Trim();
            sr.Close();
            foreach (UserDBContext user in users)
            {

                MemberDBContext.IntitalizeDB();
                MemberDBContext memberr = MemberDBContext.GetMember(user.MemberID);
                if (memberr.FirstName.Contains(searchText))
                {
                    if (user.Email.Equals(email))
                    {

                        continue;
                    }
                    int newChat = 0;
                    string newChatString = "";
                    ChatDBContext.IntitalizeDB();
                    List<ChatDBContext> chats = ChatDBContext.GetChats();
                    foreach (ChatDBContext chat in chats)
                    {
                        if (chat.Sender.Equals(user.Email) && chat.Receiver.Equals(email) && chat.Seen.Equals("NO"))
                        {
                            newChat++;
                        }

                    }
                    if (newChat > 0)
                    {
                        newChatString = string.Format($"You Have {newChat} New Messages");
                    }

                    MemberDBContext.IntitalizeDB();
                    MemberDBContext member = MemberDBContext.GetMember(user.MemberID);
                    string fullName = string.Format($"{member.FirstName} {member.MiddleName}");
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
                    ListViewMenu.Items.Add(new User(user.Email, fullName, bi, newChatString));
                    newChatString = "";
                }
            }
        }

        private void ProfileImageButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            profileIsClicked = true;
        }
    }
}
