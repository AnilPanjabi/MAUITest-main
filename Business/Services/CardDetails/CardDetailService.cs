using System;
using AutoMapper;
using MAUITest.Business.Models.ViewModels;
using MAUITest.Data;
using MAUITest.Data.Models;

namespace MAUITest.Business.Services.CardDetails
{
	public class CardDetailService : ICardDetailService
    {

        private readonly IRepository<CardDetailsDataModel> _repository;
        private readonly IMapper _mapper;

        public CardDetailService(IRepository<CardDetailsDataModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CardDetailsViewModel> Get(string bankDetailsId)
        {
            var bankDetailsDataModel = await _repository.GetByIdAsync(bankDetailsId);
            var bankDetailsViewModel = _mapper.Map<CardDetailsViewModel>(bankDetailsDataModel);

            return bankDetailsViewModel;
        }

        public async Task<List<CardDetailsViewModel>> GetList()
        {
            var lstCardDetailsDataModel = await _repository.GetAllAsync();
            var lstCardDetailsViewModel = _mapper.Map<List<CardDetailsViewModel>>(lstCardDetailsDataModel);

            return lstCardDetailsViewModel;
        }

        public async Task AddCardDetails(CardDetailsDataModel bankDetails)
        {
            await _repository.AddAsync(bankDetails);
        }

        public async Task UpdateCardDetails(CardDetailsDataModel bankDetails)
        {
            await _repository.UpdateAsync(bankDetails);
        }
    }
}

