using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplications.Utility
{
    public static class AppSettings
    {
        public static string ConnectionString { get; set; }
        public static string JwtKey { get; set; }
        public static string JwtIssuer { get; set; }
        public static string JwtAudience { get; set; }
        public static string SiteUrl { get; set; }
        public static string RootFolderName { get; set; }
        public static string UploadFolderPath { get; set; }
        public static string FireBaseServerKey { get; set; }
        public static string AdminEmailAddress { get; set; }
    }
}
