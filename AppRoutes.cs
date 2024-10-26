using System;
using MAUITest.UI.BankDetails;
using MAUITest.UI.CardDetails;

namespace MAUITest
{
	public static  class AppRoutes
	{
        public static void RegisterApplicationRoutes(this Application application)
        {
            Routing.RegisterRoute(nameof(BankDetailsPage), typeof(BankDetailsPage));
            Routing.RegisterRoute(nameof(BankDetailsListPage), typeof(BankDetailsListPage));
            Routing.RegisterRoute(nameof(CardDetailsPage), typeof(CardDetailsPage));
            Routing.RegisterRoute(nameof(CardDetailsListPage), typeof(CardDetailsListPage));

        }
    }
}

