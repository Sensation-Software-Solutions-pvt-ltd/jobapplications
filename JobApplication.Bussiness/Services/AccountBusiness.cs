using jobapplication.Utility;
using JobApplications.Bussiness.Interfaces;
using JobApplications.Domain.GenericModel;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using JobApplications.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static jobapplication.Utility.Enums;
using Microsoft.AspNetCore.StaticFiles;

namespace JobApplications.Bussiness.Services
{
    public class AccountBusiness : IAccountBusiness
    {
        private readonly ICommonService _commonService;
        private readonly IHostingEnvironment _env;
        public AccountBusiness(ICommonService commonService, IHostingEnvironment env)
        {
            _commonService = commonService;
            _env = env;
        }

    
        public async Task<ResponseModel> ApplyForJob(string JsonData, string Backend)
        {
            ResponseModel response = new ResponseModel();

            var result = await _commonService.ExecuteProcedureAsync(StoredProcedure.SP_ApplyForJob, JsonData, Backend);
            var Response = JsonConvert.DeserializeObject<AddUpdateResponseModel>(result);
            response.ResponseCode = Response.StatusCode;
            response.Message = Response.Message;
            return response;
        }

        public async Task<ResponseModel> DeleteJob(string FrontendJson, string BackendJson)
        {
            ResponseModel response = new ResponseModel();
            var result = await _commonService.ExecuteProcedureAsync(StoredProcedure.SP_DeleteJob, FrontendJson, BackendJson);
            if (result != null)
            {
                var data = JsonConvert.DeserializeObject<AddUpdateResponseModel>(result);
                response.ResponseCode = data.StatusCode;
                response.Message = data.Message;
            }
            else
            {
                response.ResponseCode = (int)StatusCode.NotFound;
                response.Message = "No record found.";
            }
            return response;
        }
        public async Task<ResponseModel> DownloadResume(string FrontendJson, string BackendJson)
        {
         
            ResponseModel response = new ResponseModel();
            try
            {
                var result = await _commonService.ExecuteProcedureAsync(StoredProcedure.SP_DownloadResume, FrontendJson, BackendJson);
                if (result != null)
                {
                    var data = JsonConvert.DeserializeObject<ResponseModel>(result);
                    response.ResponseCode = data.ResponseCode;
                    response.Message = data.Message;
                    string envPath = _env.WebRootPath;
                    string filePath = envPath + "/Uploads/" + data.Response;
                    response.Response = filePath;
                }
                else
                {
                    response.ResponseCode = (int)StatusCode.NotFound;
                    response.Message = "No record found.";
                }
            }
            catch(Exception ex)
            {

            }
            return response;
        }

        public async Task<ResponseModel> GetResumeList()
        {

             ResponseModel response = new ResponseModel();

            var result = await _commonService.ExecuteProcedureAsync(StoredProcedure.SP_GetResumeList, null, null);
            if (result != null)
            {
                var data = JsonConvert.DeserializeObject<ResponseModel>(result);
                response.ResponseCode = data.ResponseCode;
                response.Message = data.Message;
                response.Response = data.Response;
            }
            else
            {
                response.ResponseCode = (int)StatusCode.NotFound;
                response.Message = "No record found.";
            }
            return response;
        }





    }
}
