using CommunityToolkit.Mvvm.ComponentModel;

using DB_FINAL_PROJECT.Contracts.Services;
using DB_FINAL_PROJECT.ViewModels;
using DB_FINAL_PROJECT.Views;

using Microsoft.UI.Xaml.Controls;

namespace DB_FINAL_PROJECT.Services;

public class PageService : IPageService
{
    private readonly Dictionary<string, Type> _pages = new();

    public PageService()
    {
        Configure<LOGINViewModel, LOGINPage>();
        Configure<ADMINISTRATORViewModel, ADMINISTRATORPage>();
        Configure<TEACHERViewModel, TEACHERPage>();
        Configure<STUDENTViewModel, STUDENTPage>();
        Configure<SettingsViewModel, SettingsPage>();
        Configure<ADD_TEACHERViewModel, ADD_TEACHERPage>();
        Configure<ADD_STUDENTViewModel, ADD_STUDENTPage>();
        Configure<EDIT_TEACHERViewModel, EDIT_TEACHERPage>();
        Configure<EDIT_STUDENTViewModel, EDIT_STUDENTPage>();
        Configure<ADD_ATTENDANCEViewModel, ADD_ATTENDANCEPage>();
        Configure<VIEW_ATTENDANCEViewModel, VIEW_ATTENDANCEPage>();
        Configure<VIEW_CLASSViewModel, VIEW_CLASSPage>();
        Configure<MY_ATTENDANCEViewModel, MY_ATTENDANCEPage>();
        Configure<MY_SCHEDULEViewModel, MY_SCHEDULEPage>();
        Configure<CLASS_MODULEViewModel, CLASS_MODULEPage>();
        Configure<ADD_CLASSViewModel, ADD_CLASSPage>();
        Configure<ADD_CLASS_SCHEDULEViewModel, ADD_CLASS_SCHEDULEPage>();
        Configure<ADD_STUDENT_TO_CLASSViewModel, ADD_STUDENT_TO_CLASSPage>();
        Configure<VIEW_CLASSESViewModel, VIEW_CLASSESPage>();
        Configure<VIEW_STUDENTS_IN_CLASSViewModel, VIEW_STUDENTS_IN_CLASSPage>();
    }

    public Type GetPageType(string key)
    {
        Type? pageType;
        lock (_pages)
        {
            if (!_pages.TryGetValue(key, out pageType))
            {
                throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
            }
        }

        return pageType;
    }

    private void Configure<VM, V>()
        where VM : ObservableObject
        where V : Page
    {
        lock (_pages)
        {
            var key = typeof(VM).FullName!;
            if (_pages.ContainsKey(key))
            {
                throw new ArgumentException($"The key {key} is already configured in PageService");
            }

            var type = typeof(V);
            if (_pages.Any(p => p.Value == type))
            {
                throw new ArgumentException($"This type is already configured with key {_pages.First(p => p.Value == type).Key}");
            }

            _pages.Add(key, type);
        }
    }
}
