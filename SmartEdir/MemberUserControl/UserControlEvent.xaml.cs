using SmartEdir.DBContext;
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

namespace SmartEdir.MemberUserControl
{
    /// <summary>
    /// Interaction logic for UserControlEvent.xaml
    /// </summary>
    public partial class UserControlEvent : UserControl
    {
        public UserControlEvent()
        {
            InitializeComponent();
            InitializeEvent();
        }
        private void InitializeEvent() {
            EventDBContext.IntitalizeDB();
            List<EventDBContext> events = EventDBContext.GetEvents();
            foreach (EventDBContext eventt in events)
            {
                EventPannel.Children.Add(new UserControlSingleEvent(eventt.EventDate,eventt.EventAddress,eventt.EventDetail));
            }
        }
    }
}
