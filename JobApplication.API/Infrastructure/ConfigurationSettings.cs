using Microsoft.Extensions.Configuration;
using JobApplications.Utility;
using System;

namespace JobApplication.WebAPI.Infrastructure
{
    public static class ConfigurationSettings
    {
        public static void Configure(IConfiguration Configuration)
        {
            AppSettings.ConnectionString = Convert.ToString(Configuration["sqlSettings:dBConnectionString"]);
            AppSettings.JwtKey = Convert.ToString(Configuration["jwtTokenConfig:secret"]);
            AppSettings.JwtIssuer = Convert.ToString(Configuration["jwtTokenConfig:issuer"]);
            AppSettings.JwtAudience = Convert.ToString(Configuration["jwtTokenConfig:audience"]);
            //AppSettings.FireBaseServerKey = Convert.ToString(Configuration["CommonSetting:fireBaseServerKey"]);
            //AppSettings.AdminEmailAddress= Convert.ToString(Configuration["AdminEmailAddress"]);

            //EmailSettings.From = Convert.ToString(Configuration["EmailSettings:From"]);
            //EmailSettings.FromName = Convert.ToString(Configuration["EmailSettings:FromName"]);
            //EmailSettings.SendGridKey = Convert.ToString(Configuration["EmailSettings:SendGridKey"]);
            //EmailSettings.FromSMTP = Convert.ToString(Configuration["EmailSettingsSMTP:FromSMTP"]);
            //EmailSettings.FromNameSMTP = Convert.ToString(Configuration["EmailSettingsSMTP:FromNameSMTP"]);
            //EmailSettings.Password = Convert.ToString(Configuration["EmailSettingsSMTP:Password"]);
            //EmailSettings.Host = Convert.ToString(Configuration["EmailSettingsSMTP:Host"]);
            //EmailSettings.IsSMTP = Convert.ToBoolean(Configuration["IsSMTP"]);
        }
    }
}
