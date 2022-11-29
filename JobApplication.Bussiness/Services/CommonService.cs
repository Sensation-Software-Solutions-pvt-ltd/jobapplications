using JobApplications.Bussiness.Interfaces;
using JobApplications.Repostory.Infrastructure.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobApplications.Bussiness.Services
{
    public class CommonService : ICommonService
    {
        private readonly IDBRepository _dbRepository;
        private readonly IHttpContextAccessor _httpContextFactory;
        public CommonService(IDBRepository dbRepository, IHttpContextAccessor httpContext)
        {
            this._dbRepository = dbRepository;
            this._httpContextFactory = httpContext;
        }

        public async Task<string> ExecuteProcedureAsync(string procedurename, string frontEndJson = "[]", string backEndJson = "[]")
        {
            return await _dbRepository.ExecuteProcedureAsync(procedurename, frontEndJson, backEndJson);
        }

        public string GetBaseUrl()
        {
            string baseUrl = string.Format("{0}://{1}{2}", _httpContextFactory.HttpContext.Request.Scheme, _httpContextFactory.HttpContext.Request.Host, _httpContextFactory.HttpContext.Request.PathBase);
            return baseUrl;
        }
    }


}
