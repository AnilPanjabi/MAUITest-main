using System.Text.RegularExpressions;
using MAUITest.Business.Common.Extensions;

namespace MAUITest.UI.CardDetails;

[QueryProperty(nameof(String), nameof(CardDetailPageQueryAttributes))]
public partial class CardDetailsPage : ContentPage, IQueryAttributable
{
    private CardDetailPageQueryAttributes _queryAttributes;

    public CardDetailsPage()
	{
		InitializeComponent();
	}

    private void OnSubmitClicked(object sender, EventArgs e)
    {
        bool isValid = ValidateForm();

        if (isValid)
        {
            // Process the form
            DisplayAlert("Success", "Your card details have been submitted.", "OK");
        }
    }

    private bool ValidateForm()
    {
        bool isValid = true;

        // Reset error messages
        CardTypeError.IsVisible = false;
        CardProviderBankNameEntryError.IsVisible = false;
        CardNumberError.IsVisible = false;
        CardholderNameError.IsVisible = false;
        CardExpiryError.IsVisible = false;
        CVVError.IsVisible = false;

        //Validate Card Type
        if (string.IsNullOrEmpty((string)CardType.SelectedItem))
        {
            CardTypeError.Text = "Card Type is required.";
            CardTypeError.IsVisible = true;
            isValid = false;
        }

        // Validate Card Number
        if (string.IsNullOrEmpty(CardProviderBankNameEntry.Text))
        {
            CardProviderBankNameEntryError.Text = "Card Provider Bank Name is required.";
            CardProviderBankNameEntryError.IsVisible = true;
            isValid = false;
        }

        // Validate Card Number
        if (string.IsNullOrEmpty(CardProviderBankNameEntry.Text))
        {
            CardProviderBankNameEntryError.Text = "Card Provider Bank Name is required.";
            CardProviderBankNameEntryError.IsVisible = true;
            isValid = false;
        }

        // Validate Card Number
        if (string.IsNullOrEmpty(CardNumberEntry.Text) || !Regex.IsMatch(CardNumberEntry.Text, @"^\d{16}$"))
        {
            CardNumberError.Text = "Card number must be 16 digits.";
            CardNumberError.IsVisible = true;
            isValid = false;
        }

        // Validate Cardholder Name
        if (string.IsNullOrEmpty(CardholderNameEntry.Text))
        {
            CardholderNameError.Text = "Cardholder name is required.";
            CardholderNameError.IsVisible = true;
            isValid = false;
        }

        // Validate Expiration Date (MM/YYYY)
        if (ExDate.SelectedMonth <= 0)
        {
            CardExpiryError.Text = ExDate.SelectedYear <= 0 ? "Month/Year must be selected." : "Month must be selected.";
            CardExpiryError.IsVisible = true;
            isValid = false;
        }
        else if (ExDate.SelectedYear <= 0)
        {
            CardExpiryError.Text = "Year must be selected.";
            CardExpiryError.IsVisible = true;
            isValid = false;
        }
        else if (ExDate.SelectedYear == DateTime.Now.Date.Year && ExDate.SelectedMonth < DateTime.Now.Date.Month)
        {
            CardExpiryError.Text = "Select valid month";
            CardExpiryError.IsVisible = true;
            isValid = false;
        }

        // Validate CVV
        if (string.IsNullOrEmpty(CVVEntry.Text))
        {
            CVVError.Text = "CVV is required.";
            CVVError.IsVisible = true;
            isValid = false;
        }

        return isValid;
    }


    #region Extract Navigation Query Properties

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        _queryAttributes = query.GetQueryAttributeValue<CardDetailPageQueryAttributes>(nameof(CardDetailPageQueryAttributes));
    }

    void CVVHideShow_Clicked(System.Object sender, System.EventArgs e)
    {
        if (CVVHideShow.Text == "Show")
        {
            CVVHideShow.Text = "Hide";
            CVVEntry.IsPassword = false;
        }
        else
        {
            CVVHideShow.Text = "Show";
            CVVEntry.IsPassword = true;
        }
    }

    #endregion
}
