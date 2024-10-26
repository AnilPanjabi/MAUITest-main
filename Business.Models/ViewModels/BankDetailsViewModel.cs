using Microsoft.Maui.Controls;
using System;
using System.Windows.Input;

namespace MAUITest.Business.Models.ViewModels
{
    /// <summary>
    /// Bank details view model
    /// </summary>
	public class BankDetailsViewModel
	{
        /// <summary>
        /// Bank detail id
        /// </summary>
        public string BankDetailId
        {
            get { return _bankDetailId; }
            set { _bankDetailId = value; }
        }
        private string _bankDetailId = string.Empty;

        /// <summary>
        /// Bank name
        /// </summary>
        public string BankName
        {
            get { return _bankName; }
            set { _bankName = value; }
        }
        private string _bankName = string.Empty;

        /// <summary>
        /// Account holder name
        /// </summary>
        public string AccountHolderName
        {
            get { return _accountHolderName; }
            set { _accountHolderName = value; }
        }
        private string _accountHolderName = string.Empty;

        /// <summary>
        /// Account number
        /// </summary>
        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }
        private string _accountNumber = string.Empty;

        /// <summary>
        /// IFSC Code
        /// </summary>
        public string IFSCCode
        {
            get { return _ifscCode; }
            set { _ifscCode = value; }
        }
        private string _ifscCode = string.Empty;

        private Command editCommand;
        public ICommand EditCommand => editCommand ??= new Command(Edit);

        private void Edit()
        {
        }
    }
}

