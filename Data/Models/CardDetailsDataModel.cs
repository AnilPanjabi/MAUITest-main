using System;
using System.ComponentModel.DataAnnotations;

namespace MAUITest.Data.Models
{
    /// <summary>
    /// CardDetailsDataModel
    /// </summary>
	public class CardDetailsDataModel
	{
        /// <summary>
        /// Card detail id
        /// </summary>
        [Key]
        public required string CardDetailId { get; set; }

        /// <summary>
        /// Card provider bank name
        /// </summary>
        public required string CardProviderBankName { get; set; }

        /// <summary>
        /// Card type
        /// </summary>
        public required string CardType { get; set; }

        /// <summary>
        /// Card holder name
        /// </summary>
        public required string CardHolderName { get; set; }

        /// <summary>
        /// Card number
        /// </summary>
        public required string CardNumber { get; set; }

        /// <summary>
        /// ExpiryMonth
        /// </summary>
        public required int ExpiryMonth { get; set; }

        /// <summary>
        /// ExpiryYear
        /// </summary>
        public required int ExpiryYear { get; set; }

        /// <summary>
        /// CVV Code
        /// </summary>
        public required string CVVCode { get; set; }
    }
}

