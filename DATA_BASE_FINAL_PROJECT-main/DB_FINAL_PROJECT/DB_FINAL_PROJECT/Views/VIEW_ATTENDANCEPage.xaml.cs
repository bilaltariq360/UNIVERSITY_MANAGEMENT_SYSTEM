using DB_FINAL_PROJECT.ViewModels;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Oracle.ManagedDataAccess.Client;
using static DB_FINAL_PROJECT.App;
using System.Data;

namespace DB_FINAL_PROJECT.Views;

public sealed partial class VIEW_ATTENDANCEPage : Page
{
    OracleConnection con;

    public VIEW_ATTENDANCEViewModel ViewModel
    {
        get;
    }

    public VIEW_ATTENDANCEPage()
    {
        ViewModel = App.GetService<VIEW_ATTENDANCEViewModel>();
        InitializeComponent();

        string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID = F21_9243; PASSWORD = 1234";
        con = new OracleConnection(conStr);

        LoadOnPage();
    }

    private void LoadOnPage()
    {
        if (LoginPortal.LoginTea)
        {
            ContentArea.Visibility = Visibility.Visible;
            tnameText.Text = LoginPortal.LoginInfo;
            AddDataToGrid();
        }
    }

    private void AddDataToGrid()
    {
        List<Data> attData = new List<Data>();

        con.Open();
        OracleCommand getAtt = con.CreateCommand();
        getAtt.CommandText = "SELECT a.s_id, a.total_classes, TRUNC(a.PERCENTAGE_OF_ATTENDENCE, 3), a.NUMBER_OF_CLASSES_ATTEND, s.first_name, s.last_name FROM ATTENDENCE a, STUDENT s, CLASS c, Teacher t WHERE a.s_id = s.s_id AND s.c_id = c.c_id AND t.t_id ='" + LoginPortal.LoginInfo + "'AND c.t_id = '" + LoginPortal.LoginInfo + "' ORDER BY a.s_id ASC";
        getAtt.CommandType = CommandType.Text;
        OracleDataReader AttDR = getAtt.ExecuteReader();

        while (AttDR.Read())
        {
            attData.Add(new Data { Studentid = AttDR.GetString(0), Name = AttDR.GetString(4) + " " + AttDR.GetString(5), Totalclasses = AttDR.GetString(1), POclasses = AttDR.GetString(2) + "%", NOCattended = AttDR.GetString(3) });
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
