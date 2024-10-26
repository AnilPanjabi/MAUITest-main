namespace MAUITest.UI.BankDetails;

public partial class BankDetailsListPage : ContentPage
{
    private readonly BankDetailsPageViewModel _viewModel;

    public BankDetailsListPage(BankDetailsPageViewModel viewModel)
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
