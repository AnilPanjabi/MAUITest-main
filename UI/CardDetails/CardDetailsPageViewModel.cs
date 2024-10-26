using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MAUITest.Business.Common.Services;
using MAUITest.Data.Models;
using MAUITest.Business.Services.CardDetails;
using MAUITest.Common.Abstractions;
using MAUITest.Business.Models.ViewModels;

namespace MAUITest.UI.CardDetails
{
    public class CardDetailsPageViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// ICardDetailService
        /// </summary>
        private readonly ICardDetailService _cardDetailService;
        private readonly INavigationService _navigationService;

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand ShareCommand { get; set; }
        public ICommand CopyCommand { get; set; }

        public CardDetailsViewModel CardDetail
        {
            get { return _cardDetail; }
            set
            {
                _cardDetail = value;
                OnPropertyChanged();
            }
        }
        private CardDetailsViewModel _cardDetail;


        public ObservableCollection<CardDetailsViewModel> CardDetails
        {
            get { return _cardDetails; }
            set
            {
                _cardDetails = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<CardDetailsViewModel> _cardDetails;

        public string CardDetailsId
        {
            get { return _cardDetailsId; }
            set
            {
                _cardDetailsId = value;
                OnPropertyChanged();
            }
        }
        private string _cardDetailsId;


        public bool IsListForm
        {
            get { return _isListForm; }
            set
            {
                _isListForm = value;
                OnPropertyChanged();
            }
        }
        private bool _isListForm = false;

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="cardDetailService"></param>
        /// <param name="navigationService"></param>
        public CardDetailsPageViewModel(ICardDetailService cardDetailService, INavigationService navigationService)
        {
            _cardDetailService = cardDetailService;
            _navigationService = navigationService;

            AddCommand = new Command(OnAdd);
            EditCommand = new Command<CardDetailsViewModel>(OnEdit);
            ShareCommand = new Command<CardDetailsViewModel>(OnShare);
            CopyCommand = new Command<string>(OnCopy);
        }

        public async Task OnAppearing()
        {
            await LoadCardDetails();
        }

        public async Task AddCardDetails()
        {
            var cardDetail = new CardDetailsDataModel()
            {
                CardType = CardDetail.CardType,
                CardProviderBankName = CardDetail.CardProviderBankName,
                CardHolderName = CardDetail.CardHolderName,
                CardNumber = CardDetail.CardNumber,
                ExpiryMonth = CardDetail.ExpiryMonth,
                ExpiryYear = CardDetail.ExpiryYear,
                CVVCode = CardDetail.CVVCode,
                CardDetailId = string.IsNullOrEmpty(CardDetailsId) ? Guid.NewGuid().ToString() : CardDetailsId
            };
            if (string.IsNullOrEmpty(CardDetailsId))
            {
                await _cardDetailService.AddCardDetails(cardDetail);
            }
            else
            {
                await _cardDetailService.UpdateCardDetails(cardDetail);
            }
        }

        #region Private

        private async Task LoadCardDetails()
        {
            if (IsListForm)
            {
                CardDetails = new ObservableCollection<CardDetailsViewModel>(await _cardDetailService.GetList());
            }
            else
            {
                if (!string.IsNullOrEmpty(CardDetailsId))
                {
                    CardDetail = await _cardDetailService.Get(CardDetailsId);
                }
                else
                {
                    CardDetail = new CardDetailsViewModel();
                }
            }
        }

        private async void OnAdd()
        {
            await _navigationService.NavigateTo(nameof(CardDetailsPage));
        }

        private async void OnEdit(CardDetailsViewModel cardDetail)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                {
                    nameof(CardDetailPageQueryAttributes),
                    new CardDetailPageQueryAttributes() { CardDetailId = cardDetail.CardDetailId }
                }
            };

            await _navigationService.NavigateTo(nameof(CardDetailsPage), false, navigationParameter);
        }

        private async void OnShare(CardDetailsViewModel cardDetail)
        {
            var text = cardDetail.CardProviderBankName + Environment.NewLine;
            text += "Card Holder Name: " + cardDetail.CardHolderName + Environment.NewLine;
            text += "Card Number: " + cardDetail.CardNumber + Environment.NewLine;
            text += "MM/YY : " + string.Concat(cardDetail.ExpiryMonth, "/", cardDetail.ExpiryYear);

            await Share.Default.RequestAsync(new ShareTextRequest
            {
                Text = text,
                Title = "Card Details"
            });
        }

        private async void OnCopy(string value)
        {
            await ActivityService.CopyToClipBoard(value);
        }

        #endregion

        #region protected

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}

