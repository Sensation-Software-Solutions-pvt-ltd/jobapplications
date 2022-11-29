using Dapper;
using JobApplications.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplications.Repostory
{
    public class DBHandler
    {
        string _connectionString = AppSettings.ConnectionString;
        public async Task<string> SP_ExecuteAsync(string frontEndJson, string backEndJson, string query_spName, CommandType? commandType = CommandType.StoredProcedure)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    try
                    {
                        con.Open();
                        var param = new DynamicParameters();
                        param.Add("@FrontEndInputJson", frontEndJson);
                        param.Add("@BackEndInputJson", backEndJson);
                        var result = await con.QueryAsync<string>(query_spName, param, commandType: commandType);
                        con.Close();
                        return result.FirstOrDefault();
                    }
                    finally
                    {
                        con.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
                //return new { Message= ErrorMessages.SomethingWentWrong ,StatusCode= (int)Enums.StatusCode.InternalError }.ToString();
            }
        }
    }
}
