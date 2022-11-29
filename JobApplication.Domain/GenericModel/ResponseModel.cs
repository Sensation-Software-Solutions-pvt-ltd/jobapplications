using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplications.Domain.GenericModel
{
   public  class ResponseModel
    {
        public object Response { get; set; }
        public int ResponseCode { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public int? TotalRecords { get; set; }
        public object Error { get; set; }
        public bool Status { get; set; }
        public string AccessToken { get; set; }
        public string ShiftInTime { get; set; }
    }

    public class JobApplyModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string DOB { get; set; }
        public string BirthPlace { get; set; }
        public int JobId { get; set; }
        public IFormFile File { get; set; }
    }
    public class SaveJobDataModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string DOB { get; set; }
        public string BirthPlace { get; set; }
        public int JobId { get; set; }
        public string DocumentBytes { get; set; }
    }

}
