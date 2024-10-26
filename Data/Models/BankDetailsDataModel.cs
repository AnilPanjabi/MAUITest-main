using System.ComponentModel.DataAnnotations;

namespace MAUITest.Data.Models
{
    /// <summary>
    /// Class BankDetailsDataModel
    /// </summary>
	public class BankDetailsDataModel
    {
        /// <summary>
        /// Bank detail id
        /// </summary>
        [Key]
        public required string BankDetailId { get; set; }

        /// <summary>
        /// Bank name
        /// </summary>
        public required string BankName { get; set; }

        /// <summary>
        /// Account holder name
        /// </summary>
        public required string AccountHolderName { get; set; }

        /// <summary>
        /// Account number
        /// </summary>
        public required string AccountNumber { get; set; }

        /// <summary>
        /// IFSC Code
        /// </summary>
        public required string IFSCCode { get; set; }
    }
}

