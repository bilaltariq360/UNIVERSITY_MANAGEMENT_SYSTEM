using DB_FINAL_PROJECT.ViewModels;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Oracle.ManagedDataAccess.Client;
using static DB_FINAL_PROJECT.App;
using System.Data;
using System.Text.RegularExpressions;
using CommunityToolkit.WinUI.UI.Controls;
using System.Drawing.Drawing2D;

namespace DB_FINAL_PROJECT.Views;

public sealed partial class ADD_ATTENDANCEPage : Page
{
    OracleConnection con;

    List<string> students = new List<string>();

    public ADD_ATTENDANCEViewModel ViewModel
    {
        get;
    }

    public ADD_ATTENDANCEPage()
    {
        ViewModel = App.GetService<ADD_ATTENDANCEViewModel>();
        InitializeComponent();

        string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID = F21_9243; PASSWORD = 1234";
        con = new OracleConnection(conStr);

        LoadOnPage();
    }

    private void LoadOnPage()
    {
        if (LoginPortal.LoginTea)
        {
            Visible1.Visibility = Visibility.Visible;
            con.Open();
            OracleCommand getStd = con.CreateCommand();
            getStd.CommandText = "SELECT s.s_id FROM STUDENT s, CLASS c, TEACHER t WHERE s.c_id = c.c_id AND t.t_id ='" + LoginPortal.LoginInfo + "'AND c.t_id = '" + LoginPortal.LoginInfo + "' ORDER BY s.s_id ASC";
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
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        bool intTC = int.TryParse(TCText.Text, out int TC);
        bool intAC = int.TryParse(ACText.Text, out int AC);

        Error.Title = "Warning! ❌";

        con.Open();
        OracleCommand getRec = con.CreateCommand();
        getRec.CommandText = "SELECT a.s_id FROM ATTENDENCE a WHERE a.s_id = '" + sidText.Text.ToString() + "'";
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
            Error.Subtitle = "Record of this student already exist!";
        }
        else if (TCText.Text.Length == 0)
        {
            Error.Subtitle = "Total classes cannot be null";
        }
        else if (!students.Contains(sidText.Text.ToString()))
        {
            Error.Subtitle = "This student is not in your classes";
        }
        else if (!intTC)
        {
            Error.Subtitle = "Enter numeric value in total classes";
        }
        else if (TCText.Text.Length > 30)
        {
            Error.Subtitle = "Total classes has " + (TCText.Text.Length - 30) + " extra character(s)!";
        }
        else if (ACText.Text.Length == 0)
        {
            Error.Subtitle = "Total attented classes cannot be null";
        }
        else if (!intAC)
        {
            Error.Subtitle = "Enter numeric value in attended classes";
        }
        else if (TCText.Text.Length > 30)
        {
            Error.Subtitle = "Total attented classes has " + (ACText.Text.Length - 30) + " extra character(s)!";
        }
        else
        {
            con.Open();
            OracleCommand insertAtt = con.CreateCommand();
            insertAtt.CommandType = CommandType.Text;
            insertAtt.CommandText = "INSERT INTO ATTENDENCE VALUES('" +
            sidText.Text.ToString() + "\'," +
            TCText.Text.ToString() + "," +
            (((double)AC / TC) * 100).ToString() + "," +
            ACText.Text.ToString() + ")";
            insertAtt.ExecuteNonQuery();
            con.Close();

            Error.Title = "Successfull! ✔️";
            Error.Subtitle = "Attendence added successfully!";
        }

        Error.IsOpen = true;
        Error.RequestedTheme = ElementTheme.Light;
    }
}
