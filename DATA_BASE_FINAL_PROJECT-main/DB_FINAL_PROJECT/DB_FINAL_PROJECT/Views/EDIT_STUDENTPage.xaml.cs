using CommunityToolkit.WinUI.UI.Controls;
using System.Data;
using DB_FINAL_PROJECT.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Oracle.ManagedDataAccess.Client;
using static DB_FINAL_PROJECT.App;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DB_FINAL_PROJECT.Views;

public sealed partial class EDIT_STUDENTPage : Page
{
    OracleConnection con;

    List<string> students = new List<string>();

    public EDIT_STUDENTViewModel ViewModel
    {
        get;
    }

    public EDIT_STUDENTPage()
    {
        ViewModel = App.GetService<EDIT_STUDENTViewModel>();
        InitializeComponent();

        string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID = F21_9243; PASSWORD = 1234";
        con = new OracleConnection(conStr);

        LoadOnPage();
    }

    private void LoadOnPage()
    {
        if (LoginPortal.LoginAdd)
        {
            Visible1.Visibility = Visibility.Visible;
            con.Open();
            OracleCommand getStd = con.CreateCommand();
            getStd.CommandText = "SELECT s_id FROM STUDENT";
            getStd.CommandType = CommandType.Text;
            OracleDataReader StdDR = getStd.ExecuteReader();

            while (StdDR.Read())
            {
                students.Add(StdDR.GetString(0).ToString());
            }
            StdDR.Close();
            con.Close();
        }
    }

    private void Sid_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
        {
            var suitableItems = new List<string>();
            var splitText = sender.Text.ToLower().Split(" ");
            foreach (var cat in students)
            {
                var found = splitText.All((key) =>
                {
                    return cat.ToLower().Contains(key);
                });
                if (found)
                {
                    suitableItems.Add(cat);
                }
            }
            if (suitableItems.Count == 0)
            {
                suitableItems.Add("No results found ❌");
            }
            sender.ItemsSource = suitableItems;
        }

