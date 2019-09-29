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
    /// Interaction logic for UserControlMaterial.xaml
    /// </summary>
    public partial class UserControlMaterial : UserControl
    {
        private int materialId;
        private List<MaterialDBContext> materials;
        public UserControlMaterial()
        {
            InitializeComponent();
            InitializeDataGrid();
        }
        private void InitializeDataGrid()
        {
            MaterialDBContext.IntitalizeDB();
            materials = MaterialDBContext.GetMaterials();
            MaterialDataGrid.Items.Clear();
            foreach (MaterialDBContext material in materials)
            {
                MaterialDataGrid.Items.Add(material);
            }
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateAll() && materialId!=0)
            {
                MaterialDBContext.IntitalizeDB();
                MaterialDBContext.Update(materialId, MaterialName.Text.ToString(), BrandName.Text.ToString(), MaterialType.Text.ToString(), int.Parse(MaterialCost.Text.ToString()), PurchasedDate.Text.ToString());
                InitializeDataGrid();
                ClearAll();
                WindowSuccess success = new WindowSuccess();
                success.SetContent("Material Updated Succefully");
                success.Show();

            }
            else
            {
                WindowError error = new WindowError();
                error.SetContent("Material Is Not Selected");
                error.Show();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (materialId!=0) {
                MaterialDBContext.IntitalizeDB();
                MaterialDBContext.Delete(materialId);
                InitializeDataGrid();
                ClearAll();
                WindowSuccess success = new WindowSuccess();
                success.SetContent("Material Deleted Succefully");
                success.Show();
            }
            else{
                WindowError error = new WindowError();
                error.SetContent("Material Is Not Selected");
                error.Show();
            }           
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateAll())
            {
                MaterialDBContext.IntitalizeDB();
                MaterialDBContext.Inserst(MaterialName.Text.ToString(), BrandName.Text.ToString(), MaterialType.Text.ToString(), int.Parse(MaterialCost.Text), PurchasedDate.Text.ToString());
                InitializeDataGrid();
                ClearAll();
                WindowSuccess success = new WindowSuccess();
                success.SetContent("Material Saved Succefully");
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
                var material = materials
                    .SingleOrDefault(m => m.Id == int.Parse(SearchText.Text.ToString()));
                if (material == null)
                {
                    MaterialDataGrid.Items.Clear();
                }
                else
                {
                    MaterialDataGrid.Items.Clear();
                    MaterialDataGrid.Items.Add(material);
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
                    MaterialDataGrid.Items.Clear();
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
                xlWorkSheet.Cells[1, 2] = "Material Name";
                xlWorkSheet.Cells[1, 3] = "Brand Name";
                xlWorkSheet.Cells[1, 4] = "Material Type";
                xlWorkSheet.Cells[1, 5] = "Material Cost";
                xlWorkSheet.Cells[1, 6] = "Purchased Date";
                for (int i = 0; i <= MaterialDataGrid.Items.Count - 1; i++)
                {
                    xlWorkSheet.Cells[i + 2, 1] = ((MaterialDBContext)MaterialDataGrid.Items[i]).Id;
                    xlWorkSheet.Cells[i + 2, 2] = ((MaterialDBContext)MaterialDataGrid.Items[i]).MaterialName;
                    xlWorkSheet.Cells[i + 2, 3] = ((MaterialDBContext)MaterialDataGrid.Items[i]).BrandName;
                    xlWorkSheet.Cells[i + 2, 4] = ((MaterialDBContext)MaterialDataGrid.Items[i]).MaterialType;
                    xlWorkSheet.Cells[i + 2, 5] = ((MaterialDBContext)MaterialDataGrid.Items[i]).MaterialCost;
                    xlWorkSheet.Cells[i + 2, 6] = ((MaterialDBContext)MaterialDataGrid.Items[i]).PurchasedDate;
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

        private void BrandName_KeyUp(object sender, KeyEventArgs e)
        {
            if (BrandName.Text.ToString().Length < 3)
            {
                BNErr.Text = "Brand Name Must Be Atleast 3 Letters";
                BNErr.Visibility = Visibility.Visible;
            }
            else
            {
                BNErr.Visibility = Visibility.Hidden;
            }
        }

        private void MaterialCost_KeyUp(object sender, KeyEventArgs e)
        {
            try {
                double.Parse(MaterialCost.Text.ToString());
                if (MaterialCost.Text.ToString().Length < 1)
                {
                    MCErr.Text = "Material Cost Can't Be Empty";
                    MCErr.Visibility = Visibility.Visible;
                }
                else {
                    MCErr.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception) {
                MCErr.Text = "Material Cost Must Be Number Only";
                MCErr.Visibility = Visibility.Visible;
            }
        }
        private void PurchasedDate_KeyUp(object sender, KeyEventArgs e)
        {

            if (!validateDate(PurchasedDate.Text.ToString()))
            {
                PDErr.Text = "Invalid Date Format";
                PDErr.Visibility = Visibility.Visible;
            }
            else
            {
                PDErr.Visibility = Visibility.Hidden;
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
            if (MNErr.IsVisible || BNErr.IsVisible || MCErr.IsVisible || PDErr.IsVisible)
            {
                return false;
            } else if (string.IsNullOrEmpty(MaterialName.Text.ToString().Trim()) || string.IsNullOrEmpty(BrandName.Text.ToString().Trim()) || string.IsNullOrEmpty(MaterialCost.Text.ToString().Trim()) || string.IsNullOrEmpty(PurchasedDate.Text.ToString().Trim()) ) {
                return false;
            }
            return true;
        }

        private void MemberDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MaterialDBContext material = ((MaterialDBContext)MaterialDataGrid.SelectedItem);
            if (material != null)
            {
                materialId = material.Id;
                MaterialName.Text = material.MaterialName;
                BrandName.Text = material.BrandName;
                MaterialType.Text = material.MaterialType;
                MaterialCost.Text = material.MaterialCost.ToString();
                PurchasedDate.Text = material.PurchasedDate;
            }
        }
        public void ClearAll() {

            materialId =0;
            MaterialName.Text = "";
            BrandName.Text = "";
            MaterialCost.Text = "";
            PurchasedDate.Text = "";
        }

        private void PurchasedDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            PDErr.Visibility = Visibility.Hidden;
        }
    }
}
