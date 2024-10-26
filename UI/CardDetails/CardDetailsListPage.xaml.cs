namespace MAUITest.UI.CardDetails;

public partial class CardDetailsListPage : ContentPage
{
	private readonly CardDetailsPageViewModel _viewModel;
	public CardDetailsListPage(CardDetailsPageViewModel viewModel)
	{
		BindingContext = viewModel;
		_viewModel = viewModel;
        _viewModel.IsListForm = true;
        InitializeComponent();
	}


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.OnAppearing();
    }
}
