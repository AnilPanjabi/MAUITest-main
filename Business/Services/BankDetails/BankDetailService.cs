using System;
using AutoMapper;
using MAUITest.Business.Models.ViewModels;
using MAUITest.Data;
using MAUITest.Data.Models;

namespace MAUITest.Business.Services.BankDetails
{
	public class BankDetailService : IBankDetailService
    {
        private readonly IRepository<BankDetailsDataModel> _repository;
        private readonly IMapper _mapper;

        public BankDetailService(IRepository<BankDetailsDataModel> repository, IMapper mapper)
		{
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BankDetailsViewModel> Get(string bankDetailsId)
        {
            //var bankDetails = new BankDetailsViewModel
            //{
            //    AccountHolderName = "Anil Panjabi",
            //    AccountNumber = "1234567890",
            //    BankDetailId = Guid.NewGuid().ToString(),
            //    BankName = "State Bank Of India",
            //    IFSCCode = "SBIN000222"
            //};

            var bankDetails = (await GetList()).Where(_ => _.BankDetailId == bankDetailsId).FirstOrDefault();

            return bankDetails;

            //var bankDetailsDataModel = await _repository.GetByIdAsync(bankDetailsId);
            //var bankDetailsViewModel = _mapper.Map<BankDetailsViewModel>(bankDetailsDataModel);

            //return bankDetailsViewModel;
        }

        public async Task<List<BankDetailsViewModel>> GetList()
        {
            var listBankDetails = new List<BankDetailsViewModel>
            {
                new BankDetailsViewModel
                {
                    AccountHolderName = "Anil Panjabi",
                    AccountNumber = "1234567890",
                    BankDetailId = "74d50c5a-5ab8-4060-add4-032b4ac001d8",
                    BankName = "State Bank Of India",
                    IFSCCode = "SBIN000222"
                },
                new BankDetailsViewModel
                {
                    AccountHolderName = "Anil Panjabi",
                    AccountNumber = "1234567891",
                    BankDetailId = "2c72135a-c93f-4f8c-bedb-959f9c61a3bf",
                    BankName = "HDFC Bank",
                    IFSCCode = "HDFC000222"
                },
                new BankDetailsViewModel
                {
                    AccountHolderName = "Anil Panjabi",
                    AccountNumber = "1234567892",
                    BankDetailId = "08895632-3711-44cf-8b08-71a21bbff18a",
                    BankName = "Bank Of India",
                    IFSCCode = "BOI000222"
                },
                new BankDetailsViewModel
                {
                    AccountHolderName = "Anil Panjabi",
                    AccountNumber = "1234567893",
                    BankDetailId = "b4cbedde-8df2-4dcc-89ac-263ec9d871da",
                    BankName = "ICICI",
                    IFSCCode = "ICICI00222"
                }
            };
            return listBankDetails;

            //var lstBankDetailsDataModel = await _repository.GetAllAsync();
            //var lstBankDetailsViewModel = _mapper.Map<List<BankDetailsViewModel>>(lstBankDetailsDataModel);

            //return lstBankDetailsViewModel;

        }

        public async Task AddBankDetails(BankDetailsDataModel bankDetails)
        {
            await _repository.AddAsync(bankDetails);
        }

        public async Task UpdateBankDetails(BankDetailsDataModel bankDetails)
        {
            await _repository.UpdateAsync(bankDetails);
        }
    }
}

