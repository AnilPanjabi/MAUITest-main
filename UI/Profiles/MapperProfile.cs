using AutoMapper;
using MAUITest.Business.Models.ViewModels;
using MAUITest.Data.Models;

namespace MAUITest.UI.Profiles
{
    public class MapperProfile : Profile
    {
		public MapperProfile()
		{
			_ = CreateMap<BankDetailsDataModel, BankDetailsViewModel>().ReverseMap();

		}
	}
}

