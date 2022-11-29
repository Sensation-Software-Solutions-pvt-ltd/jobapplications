using JobApplications.Repostory.Infrastructure.Interface;
using JobApplications.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobApplications.Repostory.Infrastructure
{
    public class DBRepository : IDBRepository
    {
        string _connectionString = AppSettings.ConnectionString;

        public async Task<string> ExecuteProcedureAsync(string procedurename, string frontEndJson, string backEndJson)
        {
            try
            {
                DBHandler dbHandler = new DBHandler();
                var result = await dbHandler.SP_ExecuteAsync(frontEndJson, backEndJson, procedurename);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
