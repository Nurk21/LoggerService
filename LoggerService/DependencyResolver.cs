using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerService
{
    public static class DependencyResolver
    {
        public static void Resolve(IServiceCollection services, IConfiguration configuration)
        {
            var appSettingSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingSection);
            services.AddMemoryCache();
            services.AddRouting();
            Repositories(services);
            Services(services);
            Validators(services);
        }


        private static void Validators(IServiceCollection services)
        {
            services.AddScoped<IClientPaymentDataValidator, ClientPaymentDataValidator>();

        }

        private static void Services(IServiceCollection services)
        {
            services.AddScoped<IClientPaymentDataService, ClientPaymentDataService>();
            services.AddScoped<IOschadPaymentService, OschadPaymentService>();
            services.AddScoped<ICryptographyService, CryptographyService>();
            services.AddScoped<IPutSuccessPaymentRecordThroughWINTService, PutSuccessPaymentRecordThroughWINTService>();
            services.AddScoped<IGetDataFromDBThroughWINTService, GetDataFromDBThroughWINTService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            services.AddHttpClient();
        }

        private static void Repositories(IServiceCollection services)
        {
        }

    }
}
