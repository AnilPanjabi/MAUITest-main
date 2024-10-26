using MAUITest.Business.Common.Extensions;
using MAUITest.Common.Abstractions;

namespace MAUITest.UI.BankDetails;

[QueryProperty(nameof(String), nameof(BankDetailPageQueryAttributes))]
public partial class BankDetailsPage : ContentPage, IQueryAttributable
{
    private readonly INavigationService _navigationService;
    private readonly BankDetailsPageViewModel _viewModel;
    private BankDetailPageQueryAttributes _queryAttributes;

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="viewModel"></param>
    public BankDetailsPage(BankDetailsPageViewModel viewModel, INavigationService navigationService)
	{
        BindingContext = viewModel;
        _viewModel = viewModel;
        _navigationService = navigationService;

        InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (!string.IsNullOrEmpty(_queryAttributes?.BankDetailId))
        {
            _viewModel.BankDetailsId = _queryAttributes?.BankDetailId;
            AddButton.Text = "Update";
            this.Title = "Update Bank Details";
        }

        await _viewModel.OnAppearing();
    }


    private async void OnUploadImageButtonClicked(object sender, EventArgs e)
    {
        await CapturePhotoAsync();
    }

    private async Task CapturePhotoAsync()
    {
        try
        {
            var result = await MediaPicker.CapturePhotoAsync();

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                SelectedImage.Source = ImageSource.FromStream(() => stream);
                SelectedImage.IsVisible = true;

                // Save the file locally (optional)
                var localPath = Path.Combine(FileSystem.AppDataDirectory, result.FileName);
                using (var localStream = File.Create(localPath))
                {
                    await stream.CopyToAsync(localStream);
                }
            }
        }
        catch (FeatureNotSupportedException)
        {
            await DisplayAlert("Error", "Camera not supported on this device.", "OK");
        }
        catch (PermissionException)
        {
            await DisplayAlert("Error", "Camera permissions not granted.", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "An error occurred: " + ex.Message, "OK");
        }
    }

    private async void OnAddButtonClicked(object sender, EventArgs e)
    {
        var bankName = BankNameEntry.Text;
        var accountHolderName = AccountHolderNameEntry.Text;
        var accountNumber = AccountNumberEntry.Text;
        var ifscCode = IfscCodeEntry.Text;

        if (string.IsNullOrWhiteSpace(bankName) ||
            string.IsNullOrWhiteSpace(accountHolderName) ||
            string.IsNullOrWhiteSpace(accountNumber) ||
            string.IsNullOrWhiteSpace(ifscCode))
        {
            await DisplayAlert("Error", "Please fill in all fields", "OK");

            return;
        }

        // Handle the add logic here, such as saving to a database or sending to an API

        await _viewModel.AddBankDetails();
        await DisplayAlert("Success", "Bank details added successfully", "OK");


        // Optionally, navigate back or clear the form
        await _navigationService.NavigateBack();

    }

    #region Extract Navigation Query Properties

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        _queryAttributes = query.GetQueryAttributeValue<BankDetailPageQueryAttributes>(nameof(BankDetailPageQueryAttributes));
    }

    #endregion
}
