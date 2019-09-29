using Microsoft.Win32;
using SmartEdir.DBContext;
using SmartEdir.DialogBoxs;
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
using Excel = Microsoft.Office.Interop.Excel;
namespace SmartEdir.AdminUserControl
{
    /// <summary>
    /// Interaction logic for UserControlPayment.xaml
    /// </summary>
    public partial class UserControlPayment : UserControl
    {
        List<PaymentDBContext> payments;
        public UserControlPayment()
        {
            InitializeComponent();
            InitializeDataGrid();
            fillMonthYear();
        }
        private void InitializeDataGrid()
        {
            PaymentDBContext.IntitalizeDB();
            payments = PaymentDBContext.GetPayments();
            PaymentDataGrid.Items.Clear();
            foreach (PaymentDBContext payment in payments)
            {
                PaymentDataGrid.Items.Add(payment);
            }
        }
        private void fillMonthYear()
        {
            YearDBContext.IntitalizeDB();
            string[] month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            List<YearDBContext> years = YearDBContext.GetYears();
            foreach (YearDBContext year in years)
            {
                YearTotal.Items.Add(year.Year);
            }
            for (int i = 0; i < month.Length; i++)
            {
                MonthTotal.Items.Add(month[i]);
            }            
        }
        private void SearchText_KeyUp(object sender, KeyEventArgs e)
        {
            string searchText = SearchText.Text.ToString().Trim();
            try
            {
                if (searchText.Contains(" ") && count(searchText) == 1)
                {
                    string[] strs = searchText.Split();
                    int id = int.Parse(strs[0]);
                    string month = strs[1];
                    PaymentDataGrid.Items.Clear();
                    foreach (var payment in payments)
                    {
                        if (payment.MemberId == id && payment.Month.Contains(month))
                        {
                            PaymentDataGrid.Items.Add(payment);
                        }
                    }
                } else if (searchText.Contains(" ") && count(searchText) == 2) {
                    string[] strs = searchText.Split();
                    int id = int.Parse(strs[0]);
                    string month = strs[1];
                    int year = int.Parse(strs[2]);
                    PaymentDataGrid.Items.Clear();
                    foreach (var payment in payments)
                    {
                        if (payment.MemberId == id && payment.Month.Contains(month) && payment.Year==year)
                        {
                            PaymentDataGrid.Items.Add(payment);
                        }
                    }
                }
                else {
                    int id = int.Parse(searchText);
                    PaymentDataGrid.Items.Clear();
                    foreach (var payment in payments)
                    {
                        if (payment.MemberId == id) {
                            PaymentDataGrid.Items.Add(payment);
                        }
                    }
                }
            }
            catch (Exception)
            {
                if (string.IsNullOrEmpty(SearchText.Text.ToString()))
                {
                    InitializeDataGrid();
                } else if (!searchText.Contains(" ")) {
                    try
                    {
                        int year = int.Parse(searchText);
                        PaymentDataGrid.Items.Clear();
                        foreach (var payment in payments)
                        {
                            if (payment.Year == year)
                            {
                                PaymentDataGrid.Items.Add(payment);
                            }
                        }
                    }
                    catch(Exception) {
                        PaymentDataGrid.Items.Clear();
                        foreach (var payment in payments)
                        {
                            if (payment.Month.Contains(searchText))
                            {
                                PaymentDataGrid.Items.Add(payment);
                            }
                        }
                    }
                }
                else
                {
                    PaymentDataGrid.Items.Clear();
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
                xlWorkSheet.Cells[1, 1] = "Receipt Number";
                xlWorkSheet.Cells[1, 2] = "Member Id";
                xlWorkSheet.Cells[1, 3] = "Day";
                xlWorkSheet.Cells[1, 4] = "Month";
                xlWorkSheet.Cells[1, 5] = "Year";
                xlWorkSheet.Cells[1, 6] = "Status";
                for (int i = 0; i <= PaymentDataGrid.Items.Count - 1; i++)
                {
                    xlWorkSheet.Cells[i + 2, 1] = ((PaymentDBContext)PaymentDataGrid.Items[i]).ReceiptNumber;
                    xlWorkSheet.Cells[i + 2, 2] = ((PaymentDBContext)PaymentDataGrid.Items[i]).MemberId;
                    xlWorkSheet.Cells[i + 2, 3] = ((PaymentDBContext)PaymentDataGrid.Items[i]).Day;
                    xlWorkSheet.Cells[i + 2, 4] = ((PaymentDBContext)PaymentDataGrid.Items[i]).Month;
                    xlWorkSheet.Cells[i + 2, 5] = ((PaymentDBContext)PaymentDataGrid.Items[i]).Year;
                    xlWorkSheet.Cells[i + 2, 6] = ((PaymentDBContext)PaymentDataGrid.Items[i]).Status;
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
        private int count(string strs) {
            int counter = 0;
            foreach (var str in strs)
            {
                if (str.Equals(" ")) {
                    counter++;
                }
            }
            return counter;
        }
        private void Year_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int.Parse(Year.Text.ToString());
                if (Year.Text.ToString().Length != 4)
                {
                    YErr.Text = "Year Must Be Length Of 4";
                    YErr.Visibility = Visibility.Visible;
                }
                else
                {
                    YErr.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception)
            {
                YErr.Text = "Year Must Be Number Only";
                YErr.Visibility = Visibility.Visible;
            }
        }

        private void Amount_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int.Parse(Amount.Text.ToString());
                if (Amount.Text.ToString().Length <1)
                {
                    AErr.Text = "Amount Can't Be Empty";
                    AErr.Visibility = Visibility.Visible;
                }
                else
                {
                    AErr.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception)
            {
                AErr.Text = "Amount Must Be Number Only";
                AErr.Visibility = Visibility.Visible;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateAll()) {
                YearDBContext.IntitalizeDB();
                bool result = YearDBContext.Inserst(int.Parse(Year.Text.ToString()), double.Parse(Amount.Text.ToString()));
                if (result)
                {
                    WindowSuccess success = new WindowSuccess();
                    success.SetContent("Year Added Successfully");
                    success.Show();
                }
                else {
                    WindowError error = new WindowError();
                    error.SetContent("Year Already Exists");
                    error.Show();
                }
            }
            
        }

        private void PaymentDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PaymentDBContext payment = ((PaymentDBContext)PaymentDataGrid.SelectedItem);
            if (payment != null)
            {
                WindowDetail detail = new WindowDetail(payment.MemberId,payment.ReceiptNumber,payment.Receipt,payment.Status);
                detail.Show();
            }
        }

        private bool ValidateAll() {
            if (YErr.IsVisible || AErr.IsVisible) {
                return false;
            } else if (string.IsNullOrEmpty(Year.Text.ToString().Trim()) || string.IsNullOrEmpty(Amount.Text.ToString().Trim())) {
                return false;
            }
            return true;

        }

        private void YearTotal_SelectionChanged_1(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(YearTotal.Text.ToString()))
            {
                double total = 0;
                YearDBContext.IntitalizeDB();
                List<YearDBContext> years = YearDBContext.GetYears();
                YearDBContext year = years
                    .SingleOrDefault(m => m.Year == int.Parse(YearTotal.Text.ToString()));
                PaymentDBContext.IntitalizeDB();
                foreach (PaymentDBContext payment in payments)
                {
                    if (payment.Year == year.Year)
                    {
                        total += year.Amount;
                    }
                }
                YI.Text = string.Format($"The Total Income is {total} ETB");
                YI.Visibility = Visibility.Visible;
            }
        }

        private void MonthTotal_SelectionChanged_1(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(MonthTotal.Text.ToString()))
            {
                double total = 0;
                YearDBContext.IntitalizeDB();
                List<YearDBContext> years = YearDBContext.GetYears();
                YearDBContext year = years
                    .SingleOrDefault(m => m.Year == int.Parse(YearTotal.Text.ToString()));
                PaymentDBContext.IntitalizeDB();
                foreach (PaymentDBContext payment in payments)
                {
                    if (payment.Year == year.Year && payment.Month.Equals(MonthTotal.Text.ToString()))
                    {
                        total += year.Amount;
                    }
                }
                MI.Text = string.Format($"The Total Income is {total} ETB");
                MI.Visibility = Visibility.Visible;
            }
        }

        private void Refresh_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            InitializeDataGrid();
        }
    }
}
