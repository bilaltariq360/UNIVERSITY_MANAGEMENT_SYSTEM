using DB_FINAL_PROJECT.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using static DB_FINAL_PROJECT.App;

namespace DB_FINAL_PROJECT.Views;

public sealed partial class STUDENTPage : Page
{
    public STUDENTViewModel ViewModel
    {
        get;
    }

    public STUDENTPage()
    {
        ViewModel = App.GetService<STUDENTViewModel>();
        InitializeComponent();
        LoadOnPage();
    }

    private void LoadOnPage()
    {
        if (LoginPortal.LoginStd)
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
        LoginPortal.LoginStd = false;
        LoginMsgText.Text = "Login to your account!";
        LogoutButton.Visibility = Visibility.Collapsed;
        Frame.Navigate(typeof(LOGINPage));
    }
}
