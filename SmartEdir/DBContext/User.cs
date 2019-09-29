using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SmartEdir.DBContext
{
    class User
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public BitmapImage Image { get; set; }
        public string New { get; set; }

        public User(string email, string name, BitmapImage image,string newM)
        {
            Email = email;
            Name = name;
            Image = image;
            New = newM;
        }
    }
}
