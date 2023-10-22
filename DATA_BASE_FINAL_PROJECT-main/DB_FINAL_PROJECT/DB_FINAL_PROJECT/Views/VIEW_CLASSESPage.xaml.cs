using System.Data;
using DB_FINAL_PROJECT.ViewModels;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Oracle.ManagedDataAccess.Client;
using static DB_FINAL_PROJECT.App;

namespace DB_FINAL_PROJECT.Views;

public sealed partial class VIEW_CLASSESPage : Page
{
    OracleConnection con;

    public VIEW_CLASSESViewModel ViewModel
    {
        get;
    }

    public VIEW_CLASSESPage()
    {
        ViewModel = App.GetService<VIEW_CLASSESViewModel>();
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
            AddDataToGrid();
        }
    }

    private void AddDataToGrid()
    {
        List<Data> classData = new List<Data>();

        con.Open();
        OracleCommand getClasses = con.CreateCommand();
        getClasses.CommandText = "SELECT * FROM CLASS";
        getClasses.CommandType = CommandType.Text;
        OracleDataReader classesDR = getClasses.ExecuteReader();

        while (classesDR.Read())
        {
            classData.Add(new Data { Classid = classesDR.GetString(0), Teacherid = classesDR.GetString(1), Section = classesDR.GetString(2), Semester = classesDR.GetString(3), Capacity = classesDR.GetString(4) });
        }
        dataGrid.ItemsSource = classData;
        classesDR.Close();
        con.Close();
    }

    public class Data
    {
        public string? Classid
        {
            get; set;
        }
        public string? Teacherid
        {
            get; set;
        }
        public string? Section
        {
            get; set;
        }
        public string? Semester
        {
            get; set;
        }
        public string? Capacity
        {
            get; set;
        }
    }
}