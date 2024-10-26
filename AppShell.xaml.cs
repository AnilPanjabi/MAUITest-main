using MAUITest.Business.Common.Services;
using MAUITest.Common.Abstractions;
using MAUITest.UI.BankDetails;
using MAUITest.UI.CardDetails;

namespace MAUITest;

public partial class AppShell : Shell
{
	private readonly INavigationService _navigationService;

    public AppShell()
    {
        _navigationService = AppService.ServiceProvider.GetRequiredService<INavigationService>();

        InitializeComponent();
	}

    private async void BankDetails_Clicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.FlyoutIsPresented = false;
        await _navigationService.NavigateTo(nameof(BankDetailsListPage));
    }

    private async void CardDetails_Clicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.FlyoutIsPresented = false;
        await _navigationService.NavigateTo(nameof(CardDetailsListPage));
    }
}

