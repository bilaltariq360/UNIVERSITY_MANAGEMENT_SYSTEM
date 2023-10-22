using System.Data;
using CommunityToolkit.WinUI.UI.Controls;
using DB_FINAL_PROJECT.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Oracle.ManagedDataAccess.Client;
using static DB_FINAL_PROJECT.App;
using static DB_FINAL_PROJECT.Views.VIEW_CLASSESPage;

namespace DB_FINAL_PROJECT.Views;

public sealed partial class ADD_CLASSPage : Page
{
    OracleConnection con;

    List<string> teachers = new List<string>();

    public ADD_CLASSViewModel ViewModel
    {
        get;
    }

    public ADD_CLASSPage()
    {
        ViewModel = App.GetService<ADD_CLASSViewModel>();
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
            OracleCommand getTeachers = con.CreateCommand();
            getTeachers.CommandText = "SELECT t_id FROM TEACHER";
            getTeachers.CommandType = CommandType.Text;
            OracleDataReader teacherDR = getTeachers.ExecuteReader();
            while (teacherDR.Read())
            {
                teachers.Add(teacherDR.GetString(0));
            }
            teacherDR.Close();
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
    }

    private void InsertButton_Click(object sender, RoutedEventArgs e)
    {
        bool intSem = int.TryParse(semText.Text, out int semester);
        bool intCap = int.TryParse(capText.Text, out int capacity);

        Error.Title = "Warning! ❌";

        con.Open();
        OracleCommand getRec = con.CreateCommand();
        getRec.CommandText = "SELECT c_id FROM CLASS WHERE c_id = '" + cidText.Text.ToString() + "'";
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
            Error.Subtitle = "Record of this class already exist!";
        }
        else if (cidText.Text.Length == 0)
        {
            Error.Subtitle = "Class ID cannot be NULL!";
        }
        else if (cidText.Text.Length > 4)
        {
            Error.Subtitle = "Class id has " + (cidText.Text.Length - 4).ToString() + " extra character(s)!";
        }
        else if (cidText.Text.Length < 4)
        {
            Error.Subtitle = "Class id requires at least " + (4 - cidText.Text.Length).ToString() + " more character(s)!";
        }
        else if (semText.Text.Length == 0)
        {
            Error.Subtitle = "Semester cannot be NULL!";
        }
        else if (intSem && (semester > 8))
        {
            Error.Subtitle = "Semester cannot be greater than 8!";
        }
        else if (intSem && (semester < 1))
        {
            Error.Subtitle = "Semester cannot be lesser than 1!";
        }
        else if (!intSem)
        {
            Error.Subtitle = "Enter numeric value in semester!";
        }
        else if (secText.Text.Length == 0)
        {
            Error.Subtitle = "Section cannot be NULL!";
        }
        else if (secText.Text.Length > 1)
        {
            Error.Subtitle = "Section has " + (secText.Text.Length - 1).ToString() + " extra character(s)!";
        }
        else if (intCap && (capacity > 100))
        {
            Error.Subtitle = "Capacity cannot be greater than 100!";
        }
        else if (intCap && (capacity < 10))
        {
            Error.Subtitle = "Capacity cannot be lesser than 10!";
        }
        else if (!intCap)
        {
            Error.Subtitle = "Enter numeric value in capacity!";
        }
        else if (!teachers.Contains(tidText.Text.ToString()))
        {
            Error.Subtitle = "Teacher id not found!";
        }
        else
        {
            con.Open();
            OracleCommand insertEmp = con.CreateCommand();
            insertEmp.CommandType = CommandType.Text;
            insertEmp.CommandText = "INSERT INTO CLASS VALUES('" +
            cidText.Text.ToString() + "\',\'" +
            tidText.Text.ToString() + "\',\'" +
            secText.Text.ToString() + "\'," +
            semText.Text.ToString() + "," +
            capText.Text.ToString() +
            ")";
            insertEmp.ExecuteNonQuery();
            con.Close();
            Error.Title = "Successfull! ✔️";
            Error.Subtitle = "New student added successfully!";
        }

        Error.IsOpen = true;
        Error.RequestedTheme = ElementTheme.Light;
    }
}
