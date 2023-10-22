using DB_FINAL_PROJECT.Activation;
using DB_FINAL_PROJECT.Contracts.Services;
using DB_FINAL_PROJECT.Core.Contracts.Services;
using DB_FINAL_PROJECT.Core.Services;
using DB_FINAL_PROJECT.Helpers;
using DB_FINAL_PROJECT.Models;
using DB_FINAL_PROJECT.Notifications;
using DB_FINAL_PROJECT.Services;
using DB_FINAL_PROJECT.ViewModels;
using DB_FINAL_PROJECT.Views;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

namespace DB_FINAL_PROJECT;

// To learn more about WinUI 3, see https://docs.microsoft.com/windows/apps/winui/winui3/.
public partial class App : Application
{
    // The .NET Generic Host provides dependency injection, configuration, logging, and other services.
    // https://docs.microsoft.com/dotnet/core/extensions/generic-host
    // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
    // https://docs.microsoft.com/dotnet/core/extensions/configuration
    // https://docs.microsoft.com/dotnet/core/extensions/logging
    public IHost Host
    {
        get;
    }

    public static T GetService<T>()
        where T : class
    {
        if ((App.Current as App)!.Host.Services.GetService(typeof(T)) is not T service)
        {
            throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.");
        }

        return service;
    }

    public static WindowEx MainWindow { get; } = new MainWindow();

    public App()
    {
        InitializeComponent();

        Host = Microsoft.Extensions.Hosting.Host.
        CreateDefaultBuilder().
        UseContentRoot(AppContext.BaseDirectory).
        ConfigureServices((context, services) =>
        {
            // Default Activation Handler
            services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

            // Other Activation Handlers
            services.AddTransient<IActivationHandler, AppNotificationActivationHandler>();

            // Services
            services.AddSingleton<IAppNotificationService, AppNotificationService>();
            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
            services.AddTransient<INavigationViewService, NavigationViewService>();

            services.AddSingleton<IActivationService, ActivationService>();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();

            // Core Services
            services.AddSingleton<IFileService, FileService>();

            // Views and ViewModels
            services.AddTransient<VIEW_STUDENTS_IN_CLASSViewModel>();
            services.AddTransient<VIEW_STUDENTS_IN_CLASSPage>();
            services.AddTransient<VIEW_CLASSESViewModel>();
            services.AddTransient<VIEW_CLASSESPage>();
            services.AddTransient<ADD_STUDENT_TO_CLASSViewModel>();
            services.AddTransient<ADD_STUDENT_TO_CLASSPage>();
            services.AddTransient<ADD_CLASS_SCHEDULEViewModel>();
            services.AddTransient<ADD_CLASS_SCHEDULEPage>();
            services.AddTransient<ADD_CLASSViewModel>();
            services.AddTransient<ADD_CLASSPage>();
            services.AddTransient<CLASS_MODULEViewModel>();
            services.AddTransient<CLASS_MODULEPage>();
            services.AddTransient<MY_SCHEDULEViewModel>();
            services.AddTransient<MY_SCHEDULEPage>();
            services.AddTransient<MY_ATTENDANCEViewModel>();
            services.AddTransient<MY_ATTENDANCEPage>();
            services.AddTransient<VIEW_CLASSViewModel>();
            services.AddTransient<VIEW_CLASSPage>();
            services.AddTransient<VIEW_ATTENDANCEViewModel>();
            services.AddTransient<VIEW_ATTENDANCEPage>();
            services.AddTransient<ADD_ATTENDANCEViewModel>();
            services.AddTransient<ADD_ATTENDANCEPage>();
            services.AddTransient<EDIT_STUDENTViewModel>();
            services.AddTransient<EDIT_STUDENTPage>();
            services.AddTransient<EDIT_TEACHERViewModel>();
            services.AddTransient<EDIT_TEACHERPage>();
            services.AddTransient<ADD_CLASS_SCHEDULEViewModel>();
            services.AddTransient<ADD_CLASSViewModel>();
            services.AddTransient<ADD_STUDENTViewModel>();
            services.AddTransient<ADD_STUDENTPage>();
            services.AddTransient<ADD_TEACHERViewModel>();
            services.AddTransient<ADD_TEACHERPage>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<SettingsPage>();
            services.AddTransient<STUDENTViewModel>();
            services.AddTransient<STUDENTPage>();
            services.AddTransient<TEACHERViewModel>();
            services.AddTransient<TEACHERPage>();
            services.AddTransient<ADMINISTRATORViewModel>();
            services.AddTransient<ADMINISTRATORPage>();
            services.AddTransient<LOGINViewModel>();
            services.AddTransient<LOGINPage>();
            services.AddTransient<ShellPage>();
            services.AddTransient<ShellViewModel>();

            // Configuration
            services.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));
        }).
        Build();

        App.GetService<IAppNotificationService>().Initialize();

        UnhandledException += App_UnhandledException;
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        // TODO: Log and handle exceptions as appropriate.
        // https://docs.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.application.unhandledexception.
    }

    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);

        App.GetService<IAppNotificationService>().Show(string.Format("AppNotificationSamplePayload".GetLocalized(), AppContext.BaseDirectory));

        await App.GetService<IActivationService>().ActivateAsync(args);
    }

    public static class LoginPortal
    {
        public static bool LoginAdd = false;
        public static bool LoginStd = false;
        public static bool LoginTea = false;
        public static string LoginInfo;
    }
}
