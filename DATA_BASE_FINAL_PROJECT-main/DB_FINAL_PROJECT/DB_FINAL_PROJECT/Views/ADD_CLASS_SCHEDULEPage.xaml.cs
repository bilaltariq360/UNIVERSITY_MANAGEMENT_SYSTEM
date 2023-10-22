using CommunityToolkit.WinUI.UI.Controls;
using System.Data;
using DB_FINAL_PROJECT.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Oracle.ManagedDataAccess.Client;
using static DB_FINAL_PROJECT.App;
using static DB_FINAL_PROJECT.Views.VIEW_CLASSESPage;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;

namespace DB_FINAL_PROJECT.Views;

public sealed partial class ADD_CLASS_SCHEDULEPage : Page
{
    OracleConnection con;

    List<string> classes = new List<string>();
    List<string> teachers = new List<string>();

    public ADD_CLASS_SCHEDULEViewModel ViewModel
    {
        get;
    }

    public ADD_CLASS_SCHEDULEPage()
    {
        ViewModel = App.GetService<ADD_CLASS_SCHEDULEViewModel>();
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
            OracleCommand getCls = con.CreateCommand();
            getCls.CommandText = "SELECT c_id FROM CLASS";
            getCls.CommandType = CommandType.Text;
            OracleDataReader ClsDR = getCls.ExecuteReader();

            while (ClsDR.Read())
            {
                    classes.Add(ClsDR.GetString(0).ToString());
            }
            ClsDR.Close();
            con.Close();

            con.Open();
            OracleCommand getTch = con.CreateCommand();
            getTch.CommandText = "SELECT t_id FROM TEACHER";
            getTch.CommandType = CommandType.Text;
            OracleDataReader TchDR = getTch.ExecuteReader();

            while (TchDR.Read())
            {
                teachers.Add(TchDR.GetString(0).ToString());
            }
            TchDR.Close();
            con.Close();
        }
    }

    private void InsertButton_Click(object sender, RoutedEventArgs e)
    {
        var classFound = classes.Contains(cidText.Text.ToString());
        var teacherFound = teachers.Contains(tidText.Text.ToString());

        Error.Title = "Warning! ❌";

        con.Open();
        OracleCommand getRec = con.CreateCommand();
        getRec.CommandText = "SELECT s_no FROM SCHEDULE WHERE s_no = '" + schText.Text.ToString() + "'";
        getRec.CommandType = CommandType.Text;
        OracleDataReader RecDR = getRec.ExecuteReader();
        bool found = false;
        while (RecDR.Read())
        {
            found = true;
        }
        RecDR.Close();
        con.Close();

        if (found)
        {
            Error.Subtitle = "Record of this schedule already exist!";
        }
        else if (schText.Text.Length == 0)
        {
            Error.Subtitle = "Schedule id cannot be NULL!";
        }
        else if (schText.Text.Length > 4)
        {
            Error.Subtitle = "Schedule id has " + (schText.Text.Length - 4).ToString() + " extra character(s)!";
        }
        else if (schText.Text.Length < 4)
        {
            Error.Subtitle = "Schedule requires " + (4 - schText.Text.Length).ToString() + " extra character(s)!";
        }
        else if (cidText.Text.ToString() == "")
        {
            Error.Subtitle = "Class id cannot be NULL!";
        }
        else if (!classFound)
        {
            Error.Subtitle = "Class not found!";
        }
        else if (tidText.Text.ToString() == "")
        {
            Error.Subtitle = "Teacher id cannot be NULL!";
        }
        else if (!teacherFound)
        {
            Error.Subtitle = "Teacher not found!";
        }
        else if (locText.Text.Length == 0)
        {
            Error.Subtitle = "Location cannot be NULL!";
        }
        else if (locText.Text.Length > 20)
        {
            Error.Subtitle = "Location has " + (locText.Text.Length - 20).ToString() + " extra character(s)!";
        }
        else if (locText.Text.Length < 5)
        {
            Error.Subtitle = "Location requires " + (5 - locText.Text.Length).ToString() + " extra character(s)!";
        }
        else if (strText.SelectedTime == null)
        {
            Error.Subtitle = "Start time not selected!";
        }
        else if (endText.SelectedTime == null)
        {
            Error.Subtitle = "End time not selected!";
        }
        else if (dowText.Content.ToString() == "Day of week")
        {
            Error.Subtitle = "Day of week not selected!";
        }
        else
        {
            con.Open();
            OracleCommand insertClassSchedule = con.CreateCommand();
            insertClassSchedule.CommandType = CommandType.Text;
            insertClassSchedule.CommandText = "INSERT INTO CLASS_SCHEDULE VALUES (:sch, :cid, :tid, TO_TIMESTAMP(:startTime, 'HH24:MI:SS'), TO_TIMESTAMP(:endTime, 'HH24:MI:SS'), :location, :dayOfWeek)";

            insertClassSchedule.Parameters.Add(new OracleParameter(":sch", schText.Text));
            insertClassSchedule.Parameters.Add(new OracleParameter(":cid", cidText.Text));
            insertClassSchedule.Parameters.Add(new OracleParameter(":tid", tidText.Text));
            insertClassSchedule.Parameters.Add(new OracleParameter(":startTime", strText.SelectedTime.Value.ToString()));
            insertClassSchedule.Parameters.Add(new OracleParameter(":endTime", endText.SelectedTime.Value.ToString()));
            insertClassSchedule.Parameters.Add(new OracleParameter(":location", locText.Text));
            insertClassSchedule.Parameters.Add(new OracleParameter(":dayOfWeek", dowText.Content.ToString()));

            insertClassSchedule.ExecuteNonQuery();
            con.Close();

            Error.Title = "Successfull! ✔️";
            Error.Subtitle = "New schedule added successfully!";
        }

        Error.IsOpen = true;
        Error.RequestedTheme = ElementTheme.Light;
    }

    private void Cid_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
        {
            var suitableItems = new List<string>();
            var splitText = sender.Text.ToLower().Split(" ");
            foreach (var cat in classes)
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
    }

    private void Monday_Click(object sender, RoutedEventArgs e)
    {
        dowText.Content = "Monday";
    }

    private void Tuesday_Click(object sender, RoutedEventArgs e)
    {
        dowText.Content = "Tuesday";
    }

    private void Wednesday_Click(object sender, RoutedEventArgs e)
    {
        dowText.Content = "Wednesday";
    }

    private void Thursday_Click(object sender, RoutedEventArgs e)
    {
        dowText.Content = "Thursday";
    }

    private void Friday_Click(object sender, RoutedEventArgs e)
    {
        dowText.Content = "Friday";
    }

    private void Saturday_Click(object sender, RoutedEventArgs e)
    {
        dowText.Content = "Saturday";
    }

    private void Sunday_Click(object sender, RoutedEventArgs e)
    {
        dowText.Content = "Sunday";
    }

}
