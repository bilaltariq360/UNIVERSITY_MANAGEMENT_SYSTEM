using System.Security.Cryptography.X509Certificates;
using DB_FINAL_PROJECT.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Windows.Devices.Enumeration;
using static DB_FINAL_PROJECT.App;

namespace DB_FINAL_PROJECT.Views;

public sealed partial class ADMINISTRATORPage : Page
{
    public ADMINISTRATORViewModel ViewModel
    {
        get;
    }

    public ADMINISTRATORPage()
    {
        ViewModel = App.GetService<ADMINISTRATORViewModel>();
        InitializeComponent();
        LoadOnPage();
    }

    private void LoadOnPage()
    {
        if (LoginPortal.LoginAdd)
        {
            LoginMsgText.Text = LoginPortal.LoginInfo.ToString();
            LoginMsgText.Visibility = Visibility.Visible;
            LoginMsgText.Text += """ 🎉""";
            LogoutButton.Visibility = Visibility.Visible;
            Welcome_Pic.Visibility = Visibility.Visible;
        }
    }

    private void LogoutButton_Click(object sender, RoutedEventArgs e)
    {
        LoginPortal.LoginAdd = false;
        LoginMsgText.Text = "Login to your account!";
        LogoutButton.Visibility = Visibility.Collapsed;
        Frame.Navigate(typeof(LOGINPage));
    }
}
