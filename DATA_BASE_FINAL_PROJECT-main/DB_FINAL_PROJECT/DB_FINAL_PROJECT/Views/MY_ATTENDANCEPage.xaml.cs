using DB_FINAL_PROJECT.ViewModels;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Oracle.ManagedDataAccess.Client;
using static DB_FINAL_PROJECT.App;
using System.Data;
using System.Xml.Linq;

namespace DB_FINAL_PROJECT.Views;


public sealed partial class MY_ATTENDANCEPage : Page
{
    OracleConnection con;
    public MY_ATTENDANCEViewModel ViewModel
    {
        get;
    }

    public MY_ATTENDANCEPage()
    {
        ViewModel = App.GetService<MY_ATTENDANCEViewModel>();
        InitializeComponent();

        string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID = F21_9243; PASSWORD = 1234";
        con = new OracleConnection(conStr);

        LoadOnPage();
    }


    private void LoadOnPage()
    {
        if (LoginPortal.LoginStd)
        {
            ContentArea.Visibility = Visibility.Visible;
            snameText.Text = LoginPortal.LoginInfo;
            AddDataToGrid();
        }
    }

    private void AddDataToGrid()
    {
        List<Data> attData = new List<Data>();

        con.Open();
        OracleCommand getAtt = con.CreateCommand();
        getAtt.CommandText = "Select  s.first_name, s.last_name, a.s_id, a.total_classes, TRUNC(a.percentage_of_attendence, 3), a.number_of_classes_attend FROM ATTENDENCE a, STUDENT s WHERE a.s_id = s.s_id AND a.s_id = '" + LoginPortal.LoginInfo + "'";
        getAtt.CommandType = CommandType.Text;
        OracleDataReader AttDR = getAtt.ExecuteReader();

        while (AttDR.Read())
        {
            attData.Add(new Data { Studentid = AttDR.GetString(2), Name = AttDR.GetString(0) + " " + AttDR.GetString(1), Totalclasses = AttDR.GetString(3), POclasses = AttDR.GetString(4) + "%", NOCattended = AttDR.GetString(5) });
        }
        dataGrid.ItemsSource = attData;
        AttDR.Close();
        con.Close();
    }

    public class Data
    {
        public string? Studentid
        {
            get; set;
        }
        public string? Name
        {
            get; set;
        }
        public string? Totalclasses
        {
            get; set;
        }
        public string? NOCattended
        {
            get; set;
        }
        public string? POclasses
        {
            get; set;
        }
    }

}