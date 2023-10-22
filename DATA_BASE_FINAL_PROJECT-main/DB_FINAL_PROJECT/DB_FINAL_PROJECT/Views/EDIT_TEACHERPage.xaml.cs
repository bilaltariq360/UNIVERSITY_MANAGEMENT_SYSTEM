using System.Data;
using DB_FINAL_PROJECT.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Oracle.ManagedDataAccess.Client;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static DB_FINAL_PROJECT.App;

namespace DB_FINAL_PROJECT.Views;

public sealed partial class EDIT_TEACHERPage : Page
{
    OracleConnection con;

    List<string> teachers = new List<string>();

    public EDIT_TEACHERViewModel ViewModel
    {
        get;
    }

    public EDIT_TEACHERPage()
    {
        ViewModel = App.GetService<EDIT_TEACHERViewModel>();
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
            OracleCommand getTea = con.CreateCommand();
            getTea.CommandText = "SELECT t_id FROM TEACHER";
            getTea.CommandType = CommandType.Text;
            OracleDataReader TeaDR = getTea.ExecuteReader();

            while (TeaDR.Read())
            {
                teachers.Add(TeaDR.GetString(0).ToString());
            }
            TeaDR.Close();
            con.Close();
        }
    }

    private void Tid_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
        {
            var suitableItems = new List<string>();
            var splitText = sender.Text.ToLower().Split(" ");
            foreach (var cat in teachers)
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
        OracleCommand geteachers = con.CreateCommand();
        geteachers.CommandText = "SELECT address, first_name, last_name, username, email, gender, registeration_date, blood_group, contact_no, t_password FROM TEACHER WHERE t_id = \'" + tidText.Text.ToString() + "\'";
        geteachers.CommandType = CommandType.Text;
        OracleDataReader teacherDR = geteachers.ExecuteReader();
        if (teacherDR.Read())
        {
            addText.Text = teacherDR.GetString(0);
            fnameText.Text = teacherDR.GetString(1);
            lnameText.Text = teacherDR.GetString(2);
            userText.Text = teacherDR.GetString(3);
            emailText.Text = teacherDR.GetString(4);
            genText.Content = teacherDR.GetString(5);
            DateTime.TryParse(teacherDR.GetString(6), out DateTime regDate);
            regText.Date = regDate;
            bgText.Content = teacherDR.GetString(7);
            contactText.Text = teacherDR.GetString(8);
            passText.Text = teacherDR.GetString(9);
        }
        teacherDR.Close();
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
        else if (userText.Text.Length == 0)
        {
            Error.Subtitle = "Username cannot be NULL!";
        }
        else if (userText.Text.Length > 20)
        {
            Error.Subtitle = "Username has " + (userText.Text.Length - 20).ToString() + " extra digit(s)!";
        }
        else if (userText.Text.Length < 4)
        {
            Error.Subtitle = "Username requires at least " + (4 - userText.Text.Length).ToString() + " more digit(s)!";
        }
        else if (emailText.Text.Length == 0)
        {
            Error.Subtitle = "Email cannot be NULL!";
        }
        else if (emailText.Text.Length > 30)
        {
            Error.Subtitle = "Email has " + (emailText.Text.Length - 30).ToString() + " extra digit(s)!";
        }
        else if (emailText.Text.Length < 8)
        {
            Error.Subtitle = "Email requires at least " + (8 - emailText.Text.Length).ToString() + " more digit(s)!";
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
            updateStudent.CommandText = "UPDATE TEACHER SET first_name = :fname, last_name = :lname, contact_no = :contact, email = :email, address = :address, registeration_date = TO_DATE(:registerationDate, 'MM/DD/YYYY'), gender = :gender, username = :username, blood_group = :bloodGroup, t_password = :t_password WHERE t_id = :tid";

            updateStudent.Parameters.Add(new OracleParameter(":fname", fnameText.Text));
            updateStudent.Parameters.Add(new OracleParameter(":lname", lnameText.Text));
            updateStudent.Parameters.Add(new OracleParameter(":contact", contactText.Text));
            updateStudent.Parameters.Add(new OracleParameter(":email", emailText.Text));
            updateStudent.Parameters.Add(new OracleParameter(":address", addText.Text));
            updateStudent.Parameters.Add(new OracleParameter(":registerationDate", regText.SelectedDate.Value.ToString("MM/dd/yyyy")));
            updateStudent.Parameters.Add(new OracleParameter(":gender", genText.Content.ToString()));
            updateStudent.Parameters.Add(new OracleParameter(":username", userText.Text));
            updateStudent.Parameters.Add(new OracleParameter(":bloodGroup", bgText.Content.ToString()));
            updateStudent.Parameters.Add(new OracleParameter(":t_password", passText.Text));
            updateStudent.Parameters.Add(new OracleParameter(":tid", tidText.Text));

            updateStudent.CommandType = CommandType.Text;
            updateStudent.ExecuteNonQuery();
            con.Close();

            if (teachers.Contains(tidText.Text.ToString()))
            {
                Error.Title = "Successfull! ✔️";
                Error.Subtitle = "Teacher record updated successfully!";
            }
            else
            {
                Error.Subtitle = "Teacher id not found!";
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
}
