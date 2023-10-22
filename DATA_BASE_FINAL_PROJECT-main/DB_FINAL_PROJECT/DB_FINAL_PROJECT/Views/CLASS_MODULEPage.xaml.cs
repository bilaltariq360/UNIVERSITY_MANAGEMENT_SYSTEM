using DB_FINAL_PROJECT.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace DB_FINAL_PROJECT.Views;

public sealed partial class CLASS_MODULEPage : Page
{
    public CLASS_MODULEViewModel ViewModel
    {
        get;
    }

    public CLASS_MODULEPage()
    {
        ViewModel = App.GetService<CLASS_MODULEViewModel>();
        InitializeComponent();
    }
}
