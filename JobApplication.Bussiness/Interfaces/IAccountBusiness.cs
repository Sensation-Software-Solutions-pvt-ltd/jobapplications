using JobApplications.Domain.GenericModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace JobApplications.Bussiness.Interfaces
{
    public interface IAccountBusiness
    {
        //ApplyJob
        Task<ResponseModel> ApplyForJob(string JsonData, string Backend);
        //DeleteJob
        Task<ResponseModel> DeleteJob(string JsonData, string Backend);
        //DownloadFile
        Task<ResponseModel> DownloadResume(string JsonData, string Backend);
        //GetResumeList
        Task<ResponseModel> GetResumeList();




    }
}
