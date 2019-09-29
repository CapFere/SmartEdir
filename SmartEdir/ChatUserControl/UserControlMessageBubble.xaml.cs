using System;
using System.Collections.Generic;
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

namespace SmartEdir.ChatUserControl
{
    /// <summary>
    /// Interaction logic for UserControlMessageBubble.xaml
    /// </summary>
    public partial class UserControlMessageBubble : UserControl
    {
        private string oriantation;
        private string message;
        public UserControlMessageBubble(string oriantation, string message)
        {
            InitializeComponent();
            this.oriantation = oriantation;
            this.message = message;
            IntializeLayout();
        }

        private void IntializeLayout()
        {
            Message.Text = message;
            if (oriantation.Equals("L")) {
                StackPanelMessage.HorizontalAlignment = HorizontalAlignment.Left;
                RectangleMessage.Fill = new SolidColorBrush(Colors.LightGray);
            }
            
           
        }
    }
}
