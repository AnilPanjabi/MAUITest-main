using System.Reflection;
using MAUITest.Business.Common.Services;
using MAUITest.Business.Models;
using MAUITest.Business.Services.BankDetails;
using MAUITest.Business.Services.CardDetails;
using MAUITest.Common.Abstractions;
using MAUITest.Common.Helpers;
using MAUITest.Common.Services;
using MAUITest.Data;
using MAUITest.Data.Models;
using MAUITest.Data.Repositories;
using MAUITest.UI;
using MAUITest.UI.BankDetails;
using MAUITest.UI.CardDetails;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AppDependencies
	{
        public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
        {
            //var assembly = Assembly.GetExecutingAssembly();

            //builder.LoadEmbeddedJsonConfig(assembly, Constants.AppSettingsJsonResourcePath);

            builder.Services
                .AddAppServices()
                .InitializeDB()
                .AddAppDataServices()
                .AddAutoMapper(new List<Assembly>()
                {
                    typeof(AppDependencies).GetTypeInfo().Assembly
                });

            return builder;
        }

        private static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddSingleton<IMauiInitializeService, MobileCoreInitializer>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IShellHelper, ShellHelper>();

            services.AddSingleton<IBankDetailService, BankDetailService>();
            services.AddSingleton<ICardDetailService, CardDetailService>();

            services.AddTransient<MainPage>();
            services.AddTransient<BankDetailsPage>();
            services.AddTransient<CardDetailsPage>();

            services.AddTransient<BankDetailsListPage>();
            services.AddTransient<CardDetailsListPage>();

            services.AddTransient<BankDetailsPageViewModel>();
            services.AddTransient<CardDetailsPageViewModel>();

            return services;
        }

        private static IServiceCollection InitializeDB(this IServiceCollection services)
        {

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, Constants.DbName);
            services
            .AddDbContext<AppDbContext>(options =>
              options.UseSqlite($"Filename={dbPath}"));

            // Ensure database is created on startup if it doesn't already exist
            if (!File.Exists(dbPath))
            {
                // Ensure database is created on startup
                var serviceProvider = services.BuildServiceProvider();
                using (var scope = serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    dbContext.Database.EnsureCreated();
                }
            }
            return services;
        }

        private static IServiceCollection AddAppDataServices(this IServiceCollection services)
        {

            //// Add data layer services
            //services.AddSingleton<IMobileDatabaseService, AppDatabaseService>();
            //services.AddSingleton<AppDbContextFactory>();
            //services.AddSingleton<IInspectionContactBusinessModelMapperHelper, InspectionContactBusinessModelMapperHelper>();

            //services.AddSupportCompiledKeyService<InspectionSummaryInfoDataModel, InspectionSummaryInfoDataModel>();

            //// Business Details

            //services.AddSupportCompiledKeyService<InspectionDataModel, InspectionDataModel>();
            //services.AddSupportCompiledKeyService<BusinessLicenseHoursOfOperationDataModel, BusinessLicenseHoursOfOperationDataModel>();
            //services.AddSupportCompiledKeyService<PreviousInspectionInfoDataModel, PreviousInspectionInfoDataModel>();
            //services.AddSupportCompiledKeyService<InspectionContactDataModel, InspectionContactDataModel>();
            //services.AddSupportCompiledKeyService<GlobalEntityDataModel, GlobalEntityDataModel>();
            //services.AddSupportCompiledKeyService<InspectionViolationLibraryInfoDataModel, InspectionViolationLibraryInfoDataModel>();
            //services.AddSupportCompiledKeyService<ViolationItemDataModel, ViolationItemDataModel>();
            //services.AddSupportCompiledKeyService<InspectionHealthViolationCodeRefDataModel, InspectionHealthViolationCodeRefDataModel>();
            //services.AddSupportCompiledKeyService<InspectionNoteDataModel, InspectionNoteDataModel>();
            //services.AddSupportCompiledKeyService<InspectionViolationHistoryDataModel, InspectionViolationHistoryDataModel>();

            //services.AddSupportCompiledKeyService<InspectionViolationHistoryDataModel, InspectionViolationHistoryDataModel>();
            //services.AddSupportCompiledKeyService<InspectionTypeDataModel, InspectionTypeDataModel>();
            //services.AddSupportCompiledKeyService<InspectionTemperatureDataModel, InspectionTemperatureDataModel>();
            //services.AddSupportCompiledKeyService<InspectionStatusDataModel, InspectionStatusDataModel>();
            //services.AddSupportCompiledKeyService<InspectionTimeTrackingDataModel, InspectionTimeTrackingDataModel>();

            // Repositories
            services.AddScoped(typeof(IRepository<BankDetailsDataModel>), typeof(BankDetailsRepository));
            services.AddScoped(typeof(IRepository<CardDetailsDataModel>), typeof(CardDetailsRepository));


            //services.AddMobileRepository<InspectionSummaryInfoRepository, InspectionSummaryInfoDataModel>();
            //services.AddMobileRepository<InspectionRepository, InspectionDataModel, string>();
            //services.AddMobileRepository<BusinessLicenseHoursOfOperationRepository, BusinessLicenseHoursOfOperationDataModel, string>();
            //services.AddMobileRepository<PreviousInspectionRepository, PreviousInspectionInfoDataModel, string>();
            //services.AddMobileRepository<InspectionContactRepository, InspectionContactDataModel, string>();
            //services.AddMobileRepository<GlobalEntityRepository, GlobalEntityDataModel, string>();
            //services.AddMobileRepository<InspectionViolationLibraryInfoDataModelRepository, InspectionViolationLibraryInfoDataModel, string>();
            //services.AddMobileRepository<ViolationsItemRepository, ViolationItemDataModel, string>();
            //services.AddMobileRepository<InspectionHealthViolationCodeRefRepository, InspectionHealthViolationCodeRefDataModel, string>();
            //services.AddMobileRepository<InspectionNoteRepository, InspectionNoteDataModel, string>();
            //services.AddMobileRepository<InspectionViolationHistoryRepository, InspectionViolationHistoryDataModel, InspectionViolationHistoryCompositeKey>();
            //services.AddMobileRepository<InspectionTypeRepository, InspectionTypeDataModel, string>();
            //services.AddMobileRepository<InspectionTemperatureRepository, InspectionTemperatureDataModel, string>();
            //services.AddMobileRepository<InspectionStatusRepository, InspectionStatusDataModel, string>();
            //services.AddMobileRepository<InspectionTimeTrackingRepository, InspectionTimeTrackingDataModel, string>();

            //// ChangeSet service
            //services.AddSingleton<IChangeSetServiceManager<string>, InspectionChangeSetServiceManager>();
            //services.AddSingleton<IChangeSetService<Inspection, InspectionDataModel, InspectionViewModel>, InspectionChangeSetService>();
            //services.AddSingleton<IChangeSetService<InspectionNote, InspectionDataModel, InspectionViewModel>, InternalNoteChangeSetService>();
            //services.AddSingleton<IChangeSetService<InspectionTemperature, InspectionDataModel, InspectionViewModel>, TemperatureChangeSetService>();
            //services.AddSingleton<IChangeSetService<InspectionHealthViolation, InspectionDataModel, InspectionViewModel>, ViolationItemDetailsChangesetService>();
            //services.AddSingleton<IChangeSetService<Tyler.Energov.Mobile.EH.Api.Client.InspectionHealthViolationCodeRef, ViolationItemDataModel, ViolationItemViewModel>, ViolationItemCodeRefChangesetService>();
            //services.AddSingleton<IChangeSetService<Attachment, InspectionDataModel, InspectionViewModel>, AttachmentChangesetService>();

            //// ChangeSet Mapper
            //services.AddSingleton<IChangesetMapper<InspectionViewModel>, InspectionChangeSetMapper>();
            //services.AddSingleton<IChangesetMapper<InspectionNoteViewModel>, InspectionNoteChangeSetMapper>();
            //services.AddSingleton<IChangesetMapper<InspectionTemperatureViewModel>, TemperatureChangeSetMapper>();
            //services.AddSingleton<IChangesetMapper<ViolationItemViewModel>, ViolationItemDetailsChangeSetMapper>();
            //services.AddSingleton<IChangesetMapper<Tyler.Energov.Mobile.EH.Business.Models.Inspections.InspectionHealthViolationCodeRef>, ViolationCodeRefChangeSetMapper>();
            //services.AddSingleton<IChangesetMapper<AttachmentViewModel>, AttachmentChangesetMapper>();

            return services;
        }
    }
}

