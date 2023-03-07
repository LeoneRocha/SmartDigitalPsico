using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Business.Principals;
using SmartDigitalPsico.Business.SystemDomains;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Contract.SystemDomains;
using SmartDigitalPsico.Repository.FileManager;
using SmartDigitalPsico.Repository.Principals;
using SmartDigitalPsico.Repository.SystemDomains;
using SmartDigitalPsico.Services.Contracts.Principals;
using SmartDigitalPsico.Services.Contracts.SystemDomains;
using SmartDigitalPsico.Services.Principals;
using SmartDigitalPsico.Services.SystemDomains;

namespace SmartDigitalPsico.WebAPI.Helper
{
    public static class DependenciesInjectionHelper
    {

        public static void AddDependenciesInjection(IServiceCollection services)
        {
            addRepositories(services);
            addBusiness(services);
            addServices(services);
            addDependencies(services);
        }

        #region INTERFACES
        private static void addRepositories(IServiceCollection services)
        {
            services.AddScoped<IRepositoryFileDisk, RepositoryFileDisk>();

            //services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMedicalRepository, MedicalRepository>();

            services.AddScoped<IPatientFileRepository, PatientFileRepository>();
            services.AddScoped<IMedicalFileRepository, MedicalFileRepository>();

            #region PATIENT
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientRecordRepository, PatientRecordRepository>();
            services.AddScoped<IPatientMedicationInformationRepository, PatientMedicationInformationRepository>();
            services.AddScoped<IPatientHospitalizationInformationRepository, PatientHospitalizationInformationRepository>();
            services.AddScoped<IPatientAdditionalInformationRepository, PatientAdditionalInformationRepository>();
            services.AddScoped<IPatientNotificationMessageRepository, PatientNotificationMessageRepository>();
            #endregion PATIENT

            services.AddScoped<IApplicationLanguageRepository, ApplicationLanguageRepository>();
            services.AddScoped<IApplicationConfigSettingRepository, ApplicationConfigSettingRepository>();

            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IOfficeRepository, OfficeRepository>();
            services.AddScoped<IRoleGroupRepository, RoleGroupRepository>();
            services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();

        }
        private static void addBusiness(IServiceCollection services)
        {
            services.AddScoped<IApplicationLanguageBusiness, ApplicationLanguageBusiness>();
            services.AddScoped<IApplicationConfigSettingBusiness, ApplicationConfigSettingBusiness>();

            services.AddScoped<IOfficeBusiness, OfficeBusiness>();
            services.AddScoped<IRoleGroupBusiness, RoleGroupBusiness>();
            services.AddScoped<IGenderBusiness, GenderBusiness>();
            services.AddScoped<ISpecialtyBusiness, SpecialtyBusiness>();

            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IMedicalBusiness, MedicalBusiness>();

            services.AddScoped<IPatientFileBusiness, PatientFileBusiness>();
            services.AddScoped<IMedicalFileBusiness, MedicalFileBusiness>();

            #region PATIENT
            services.AddScoped<IPatientBusiness, PatientBusiness>();
            services.AddScoped<IPatientRecordBusiness, PatientRecordBusiness>();
            services.AddScoped<IPatientMedicationInformationBusiness, PatientMedicationInformationBusiness>();
            services.AddScoped<IPatientHospitalizationInformationBusiness, PatientHospitalizationInformationBusiness>();
            services.AddScoped<IPatientAdditionalInformationBusiness, PatientAdditionalInformationBusiness>();
            services.AddScoped<IPatientNotificationMessageBusiness, PatientNotificationMessageBusiness>();
            #endregion PATIENT 
        }

        private static void addServices(IServiceCollection services)
        {
            services.AddScoped<IApplicationLanguageServices, ApplicationLanguageServices>();
            services.AddScoped<IApplicationConfigSettingServices, ApplicationConfigSettingServices>();

            services.AddScoped<IGenderServices, GenderServices>();
            services.AddScoped<IOfficeServices, OfficeServices>();
            services.AddScoped<IRoleGroupServices, RoleGroupServices>();
            services.AddScoped<ISpecialtyServices, SpecialtyServices>();

            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IMedicalServices, MedicalServices>();

            services.AddScoped<IPatientFileServices, PatientFileServices>();
            services.AddScoped<IMedicalFileServices, MedicalFileServices>();
            #region PATIENT
            services.AddScoped<IPatientServices, PatientServices>();
            services.AddScoped<IPatientRecordServices, PatientRecordServices>();
            services.AddScoped<IPatientMedicationInformationServices, PatientMedicationInformationServices>();
            services.AddScoped<IPatientHospitalizationInformationServices, PatientHospitalizationInformationServices>();
            services.AddScoped<IPatientAdditionalInformationServices, PatientAdditionalInformationServices>();
            services.AddScoped<IPatientNotificationMessageServices, PatientNotificationMessageServices>();
            #endregion PATIENT
        }

        private static void addDependencies(IServiceCollection services)
        {
            // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        #endregion
    }
}
