using Microsoft.Win32;
using SmartEdir.DBContext;
using SmartEdir.DialogBoxs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
using Excel = Microsoft.Office.Interop.Excel;
namespace SmartEdir.AdminUserControl
{
    /// <summary>
    /// Interaction logic for UserControlMaintenance.xaml
    /// </summary>
    public partial class UserControlMaintenance : UserControl
    {
        private int maintenenceId;
        List<MaintenanceDBContext> maintenences;
        public UserControlMaintenance()
        {
            InitializeComponent();
            InitializeDataGrid();
        }
        private void InitializeDataGrid()
        {
            MaintenanceDBContext.IntitalizeDB();
            maintenences = MaintenanceDBContext.GetMaintenances();
            MaintenanceDataGrid.Items.Clear();
            foreach (MaintenanceDBContext maintenence in maintenences)
            {
                MaintenanceDataGrid.Items.Add(maintenence);
            }
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateAll() && maintenenceId!=0)
            {
                MaintenanceDBContext.IntitalizeDB();
                MaintenanceDBContext.Update(maintenenceId,int.Parse(MaterialId.Text.ToString()), MaterialName.Text.ToString(), MaterialType.Text.ToString(), int.Parse(MaintenanceCost.Text.ToString()), MaintenanceDate.Text.ToString());
                InitializeDataGrid();
                ClearAll();
                WindowSuccess success = new WindowSuccess();
                success.SetContent("Maintenance Updated Succefully");
                success.Show();

            }
            else
            {
                WindowError error = new WindowError();
                error.SetContent("Maintenance Is Not Selected");
                error.Show();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (maintenenceId!=0) {
                MaintenanceDBContext.IntitalizeDB();
                MaintenanceDBContext.Delete(maintenenceId);
                InitializeDataGrid();
                ClearAll();
                WindowSuccess success = new WindowSuccess();
                success.SetContent("Maintenance Deleted Succefully");
                success.Show();
            }
            else {
                WindowError error = new WindowError();
                error.SetContent("Maintenance Is Not Selected");
                error.Show();
            }
            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateAll())
            {
                MaintenanceDBContext.IntitalizeDB();
                MaintenanceDBContext.Inserst(int.Parse(MaterialId.Text.ToString()),MaterialName.Text.ToString(), MaterialType.Text.ToString(), int.Parse(MaintenanceCost.Text), MaintenanceDate.Text.ToString());
                InitializeDataGrid();
                ClearAll();
                WindowSuccess success = new WindowSuccess();
                success.SetContent("Maintenance Saved Succefully");
                success.Show();
            }
            else
            {
                WindowError error = new WindowError();
                error.SetContent("Empty Filed Or Invalid Input");
                error.Show();
            }
        }

