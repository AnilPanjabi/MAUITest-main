using MAUITest.UI.BankDetails;
using MAUITest.Common.Abstractions;

namespace MAUITest.UI;

public partial class MainPage : ContentPage
{

	private readonly INavigationService _navigationService;
    int count = 0;

	public MainPage(INavigationService navigationService)
	{
		_navigationService = navigationService;
		InitializeComponent();
        //_navigationService.NavigateTo(nameof(BankDetailsListPage));
    }

 //   private void OnCounterClicked(object sender, EventArgs e)
	//{
	//	count++;

	//	if (count == 1)
	//		CounterBtn.Text = $"Clicked {count} time";
	//	else
	//		CounterBtn.Text = $"Clicked {count} times";

	//	SemanticScreenReader.Announce(CounterBtn.Text);
	//}

	private async void OnAddBankDetailsClicked(Object sender, EventArgs e)
	{
		await _navigationService.NavigateTo(nameof(BankDetailsListPage));
	}

    private void OnGoogleLoginClicked(System.Object sender, System.EventArgs e)
    {
    }
}


