using System.Data;
using DB_FINAL_PROJECT.ViewModels;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Oracle.ManagedDataAccess.Client;
using static DB_FINAL_PROJECT.App;

namespace DB_FINAL_PROJECT.Views;

public sealed partial class VIEW_CLASSPage : Page
{
    OracleConnection con;

    List<string> classes = new List<string>();

    public VIEW_CLASSViewModel ViewModel
    {
        get;
    }

    public VIEW_CLASSPage()
    {
        ViewModel = App.GetService<VIEW_CLASSViewModel>();
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
            OracleCommand getCls = con.CreateCommand();
            getCls.CommandText = "SELECT c.c_id FROM CLASS c WHERE c.t_id = '" + LoginPortal.LoginInfo + "' ORDER BY c.c_id ASC";
            getCls.CommandType = CommandType.Text;
            OracleDataReader ClsDR = getCls.ExecuteReader();

            while (ClsDR.Read())
            {
                classes.Add(ClsDR.GetString(0).ToString());
            }
            ClsDR.Close();
            con.Close();
        }
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

        List<Data> classData = new List<Data>();

        con.Open();
        OracleCommand getClasses = con.CreateCommand();
        getClasses.CommandText = "SELECT s_id, first_name, last_name, gender, reg_date, fees_paid, contact_no, blood_group, address FROM STUDENT WHERE c_id = \'" + cidText.Text.ToString() + "\' ORDER BY s_id ASC";
        getClasses.CommandType = CommandType.Text;
        OracleDataReader classesDR = getClasses.ExecuteReader();

        while (classesDR.Read())
        {
            classData.Add(new Data { Studentid = classesDR.GetString(0), Studentname = classesDR.GetString(1) + " " + classesDR.GetString(2), Gender = classesDR.GetString(3), Registrationdate = classesDR.GetString(4), Feestatus = classesDR.GetString(5), Contact = classesDR.GetString(6), Bloodgroup = classesDR.GetString(7), Address = classesDR.GetString(8) });
        }
        dataGrid.ItemsSource = classData;
        classesDR.Close();
        con.Close();
    }

    public class Data
    {
        public string? Studentid
        {
            get; set;
        }
        public string? Studentname
        {
            get; set;
        }
        public string? Gender
        {
            get; set;
        }
        public string? Registrationdate
        {
            get; set;
        }
        public string? Feestatus
        {
            get; set;
        }
        public string? Contact
        {
            get; set;
        }
        public string? Bloodgroup
        {
            get; set;
        }
        public string? Address
        {
            get; set;
        }
    }
}
