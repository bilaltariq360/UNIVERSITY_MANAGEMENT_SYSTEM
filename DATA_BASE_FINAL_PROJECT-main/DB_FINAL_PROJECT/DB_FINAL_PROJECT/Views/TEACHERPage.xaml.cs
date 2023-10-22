using DB_FINAL_PROJECT.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using static DB_FINAL_PROJECT.App;

namespace DB_FINAL_PROJECT.Views;

public sealed partial class TEACHERPage : Page
{
    public TEACHERViewModel ViewModel
    {
        get;
    }

    public TEACHERPage()
    {
        ViewModel = App.GetService<TEACHERViewModel>();
        InitializeComponent();
        LoadOnPage();
    }

    private void LoadOnPage()
    {
        if (LoginPortal.LoginTea)
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
        LoginPortal.LoginTea = false;
        LoginMsgText.Text = "Login to your account!";
        LogoutButton.Visibility = Visibility.Collapsed;
        Frame.Navigate(typeof(LOGINPage));
    }
}
