using System;
using MAUITest.Business.Models.ViewModels;
using MAUITest.Data.Models;

namespace MAUITest.Business.Services.BankDetails
{
	public interface IBankDetailService
	{
		Task<List<BankDetailsViewModel>> GetList();
		Task<BankDetailsViewModel> Get(string bankDetailsId);
		Task AddBankDetails(BankDetailsDataModel bankDetails);
		Task UpdateBankDetails(BankDetailsDataModel bankDetails);
    }
}