        private void SearchText_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var maintenenace = maintenences
                    .SingleOrDefault(m => m.Id == int.Parse(SearchText.Text.ToString()));
                if (maintenenace == null)
                {
                    MaintenanceDataGrid.Items.Clear();
                }
                else
                {
                    MaintenanceDataGrid.Items.Clear();
                    MaintenanceDataGrid.Items.Add(maintenenace);
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
                    MaintenanceDataGrid.Items.Clear();
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
            if (saveFileDialog.ShowDialog() == true)
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Cells[1, 1] = "Id";
                xlWorkSheet.Cells[1, 2] = "Material Id";
                xlWorkSheet.Cells[1, 3] = "Material Name";
                xlWorkSheet.Cells[1, 4] = "Material Type";
                xlWorkSheet.Cells[1, 5] = "Maintenance Cost";
                xlWorkSheet.Cells[1, 6] = "Maintenance Date";
                for (int i = 0; i <= MaintenanceDataGrid.Items.Count - 1; i++)
                {
                    xlWorkSheet.Cells[i + 2, 1] = ((MaintenanceDBContext)MaintenanceDataGrid.Items[i]).Id;
                    xlWorkSheet.Cells[i + 2, 2] = ((MaintenanceDBContext)MaintenanceDataGrid.Items[i]).MaterialId;
                    xlWorkSheet.Cells[i + 2, 3] = ((MaintenanceDBContext)MaintenanceDataGrid.Items[i]).MaterialName;
                    xlWorkSheet.Cells[i + 2, 4] = ((MaintenanceDBContext)MaintenanceDataGrid.Items[i]).MaterialType;
                    xlWorkSheet.Cells[i + 2, 5] = ((MaintenanceDBContext)MaintenanceDataGrid.Items[i]).MaintenanceCost;
                    xlWorkSheet.Cells[i + 2, 6] = ((MaintenanceDBContext)MaintenanceDataGrid.Items[i]).MaintenanceDate;
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


        private void MaterialId_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int.Parse(MaterialId.Text.ToString());
                if (MaterialId.Text.ToString().Length < 1)
                {
                    MIDErr.Text = "Material Id Can't Be Empty";
                    MIDErr.Visibility = Visibility.Visible;
                }
                else
                {
                    MIDErr.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception)
            {
                MIDErr.Text = "Material Id Must Be Number Only";
                MIDErr.Visibility = Visibility.Visible;
            }
        }

        private void MaterialName_KeyUp(object sender, KeyEventArgs e)
        {
            if (!ValidateName(MaterialName.Text.ToString()))
            {
                MNErr.Text = "Material Name Can Only Be Letters";
                MNErr.Visibility = Visibility.Visible;

            }
            else if (MaterialName.Text.ToString().Length < 3)
            {
                MNErr.Text = "Material Name Must Be Atleast 3 Letters";
                MNErr.Visibility = Visibility.Visible;
            }
            else
            {
                MNErr.Visibility = Visibility.Hidden;
            }
        }

        private void MaintenanceCost_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double.Parse(MaintenanceCost.Text.ToString());
                if (MaintenanceCost.Text.ToString().Length < 1)
                {
                    MCErr.Text = "Material Cost Can't Be Empty";
                    MCErr.Visibility = Visibility.Visible;
                }
                else
                {
                    MCErr.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception)
            {
                MCErr.Text = "Material Cost Must Be Number Only";
                MCErr.Visibility = Visibility.Visible;
            }
        }
        private void MaintenanceDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (!validateDate(MaintenanceDate.Text.ToString()))
            {
                MDErr.Text = "Invalid Date Format";
                MDErr.Visibility = Visibility.Visible;
            }
            else
            {
                MDErr.Visibility = Visibility.Hidden;
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
        public bool ValidateName(string name)
        {
            if (Regex.IsMatch(name, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                return true;
            }
            return false;
        }
        public bool ValidateAll()
        {
            if (MIDErr.IsVisible || MNErr.IsVisible || MCErr.IsVisible || MDErr.IsVisible)
            {
                return false;
            } else if (string.IsNullOrEmpty(MaterialName.Text.ToString().Trim()) || string.IsNullOrEmpty(MaterialId.Text.ToString().Trim()) || string.IsNullOrEmpty(MaintenanceCost.Text.ToString().Trim()) || string.IsNullOrEmpty(MaintenanceDate.Text.ToString().Trim())) {
                return false;
            }
            return true;
        }

        private void MaintenanceDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MaintenanceDBContext maintenance = ((MaintenanceDBContext)MaintenanceDataGrid.SelectedItem);
            if (maintenance != null)
            {

                maintenenceId = maintenance.Id;
                MaterialId.Text = maintenance.MaterialId.ToString();
                MaterialName.Text = maintenance.MaterialName;
                MaterialType.Text = maintenance.MaterialType;
                MaintenanceCost.Text = maintenance.MaintenanceCost.ToString();
                MaintenanceDate.Text = maintenance.MaintenanceDate;
            }
        }
        public void ClearAll() {
            maintenenceId = 0;
            MaterialId.Text = "";
            MaterialName.Text = "";
            MaintenanceCost.Text = "";
            MaintenanceDate.Text = "";
        }

        private void MaintenanceDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            MDErr.Visibility = Visibility.Hidden;
        }
    }
}
