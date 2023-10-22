using System.Data;
using DB_FINAL_PROJECT.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Oracle.ManagedDataAccess.Client;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static DB_FINAL_PROJECT.App;

namespace DB_FINAL_PROJECT.Views;

public sealed partial class ADD_STUDENT_TO_CLASSPage : Page
{
    OracleConnection con;

    List<string> classes = new List<string>();
    List<string> teachers = new List<string>();

    public ADD_STUDENT_TO_CLASSViewModel ViewModel
    {
        get;
    }

    public ADD_STUDENT_TO_CLASSPage()
    {
        ViewModel = App.GetService<ADD_STUDENT_TO_CLASSViewModel>();
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
            OracleCommand getStd = con.CreateCommand();
            getStd.CommandText = "SELECT s_id FROM STUDENT";
            getStd.CommandType = CommandType.Text;
            OracleDataReader TchDR = getStd.ExecuteReader();

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
        var teacherFound = teachers.Contains(sidText.Text.ToString());

        Error.Title = "Warning! ❌";

        if (cidText.Text.ToString() == "")
        {
            Error.Subtitle = "Class id cannot be NULL!";
        }
        else if (!classFound)
        {
            Error.Subtitle = "Class not found!";
        }
        else if (sidText.Text.ToString() == "")
        {
            Error.Subtitle = "Teacher id cannot be NULL!";
        }
        else if (!teacherFound)
        {
            Error.Subtitle = "Teacher not found!";
        }
        else
        {
            con.Open();
            OracleCommand upStd = con.CreateCommand();
            upStd.CommandText = "UPDATE STUDENT SET c_id = \'" + cidText.Text.ToString() + "\' WHERE s_id = \'" + sidText.Text.ToString() + "\'";
            upStd.CommandType = CommandType.Text;
            upStd.ExecuteNonQuery();
            con.Close();

            Error.Title = "Successfull! ✔️";
            Error.Subtitle = "Section " + cidText.Text.ToString() + " assigned successfully to student " + sidText.Text.ToString() + "!";
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

    private void Sid_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
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
}