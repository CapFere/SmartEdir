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
using Excell = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using SmartEdir.DialogBoxs;
using System.Data;
using System.ComponentModel;
using System.Globalization;
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;
using SautinSoft.Document;
namespace SmartEdir.AdminUserControl
{
    /// <summary>
    /// Interaction logic for UserControlMember.xaml
    /// </summary>
    public partial class UserControlMember : UserControl
    {
        private int memberId=0;
        List<MemberDBContext> members;
        public UserControlMember()
        {
            InitializeComponent();
            InitializeDataGrid();
        }

        private void InitializeDataGrid()
        {
            MemberDBContext.IntitalizeDB();
            members = MemberDBContext.GetMembers();
            MemberDataGrid.Items.Clear();
            foreach (MemberDBContext member in members)
            {
                MemberDataGrid.Items.Add(member);
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateAll() && memberId!=0)
            {
                MemberDBContext.IntitalizeDB();
                MemberDBContext.Update(memberId, FirstName.Text.ToString(), MiddleName.Text.ToString(), LastName.Text.ToString(), BirthDate.Text.ToString(), Gender.Text.ToString(), Occupation.Text.ToString());
                InitializeDataGrid();
                clearAll();
                WindowSuccess success = new WindowSuccess();
                success.SetContent("Member Updated Succefully");
                success.Show();
                
            }
            else
            {
                WindowError error = new WindowError();
                error.SetContent("Member Is Not Selected");
                error.Show();
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (memberId!=0) {
                MemberDBContext.IntitalizeDB();
                MemberDBContext.Delete(memberId);
                InitializeDataGrid();
                clearAll();
                WindowSuccess success = new WindowSuccess();
                success.SetContent("Member Deleted Succefully");
                success.Show();
            }
            else {
                WindowError error = new WindowError();
                error.SetContent("Member Is Not Selected");
                error.Show();
            }
           

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateAll())
            {
                MemberDBContext.IntitalizeDB();
                MemberDBContext.Inserst(FirstName.Text.ToString(),MiddleName.Text.ToString(),LastName.Text.ToString(), BirthDate.Text.ToString(), Gender.Text.ToString(),Occupation.Text.ToString());
                InitializeDataGrid();
                clearAll();
                WindowSuccess success = new WindowSuccess();
                success.SetContent("Member Saved Succefully");
                success.Show();
            }
            else {
                WindowError error = new WindowError();
                error.SetContent("Empty Filed Or Invalid Input");
                error.Show();
            }
        }
        private void SearchText_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var member = members
                    .SingleOrDefault(m => m.Id == int.Parse(SearchText.Text.ToString()));
                if (member == null)
                {
                    MemberDataGrid.Items.Clear();
                }
                else {
                    MemberDataGrid.Items.Clear();
                    MemberDataGrid.Items.Add(member);
                }
            }
            catch (Exception) {
                if (string.IsNullOrEmpty(SearchText.Text.ToString()))
                {
                    InitializeDataGrid();
                }
                else {
                    MemberDataGrid.Items.Clear();
                }
                
            }
           
            
        }
        private void ExportToExell_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.Title = "Export To Excell";
            saveFileDialog.FileName = "";
            saveFileDialog.Filter = "Excel Files|*.xlsx;*.xls;*.xlsm";
            if (saveFileDialog.ShowDialog() == true) {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Cells[1, 1] = "Id";
                xlWorkSheet.Cells[1, 2] = "First Name";
                xlWorkSheet.Cells[1, 3] = "Middle Name";
                xlWorkSheet.Cells[1, 4] = "Last Name";
                xlWorkSheet.Cells[1, 5] = "Birth Date";
                xlWorkSheet.Cells[1, 6] = "Gender";
                xlWorkSheet.Cells[1, 7] = "Occupation";
                for (int i = 0; i <= MemberDataGrid.Items.Count - 1; i++)
                {
                    xlWorkSheet.Cells[i + 2, 1] = ((MemberDBContext)MemberDataGrid.Items[i]).Id;
                    xlWorkSheet.Cells[i + 2, 2] = ((MemberDBContext)MemberDataGrid.Items[i]).FirstName;
                    xlWorkSheet.Cells[i + 2, 3] = ((MemberDBContext)MemberDataGrid.Items[i]).MiddleName;
                    xlWorkSheet.Cells[i + 2, 4] = ((MemberDBContext)MemberDataGrid.Items[i]).LastName;
                    xlWorkSheet.Cells[i + 2, 5] = ((MemberDBContext)MemberDataGrid.Items[i]).BirthDate;
                    xlWorkSheet.Cells[i + 2, 6] = ((MemberDBContext)MemberDataGrid.Items[i]).Gender;
                    xlWorkSheet.Cells[i + 2, 7] = ((MemberDBContext)MemberDataGrid.Items[i]).Occupation;
                }
                string path = saveFileDialog.FileName;
                xlWorkBook.SaveCopyAs(path);
                xlWorkBook.Saved = true;
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                WindowSuccess success = new WindowSuccess();
                success.SetContent("Exported Successully");
                success.Show();
            }           

        }

        private void FirstName_KeyUp(object sender, KeyEventArgs e)
        {
            if (!ValidateName(FirstName.Text.ToString()))
            {
                FNErr.Text = "First Name Can Only Be Letters";
                FNErr.Visibility = Visibility.Visible;
                
            }
            else if (FirstName.Text.ToString().Length < 4) {
                FNErr.Text = "First Name Must Be Atleast 4 Letters";
                FNErr.Visibility = Visibility.Visible;
            }
            else
            {
                FNErr.Visibility = Visibility.Hidden;
            }
        }

        private void MiddleName_KeyUp(object sender, KeyEventArgs e)
        {
            if (!ValidateName(MiddleName.Text.ToString()))
            {
                MNErr.Text = "Middle Name Can Only Be Letters";
                MNErr.Visibility = Visibility.Visible;

            }
            else if (MiddleName.Text.ToString().Length < 4)
            {
                MNErr.Text = "Middle Name Must Be Atleast 4 Letters";
                MNErr.Visibility = Visibility.Visible;
            }
            else
            {
                MNErr.Visibility = Visibility.Hidden;
            }
        }
        private void LastName_KeyUp(object sender, KeyEventArgs e)
        {
            if (!ValidateName(LastName.Text.ToString()))
            {
                LNErr.Text = "Last Name Can Only Be Letters";
                LNErr.Visibility = Visibility.Visible;

            }
            else if (LastName.Text.ToString().Length < 4)
            {
                LNErr.Text = "Last Name Must Be Atleast 4 Letters";
                LNErr.Visibility = Visibility.Visible;
            }
            else
            {
                LNErr.Visibility = Visibility.Hidden;
            }
        }
        private void BirthDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (!validateDate(BirthDate.Text.ToString())) {
                BDErr.Text = "Invalid Date Format";
                BDErr.Visibility = Visibility.Visible;
            }
            else {
                BDErr.Visibility = Visibility.Hidden;
            }
        }
        private void Occupation_KeyUp(object sender, KeyEventArgs e)
        {
            if (Occupation.Text.ToString().Length < 3)
            {
                OErr.Text = "Occupation Must Be Atleast 3 Letters";
                OErr.Visibility = Visibility.Visible;
            }
            else
            {
                OErr.Visibility = Visibility.Hidden;
            }
        }

        public bool ValidateName(string name) {
            if (Regex.IsMatch(name, @"^[\p{L}\p{M}' \.\-]+$")) {
                return true;
            }
            return false;
        }

        public bool validateDate(string date) {
            DateTime dt;

            bool isValid = DateTime.TryParseExact(
                date,
                "MM/dd/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dt);
            return isValid;
           
        }

        public bool ValidateAll() {
            if (FNErr.IsVisible || MNErr.IsVisible || LNErr.IsVisible || BDErr.IsVisible || OErr.IsVisible) {
                return false;
            } else if(string.IsNullOrEmpty(FirstName.Text.ToString().Trim()) || string.IsNullOrEmpty(MiddleName.Text.ToString().Trim()) || string.IsNullOrEmpty(LastName.Text.ToString().Trim()) || string.IsNullOrEmpty(BirthDate.Text.ToString().Trim()) || string.IsNullOrEmpty(Occupation.Text.ToString().Trim())) {
                return false;
            }
            return true;
        }

        public void clearAll() {
            memberId = 0;
            FirstName.Text = "";
            MiddleName.Text = "";
            LastName.Text = "";
            BirthDate.Text = "";
            Occupation.Text = "";
        }
        private void MemberDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            MemberDBContext member = ((MemberDBContext)MemberDataGrid.SelectedItem);
            if (member != null) {
                memberId = member.Id;
                FirstName.Text = member.FirstName;
                MiddleName.Text = member.MiddleName;
                LastName.Text = member.LastName;
                BirthDate.Text = member.BirthDate;
                Gender.Text = member.Gender;
                Occupation.Text = member.Occupation;
            }
             
        }

        private void BirthDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BDErr.Visibility = Visibility.Hidden;
        }

        private void MemberDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            MemberDBContext member = (MemberDBContext)MemberDataGrid.SelectedItem;
            if (member !=null) {
                string filePath = @"certeficate.pdf";
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog.Title = "Generate Certeficate";
                saveFileDialog.FileName = "certeficate.pdf";
                saveFileDialog.Filter = "Pdf Files|*.pdf";
                if (saveFileDialog.ShowDialog() == true) {
                    string fileResult =saveFileDialog.FileName;
                    DocumentCore dc = DocumentCore.Load(filePath);

                    // Find a position to insert text. Before this text: "> in this position".
                    ContentRange cr = dc.Content.Find("Fireayehu Zekarias").FirstOrDefault();

                    // Insert new text.
                    if (cr != null)
                    {
                        // cr.Start.Insert("New text!");
                        string fullName = string.Format($"{member.FirstName} {member.MiddleName}");
                        cr.Replace(fullName);
                    }
                    dc.Save(fileResult);
                    WindowSuccess sucess = new WindowSuccess();
                    sucess.SetContent("Certeficate Generated!!");
                    sucess.Show();
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(fileResult) { UseShellExecute = true });
                }
                
            }
            e.Handled = true;

        }
    }
}
