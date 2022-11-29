
using System.Threading.Tasks;

namespace JobApplications.Bussiness.Interfaces
{
    public interface ICommonService
    {
        string GetBaseUrl();
        Task<string> ExecuteProcedureAsync(string procedurename, string frontEndJson = "[]", string backEndJson = "[]");
    }
}
