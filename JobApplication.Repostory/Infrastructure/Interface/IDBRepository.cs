using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobApplications.Repostory.Infrastructure.Interface
{
   public interface IDBRepository
    {
        Task<string> ExecuteProcedureAsync(string procedurename, string frontEndJson, string backEndJson);

    }
}