        con.Open();
        OracleCommand getStudents = con.CreateCommand();
        getStudents.CommandText = "SELECT address, first_name, last_name, fees_paid, gender, contact_no, s_password, reg_date, blood_group FROM STUDENT WHERE s_id = \'" + sidText.Text.ToString() + "\'";
        getStudents.CommandType = CommandType.Text;
        OracleDataReader studentDR = getStudents.ExecuteReader();
        if (studentDR.Read())
        {
            addText.Text = studentDR.GetString(0);
            fnameText.Text = studentDR.GetString(1);
            lnameText.Text = studentDR.GetString(2);
            feeText.Content = studentDR.GetString(3);
            genText.Content = studentDR.GetString(4);
            contactText.Text = studentDR.GetString(5);
            passText.Text = studentDR.GetString(6);
            DateTime.TryParse(studentDR.GetString(7), out DateTime regDate);
            regText.Date = regDate;
            bgText.Content = studentDR.GetString(8);
        }
        studentDR.Close();
        con.Close();
    }
    private void UpdateButton_Click(object sender, RoutedEventArgs e)
    {
        Error.Title = "Warning! ❌";
        if (fnameText.Text.Length == 0)
        {
            Error.Subtitle = "First name cannot be NULL!";
        }
        else if (fnameText.Text.Length > 15)
        {
            Error.Subtitle = "First name has " + (fnameText.Text.Length - 15).ToString() + " extra character(s)!";
        }
        else if (fnameText.Text.Length < 3)
        {
            Error.Subtitle = "First name requires at least " + (3 - fnameText.Text.Length).ToString() + " more character(s)!";
        }
        else if (lnameText.Text.Length == 0)
        {
            Error.Subtitle = "Last Name cannot be NULL!";
        }
        else if (lnameText.Text.Length > 15)
        {
            Error.Subtitle = "Last name has " + (lnameText.Text.Length - 15).ToString() + " extra character(s)!";
        }
        else if (lnameText.Text.Length < 3)
        {
            Error.Subtitle = "Last name requires at least " + (3 - lnameText.Text.Length).ToString() + " more character(s)!";
        }
        else if (contactText.Text.Length == 0)
        {
            Error.Subtitle = "Contact number cannot be NULL!";
        }
        else if (contactText.Text.Length > 11)
        {
            Error.Subtitle = "Contact number has " + (contactText.Text.Length - 11).ToString() + " extra digit(s)!";
        }
        else if (contactText.Text.Length < 11)
        {
            Error.Subtitle = "Contact number requires at least " + (11 - contactText.Text.Length).ToString() + " more digit(s)!";
        }
        else if (addText.Text.Length == 0)
        {
            Error.Subtitle = "Address cannot be NULL!";
        }
        else if (addText.Text.Length > 50)
        {
            Error.Subtitle = "Address has " + (addText.Text.Length - 50).ToString() + " extra characters!";
        }
        else if (addText.Text.Length < 5)
        {
            Error.Subtitle = "Address requires at least " + (5 - addText.Text.Length).ToString() + " more character(s)!";
        }
        else if (passText.Text.Length == 0)
        {
            Error.Subtitle = "Password cannot be NULL!";
        }
        else if (passText.Text.Length > 15)
        {
            Error.Subtitle = "Password has " + (passText.Text.Length - 15).ToString() + " extra character(s)!";
        }
        else if (passText.Text.Length < 6)
        {
            Error.Subtitle = "Password requires at least " + (6 - passText.Text.Length).ToString() + " more character(s)!";
        }
        else
        {
            con.Open();
            OracleCommand updateStudent = con.CreateCommand();
            updateStudent.CommandText = "UPDATE STUDENT SET first_name = :fname, last_name = :lname, contact_no = :contact, s_password = :password, address = :address, reg_date = TO_DATE(:regDate, 'MM/DD/YYYY'), gender = :gender, fees_paid = :feesPaid, blood_group = :bloodGroup WHERE s_id = :sid";

            updateStudent.Parameters.Add(new OracleParameter(":fname", fnameText.Text));
            updateStudent.Parameters.Add(new OracleParameter(":lname", lnameText.Text));
            updateStudent.Parameters.Add(new OracleParameter(":contact", contactText.Text));
            updateStudent.Parameters.Add(new OracleParameter(":password", passText.Text));
            updateStudent.Parameters.Add(new OracleParameter(":address", addText.Text));
            updateStudent.Parameters.Add(new OracleParameter(":regDate", regText.SelectedDate.Value.ToString("MM/dd/yyyy")));
            updateStudent.Parameters.Add(new OracleParameter(":gender", genText.Content.ToString()));
            updateStudent.Parameters.Add(new OracleParameter(":feesPaid", feeText.Content.ToString()));
            updateStudent.Parameters.Add(new OracleParameter(":bloodGroup", bgText.Content.ToString()));
            updateStudent.Parameters.Add(new OracleParameter(":sid", sidText.Text));

            updateStudent.CommandType = CommandType.Text;
            updateStudent.ExecuteNonQuery();
            con.Close();

            if (students.Contains(sidText.Text.ToString()))
            {
                Error.Title = "Successfull! ✔️";
                Error.Subtitle = "Student record updated successfully!";
            }
            else
            {
                Error.Subtitle = "Student id not found!";
            }
        }

        Error.IsOpen = true;
        Error.RequestedTheme = ElementTheme.Light;
    }

    private void GenderMale_Click(object sender, RoutedEventArgs e)
    {
        genText.Content = "Male";
    }

    private void GenderFemale_Click(object sender, RoutedEventArgs e)
    {
        genText.Content = "Female";
    }

    private void GenderOther_Click(object sender, RoutedEventArgs e)
    {
        genText.Content = "Other";
    }

    private void BGAPositive_Click(object sender, RoutedEventArgs e)
    {
        bgText.Content = "A+";
    }

    private void BGANegative_Click(object sender, RoutedEventArgs e)
    {
        bgText.Content = "A-";
    }

    private void BGBPositive_Click(object sender, RoutedEventArgs e)
    {
        bgText.Content = "B+";
    }

    private void BGBNegative_Click(object sender, RoutedEventArgs e)
    {
        bgText.Content = "B-";
    }

    private void BGABPositive_Click(object sender, RoutedEventArgs e)
    {
        bgText.Content = "AB+";
    }

    private void BGABNegative_Click(object sender, RoutedEventArgs e)
    {
        bgText.Content = "AB-";
    }

    private void BGOBPositive_Click(object sender, RoutedEventArgs e)
    {
        bgText.Content = "O+";
    }

    private void BGOBNegative_Click(object sender, RoutedEventArgs e)
    {
        bgText.Content = "O-";
    }
    private void FeePaid_Click(object sender, RoutedEventArgs e)
    {
        feeText.Content = "Paid";
    }
    private void FeeUnpaid_Click(object sender, RoutedEventArgs e)
    {
        feeText.Content = "Unpaid";
    }
}
