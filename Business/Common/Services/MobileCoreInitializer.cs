

namespace MAUITest.Business.Common.Services
{
    /// <summary>
    /// MauiApp Core builder 
    /// Using MAUI Builder Initializer
    /// </summary>
	public class MobileCoreInitializer : IMauiInitializeService
    {
        /// <summary>
        /// Using the Initialize to register service provider
        /// </summary>
        /// <param name="serviceProvider"></param>
        public void Initialize(IServiceProvider serviceProvider)
        {
            AppService.RegisterServiceProvider(serviceProvider);
            //AppDomain.CurrentDomain.UnhandledException += serviceProvider.GetRequiredService<IExceptionHandler<MobileCoreInitializer>>().OnUnhandledException;
        }
    }
}

