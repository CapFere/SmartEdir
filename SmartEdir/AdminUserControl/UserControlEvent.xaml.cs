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
    /// Interaction logic for UserControlEvent.xaml
    /// </summary>
    public partial class UserControlEvent : UserControl
    {
        private int eventId;
        private List<EventDBContext> events;
        public UserControlEvent()
        {
            InitializeComponent();
            InitializeDataGrid();
        }
        private void InitializeDataGrid()
        {
            EventDBContext.IntitalizeDB();
            events = EventDBContext.GetEvents();
            EventDataGrid.Items.Clear();
            foreach (EventDBContext eventt in events)
            {
                EventDataGrid.Items.Add(eventt);
            }
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateAll() && eventId!=0)
            {
                EventDBContext.IntitalizeDB();
                EventDBContext.Update(eventId, EventDate.Text.ToString(), EventAdress.Text.ToString(), EventDetail.Text.ToString().Trim());
                InitializeDataGrid();
                ClearAll();
                WindowSuccess success = new WindowSuccess();
                success.SetContent("Event Updated Succefully");
                success.Show();

            }
            else
            {
                WindowError error = new WindowError();
                error.SetContent("Event Is Not Selected");
                error.Show();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (eventId!=0) {
                EventDBContext.IntitalizeDB();
                EventDBContext.Delete(eventId);
                InitializeDataGrid();
                ClearAll();
                WindowSuccess success = new WindowSuccess();
                success.SetContent("Event Deleted Succefully");
                success.Show();
            }
            else {
                WindowError error = new WindowError();
                error.SetContent("Event Is Not Selected");
                error.Show();
            }
           
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateAll())
            {
                EventDBContext.IntitalizeDB();
                EventDBContext.Inserst(EventDate.Text.ToString(), EventAdress.Text.ToString(), EventDetail.Text.ToString().Trim());
                InitializeDataGrid();
                ClearAll();
                WindowSuccess success = new WindowSuccess();
                success.SetContent("Event Saved Succefully");
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
                var eventt = events
                    .SingleOrDefault(m => m.Id == int.Parse(SearchText.Text.ToString()));
                if (eventt == null)
                {
                    EventDataGrid.Items.Clear();
                }
                else
                {
                    EventDataGrid.Items.Clear();
                    EventDataGrid.Items.Add(eventt);
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
                    EventDataGrid.Items.Clear();
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
                xlWorkSheet.Cells[1, 2] = "Event Date";
                xlWorkSheet.Cells[1, 3] = "Event Address";
                xlWorkSheet.Cells[1, 4] = "Event Detail";
                for (int i = 0; i <= EventDataGrid.Items.Count - 1; i++)
                {
                    xlWorkSheet.Cells[i + 2, 1] = ((EventDBContext)EventDataGrid.Items[i]).Id;
                    xlWorkSheet.Cells[i + 2, 2] = ((EventDBContext)EventDataGrid.Items[i]).EventDate;
                    xlWorkSheet.Cells[i + 2, 3] = ((EventDBContext)EventDataGrid.Items[i]).EventAddress;
                    xlWorkSheet.Cells[i + 2, 4] = ((EventDBContext)EventDataGrid.Items[i]).EventDetail;
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

        private void EventAdress_KeyUp(object sender, KeyEventArgs e)
        {
            if (EventAdress.Text.ToString().Length < 1)
            {
                EAErr.Text = "Event Adress Can't Be Empty";
                EAErr.Visibility = Visibility.Visible;
            }
            else
            {
                EAErr.Visibility = Visibility.Hidden;
            }
        }

        private void EventDetail_KeyUp(object sender, KeyEventArgs e)
        {
            if (EventDetail.Text.ToString().Length < 1)
            {
                EVDErr.Text = "Event Detail Can't Be Empty";
                EVDErr.Visibility = Visibility.Visible;
            }
            else if (EventDetail.Text.ToString().Length >= 200)
            {
                EVDErr.Text = "Event Detail Is Maximum Of 200 Letters";
                EVDErr.Visibility = Visibility.Visible;
            }
            else
            {
                EVDErr.Visibility = Visibility.Hidden;
            }
        }

        private void EventDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (!validateDate(EventDate.Text.ToString()))
            {
                EDErr.Text = "Invalid Date Format";
                EDErr.Visibility = Visibility.Visible;
            }
            else
            {
                EDErr.Visibility = Visibility.Hidden;
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
        public bool ValidateAll()
        {
            if (EDErr.IsVisible || EVDErr.IsVisible || EAErr.IsVisible)
            {
                return false;
            } else if (string.IsNullOrEmpty(EventDate.Text.ToString().Trim()) || string.IsNullOrEmpty(EventAdress.Text.ToString().Trim()) || string.IsNullOrEmpty(EventDetail.Text.ToString().Trim())) {
                return false;
            }
            return true;
        }
        private void EventDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EventDBContext eventt = ((EventDBContext)EventDataGrid.SelectedItem);
            if (eventt != null)
            {
                eventId = eventt.Id;
                EventDate.Text = eventt.EventDate;
                EventAdress.Text = eventt.EventAddress;
                EventDetail.Text = eventt.EventDetail;
            }
        }
        public void ClearAll() {
            eventId = 0;
            EventDate.Text = "";
            EventAdress.Text = "";
            EventDetail.Text = "";
        }

        private void EventDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            EDErr.Visibility = Visibility.Hidden;
        }
    }
}
