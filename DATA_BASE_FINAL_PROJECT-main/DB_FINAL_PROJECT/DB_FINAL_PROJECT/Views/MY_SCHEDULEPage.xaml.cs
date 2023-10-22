using DB_FINAL_PROJECT.ViewModels;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using Oracle.ManagedDataAccess.Client;
using static DB_FINAL_PROJECT.App;
using System.Data;
using System.Xml.Linq;
using Microsoft.UI.Xaml.Controls.Primitives;
using System.Security.Claims;


namespace DB_FINAL_PROJECT.Views;

public sealed partial class MY_SCHEDULEPage : Page
{
    OracleConnection con;
    public MY_SCHEDULEViewModel ViewModel
    {
        get;
    }

    public MY_SCHEDULEPage()
    {
        ViewModel = App.GetService<MY_SCHEDULEViewModel>();
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
        List<Data> scheduleData = new List<Data>();

        con.Open();
        OracleCommand getSche = con.CreateCommand();
        getSche.CommandText = "SELECT  DISTINCT(cs.s_no), CS.C_ID, CS.T_ID, TO_CHAR(CS.START_TIME, 'DD-MM-YYYY HH24:MI:SS'), TO_CHAR(CS.END_TIME, 'DD-MM-YYYY HH24:MI:SS'), CS.LOCATION, CS.DAY_OF_WEEK FROM CLASS_SCHEDULE cs, STUDENT s ,CLASS c WHERE s.c_id = c.c_id AND c.c_id = cs.c_id AND s.s_id = '" + LoginPortal.LoginInfo + "'";
        getSche.CommandType = CommandType.Text;
        OracleDataReader ScheDR = getSche.ExecuteReader();

        while (ScheDR.Read())
        {
            scheduleData.Add(new Data { SNO = ScheDR.GetString(0), CID = ScheDR.GetString(1), TID = ScheDR.GetString(2), START_TIME = ScheDR.GetString(3), END_TIME = ScheDR.GetString(4), LOCATION = ScheDR.GetString(5), DAY_OF_WEEK = ScheDR.GetString(6) });
        }
        dataGrid.ItemsSource = scheduleData;
        ScheDR.Close();
        con.Close();
    }

    public class Data
    {
        public string? SNO
        {
            get; set;
        }
        public string? CID
        {
            get; set;
        }
        public string? TID
        {
            get; set;
        }
        public string? START_TIME
        {
            get; set;
        }
        public string? END_TIME
        {
            get; set;
        }
        public string? LOCATION
        {
            get; set;
        }
        public string? DAY_OF_WEEK
        {
            get; set;
        }
    }
}