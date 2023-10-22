using System.Data;
using System.Runtime.Intrinsics.Arm;
using DB_FINAL_PROJECT.ViewModels;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Oracle.ManagedDataAccess.Client;
using Windows.Devices.Enumeration;
using Windows.UI;
using static DB_FINAL_PROJECT.App;

namespace DB_FINAL_PROJECT.Views;

public sealed partial class LOGINPage : Page
{
    OracleConnection con;

    public LOGINViewModel ViewModel
    {
        get;
    }

    internal class ContentDialogContent
    {
        public ContentDialogContent()
        {
        }
    }

    public LOGINPage()
    {
        ViewModel = App.GetService<LOGINViewModel>();
        InitializeComponent();

        string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID = F21_9243; PASSWORD = 1234";
        con = new OracleConnection(conStr);
        
        OnLoad();
    }

    private void OnLoad()
    {
        if (LoginPortal.LoginAdd || LoginPortal.LoginStd || LoginPortal.LoginTea)
        {
            Login_Pic.Visibility = Visibility.Collapsed;
            Tick.Visibility = Visibility.Visible;
        }
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        bool found = false;

        con.Open();
        OracleCommand userId = con.CreateCommand();
        userId.CommandText = "SELECT a_id FROM ADMINISTRATOR WHERE a_password = \'" + passText.Password.ToString() + "\'";
        userId.CommandType = CommandType.Text;
        OracleDataReader userDR = userId.ExecuteReader();
        while (userDR.Read())
        {
            if (userText.Text.ToString() == userDR.GetString(0))
            {
                found = true;
                break;
            }
        }
        userDR.Close();
        con.Close();

        if (found)
        {
            LoginPortal.LoginAdd = true;
            LoginPortal.LoginStd = LoginPortal.LoginTea = false;
            LoginPortal.LoginInfo = userText.Text.ToString();
            Login_Pic.Visibility = Visibility.Collapsed;
            Frame.Navigate(typeof(ADMINISTRATORPage));
            return;
        }

        con.Open();
        userId.CommandText = "SELECT s_id FROM STUDENT WHERE s_password = \'" + passText.Password.ToString() + "\'";
        userId.CommandType = CommandType.Text;
        userDR = userId.ExecuteReader();
        while (userDR.Read())
        {
            if (userText.Text.ToString() == userDR.GetString(0))
            {
                found = true;
                break;
            }
        }
        userDR.Close();
        con.Close();

        if (found)
        {
            LoginPortal.LoginStd = true;
            LoginPortal.LoginAdd = LoginPortal.LoginTea = false;
            LoginPortal.LoginInfo = userText.Text.ToString();
            Login_Pic.Visibility = Visibility.Collapsed;
            Frame.Navigate(typeof(STUDENTPage));
            return;
        }

        con.Open();
        userId.CommandText = "SELECT t_id FROM TEACHER WHERE t_password = \'" + passText.Password.ToString() + "\'";
        userId.CommandType = CommandType.Text;
        userDR = userId.ExecuteReader();
        while (userDR.Read())
        {
            if (userText.Text.ToString() == userDR.GetString(0))
            {
                found = true;
                break;
            }
        }
        userDR.Close();
        con.Close();

        if (found)
        {
            LoginPortal.LoginTea = true;
            LoginPortal.LoginStd = LoginPortal.LoginAdd = false;
            LoginPortal.LoginInfo = userText.Text.ToString();
            Login_Pic.Visibility = Visibility.Collapsed;
            Frame.Navigate(typeof(TEACHERPage));
            return;
        }
        
        if(!found)
        {
            Error.IsOpen = true;
            Error.RequestedTheme = ElementTheme.Light;
        }
    }
}