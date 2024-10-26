namespace MAUITest.Business.Models.ViewModels
{
    public class CardDetailsViewModel
	{
        /// <summary>
        /// Card detail id
        /// </summary>
        public string CardDetailId
        {
            get { return _cardDetailId; }
            set { _cardDetailId = value; }
        }
        private string _cardDetailId = string.Empty;

        /// <summary>
        /// Card Type
        /// </summary>
        public string CardType
        {
            get { return _cardType; }
            set { _cardType = value; }
        }
        private string _cardType = string.Empty;

        /// <summary>
        /// Card Provider Bank name
        /// </summary>
        public string CardProviderBankName
        {
            get { return _cardProviderBankName; }
            set { _cardProviderBankName = value; }
        }
        private string _cardProviderBankName = string.Empty;

        /// <summary>
        /// Card holder name
        /// </summary>
        public string CardHolderName
        {
            get { return _cardHolderName; }
            set { _cardHolderName = value; }
        }
        private string _cardHolderName = string.Empty;

        /// <summary>
        /// Card number
        /// </summary>
        public string CardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }
        private string _cardNumber = string.Empty;

        /// <summary>
        /// ExpiryMonth
        /// </summary>
        public int ExpiryMonth
        {
            get { return _expiryMonth; }
            set { _expiryMonth = value; }
        }
        private int _expiryMonth;

        /// <summary>
        /// ExpiryYear
        /// </summary>
        public int ExpiryYear
        {
            get { return _expiryYear; }
            set { _expiryYear = value; }
        }
        private int _expiryYear;

        /// <summary>
        /// CVV Code
        /// </summary>
        public string CVVCode
        {
            get { return _cvvCode; }
            set { _cvvCode = value; }
        }
        private string _cvvCode = string.Empty;

    }
}

