using FileUpload.Contract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.AppServices
{
    public static class AppServicesRegister
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddTransient<IFileStorage, LocalFileStorage>();
            services.AddTransient<IFileUploadService, FileUploadService>();

            return services;
        }
    }
}
