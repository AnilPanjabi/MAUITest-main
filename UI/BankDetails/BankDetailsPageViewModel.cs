using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MAUITest.Business.Common.Services;
using MAUITest.Business.Models.ViewModels;
using MAUITest.Business.Services.BankDetails;
using MAUITest.Common.Abstractions;
using MAUITest.Data.Models;

namespace MAUITest.UI.BankDetails
{
    public class BankDetailsPageViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// IBankDetailService
        /// </summary>
        private readonly IBankDetailService _bankDetailService;
        private readonly INavigationService _navigationService;

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand ShareCommand { get; set; }
        public ICommand CopyCommand { get; set; }

        public BankDetailsViewModel BankDetail
        {
            get { return _bankDetail; }
            set
            {
                _bankDetail = value;
                OnPropertyChanged();
            }
        }
        private BankDetailsViewModel _bankDetail;


        public ObservableCollection<BankDetailsViewModel> BankDetails
        {
            get { return _bankDetails; }
            set
            {
                _bankDetails = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<BankDetailsViewModel> _bankDetails;

        public string BankDetailsId
        {
            get { return _bankDetailsId; }
            set
            {
                _bankDetailsId = value;
                OnPropertyChanged();
            }
        }
        private string _bankDetailsId;


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
        /// <param name="bankDetailService"></param>
        /// <param name="navigationService"></param>
        public BankDetailsPageViewModel(IBankDetailService bankDetailService, INavigationService navigationService)
        {
            _bankDetailService = bankDetailService;
            _navigationService = navigationService;

            AddCommand = new Command(OnAdd);
            EditCommand = new Command<BankDetailsViewModel>(OnEdit);
            ShareCommand = new Command<BankDetailsViewModel>(OnShare);
            CopyCommand = new Command<string>(OnCopy);
        }

        public async Task OnAppearing()
        {
            await LoadBankDetails();
        }

        public async Task AddBankDetails()
        {
            var bankDetail = new BankDetailsDataModel()
            {
                AccountHolderName = BankDetail.AccountHolderName,
                AccountNumber = BankDetail.AccountNumber,
                BankName = BankDetail.BankName,
                IFSCCode = BankDetail.IFSCCode,
                BankDetailId = string.IsNullOrEmpty(BankDetailsId) ? Guid.NewGuid().ToString() : BankDetailsId
            };
            if(string.IsNullOrEmpty(BankDetailsId))
            {
                await _bankDetailService.AddBankDetails(bankDetail);
            }
            else
            {
                await _bankDetailService.UpdateBankDetails(bankDetail);
            }
        }

        #region Private

        private async Task LoadBankDetails()
        {
            if (IsListForm)
            {
                BankDetails = new ObservableCollection<BankDetailsViewModel>(await _bankDetailService.GetList());
            }
            else
            {
                if (!string.IsNullOrEmpty(BankDetailsId))
                {
                    BankDetail = await _bankDetailService.Get(BankDetailsId);
                }
                else
                {
                    BankDetail = new BankDetailsViewModel();
                }
            }
        }

        private async void OnAdd()
        {
            await _navigationService.NavigateTo(nameof(BankDetailsPage));
        }

        private async void OnEdit(BankDetailsViewModel bankDetail)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                {
                    nameof(BankDetailPageQueryAttributes),
                    new BankDetailPageQueryAttributes() { BankDetailId = bankDetail.BankDetailId }
                }
            };

            await _navigationService.NavigateTo(nameof(BankDetailsPage), false, navigationParameter);
        }

        private async void OnShare(BankDetailsViewModel bankDetail)
        {
            var text = bankDetail.BankName + Environment.NewLine;
            text += "Account Holder Name: " + bankDetail.AccountHolderName + Environment.NewLine;
            text += "Account Number: " + bankDetail.AccountNumber + Environment.NewLine;
            text += "IFSC Code: " + bankDetail.IFSCCode;

            await Share.Default.RequestAsync(new ShareTextRequest
            {
                Text = text,
                Title = "Bank Details"
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

