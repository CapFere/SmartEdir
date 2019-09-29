using SmartEdir.AdminUserControl;
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

namespace SmartEdir.DialogBoxs
{
    /// <summary>
    /// Interaction logic for UserControlFacility.xaml
    /// </summary>
    public partial class UserControlFacility : UserControl
    {
        public UserControlFacility()
        {
            InitializeComponent();
            InitializeFacility();
        }
        private void InitializeFacility()
        {
            RequestDBContext.IntitalizeDB();
            List<RequestDBContext> requests = RequestDBContext.GetRequests();
            foreach (RequestDBContext request in requests)
            {
                MemberDBContext.IntitalizeDB();
                MemberDBContext member = MemberDBContext.GetMember(request.MemberId);
                string fullName = string.Format($"{member.FirstName} {member.MiddleName}");
                FacilityPannel.Children.Add(new UserControlSingleFacility(fullName,request.PhoneNumber,request.Date,request.Subject,request.Body));
            }
        }
    }
}
