using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SalaryCalculate
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        List<Salary> list = new List<Salary>();

        private void Reset(object sender, RoutedEventArgs e)
        {
            Reset();
            bemployeeid.Text = "";
            bName.Text = "";
            bDesignation.Text = "";
            bPreviouscompany.Text = "";
            bprevioussalary.Text = "";
            bexpectedsalary.Text = "";
            List1.Items.Clear();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Salary s = new Salary();
            s.EmployeeID = employeeId.Text.Trim();
            s.Name = name.Text.Trim();
            s.Designation = designation.Text.Trim();
            s.PreviousCompanyName = previousCompanyName.Text.Trim();
            s.PreviousSalary = previousSalary.Text.Trim();
            s.ExpectedSalary = expectedSalary.Text.Trim();
            list.Add(s);
            List1.Items.Add("          Employee ID No:  " + employeeId.Text + "\n          Employee Name:  " + name.Text + "\n          Designation:  " + designation.Text
                 + "\n          Previous Company Name:  " + previousCompanyName.Text +
                 "\n          Previous Salary:  " + previousSalary.Text + "\n          Expected Salary:  " + expectedSalary.Text);
            List1.Items.Add("---------------------------------------------");
            var status = new MessageDialog("Saved successfully!");
            status.ShowAsync();


            Reset();
        }
        private void Reset()
        {
            employeeId.Text = string.Empty;
            name.Text = string.Empty;
            designation.Text = string.Empty;
            previousCompanyName.Text = string.Empty;
            previousSalary.Text = string.Empty;
            expectedSalary.Text = string.Empty;
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            string Ename = name.Text;
            if (String.IsNullOrEmpty(Ename))
            {
                var dialog = new MessageDialog(" Input a Name to search");
                dialog.ShowAsync();
            }
            else
            {
                var result = list.Where(s => s.Name == Ename).FirstOrDefault();
                if (result == null)
                {
                    var dialog = new MessageDialog("Name not found.");
                    dialog.ShowAsync();
                }
                else
                {
                    bemployeeid.Text = "Employee ID No:   " + result.EmployeeID;
                    bName.Text = "Employee Name:   " + result.Name;
                    bDesignation.Text = "Designation:   " + result.Designation;
                    bPreviouscompany.Text = "Previous Company Name:   " + result.PreviousCompanyName;
                    bprevioussalary.Text = "Previous Salary:   " + result.PreviousSalary;
                    bexpectedsalary.Text = "Expected Salary:   " + result.ExpectedSalary;

                }
            }
        }


        public class Salary
        {
            public string EmployeeID { get; set; }
            public string Name { get; set; }
            public string Designation { get; set; }
            public string PreviousCompanyName { get; set; }
            public string PreviousSalary { get; set; }
            public string ExpectedSalary { get; set; }
        }
    }
}
