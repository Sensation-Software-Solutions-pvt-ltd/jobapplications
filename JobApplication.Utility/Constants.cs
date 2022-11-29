using System;
using System.Collections.Generic;
using System.Text;

namespace jobapplication.Utility
{
    public static class StoredProcedure
    {
        //Help
        public const string JobApp_HelpForFrontendInput = "JobApp_HelpForFrontendInput";

        //sp_ApplyForJob 
        public const string SP_ApplyForJob = "SP_ApplyForJob";

        //SP_DeleteJob
        public const string SP_DeleteJob = "SP_DeleteJob";
        //SP_DownloadResume
        public const string SP_DownloadResume = "SP_DownloadResume";
        //GetResumeList
        public const string SP_GetResumeList = "SP_GetResumeList";



    }

    public static class CommonMessage
    {

        public const string Help = "help";
    }

    public static class ErrorMessages
    {
        public const string SomethingWrong = "Something Went Wrong Please Try Again Later";
    }

}
