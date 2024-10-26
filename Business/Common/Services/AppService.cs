namespace MAUITest.Business.Common.Services
{
    public static class AppService
    {
        private static IServiceProvider _serviceProvider;
        public static IServiceProvider ServiceProvider => _serviceProvider ?? throw new Exception("Service provider has not been initialized");

        public static void RegisterServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}

