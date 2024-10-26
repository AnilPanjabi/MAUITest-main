using System;
using MAUITest.Business.Models.ViewModels;
using MAUITest.Data.Models;
using MAUITest.UI.CardDetails;

namespace MAUITest.Business.Services.CardDetails
{
	public interface ICardDetailService
	{
        Task<List<CardDetailsViewModel>> GetList();
        Task<CardDetailsViewModel> Get(string bankDetailsId);
        Task AddCardDetails(CardDetailsDataModel bankDetails);
        Task UpdateCardDetails(CardDetailsDataModel bankDetails);
    }
}

