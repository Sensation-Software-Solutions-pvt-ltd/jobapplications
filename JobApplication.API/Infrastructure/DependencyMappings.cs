using JobApplications.Bussiness.Interfaces;
using JobApplications.Bussiness.Services;
using JobApplications.Repostory.Infrastructure;
using JobApplications.Repostory.Infrastructure.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplicationsAPI.Infrastructure
{
    public static class DependencyMappings
    {
        public static void DependencySetting(this IServiceCollection services)
        {
            services.AddTransient<ICommonService, CommonService>();
            services.AddTransient<IAccountBusiness, AccountBusiness>();
            services.AddTransient<IDBRepository, DBRepository>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
