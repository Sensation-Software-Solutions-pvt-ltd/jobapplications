using JobApplications.Bussiness.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JobApplications.Domain.GenericModel;
using Newtonsoft.Json;
using jobapplication.Utility;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace JobApplications.API.Controllers
{
    //[Authorize]
    [Route("JobApplications")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountBusiness _accountBusiness;
        private readonly ICommonService _commonService;
        private readonly IHostingEnvironment _env;


        public AccountController(IAccountBusiness accountBusiness, ICommonService commonService, IHostingEnvironment env)
        {
            _accountBusiness = accountBusiness;
            _commonService = commonService;
            _env = env;

        }


        [Route("ApplyForJob")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<ResponseModel> ApplyForJob([FromForm] JobApplyModel uploadData)
        {
            ResponseModel response = new ResponseModel();

            string envPath = _env.WebRootPath;

            if (uploadData.File != null)
            {
                string fileExtension = System.IO.Path.GetExtension(uploadData.File.FileName);
                string fileName = Path.GetFileNameWithoutExtension(uploadData.File.FileName);
                string folderName = "/Uploads/";
                string fullFileName = fileName + fileExtension;

                string newPath = envPath + folderName;
                string fullPath = Path.Combine(newPath, fullFileName);
                string imagePathAndName = fullPath;

                SaveJobDataModel SaveJobDataModel = new SaveJobDataModel()
                {
                    FirstName = uploadData.FirstName,
                    LastName = uploadData.LastName,
                    JobId = uploadData.JobId,
                    DOB = uploadData.DOB,
                    BirthPlace = uploadData.BirthPlace,
                    EmailId = uploadData.EmailId,
                    DocumentBytes = fullFileName

                };

                var FrontendJson = JsonConvert.SerializeObject(SaveJobDataModel);
                var result = await _accountBusiness.ApplyForJob(FrontendJson, null);
                if(result.ResponseCode == 200)
                {
                    response.ResponseCode = result.ResponseCode;
                    response.Message = result.Message;

                    if (!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);
                    }
                    using (var stream = new FileStream(imagePathAndName, FileMode.Create))
                    {
                        try
                        {
                            uploadData.File.CopyTo(stream);
                            stream.Close();

                        }
                        catch (Exception ex)
                        {
                            response.Error = ex;
                            response.Message = ErrorMessages.SomethingWrong;
                        }
                    }
                }

            }

            return response;
        

        }

        [Route("DeleteJob")]
        [HttpGet]
        public async Task<IActionResult> DeleteJob(string resumeId)
        {
            var FrontendJson = JsonConvert.SerializeObject(new { ResumeId = resumeId });
            var BackendJson = JsonConvert.SerializeObject(new { RequestedBy = "[]" });
            var result = await _accountBusiness.DeleteJob(FrontendJson, BackendJson);
            return Ok(result);
        }

        [AllowAnonymous]
        [Route("DownloadResume")]
        [HttpGet]
        public async Task<ResponseModel> DownloadResume(string resumeId)
        {
            var FrontendJson = JsonConvert.SerializeObject(new { ResumeId = resumeId});
            var BackendJson = JsonConvert.SerializeObject(new { RequestedBy = "[]" });
            var result = await _accountBusiness.DownloadResume(FrontendJson, BackendJson);
            return result;
        }

        [AllowAnonymous]
        [Route("GetResumeList")]
        [HttpGet]
        public async Task<ResponseModel> GetResumeList()
        {
            var result = await _accountBusiness.GetResumeList();
            return result;
        }


    }
}
