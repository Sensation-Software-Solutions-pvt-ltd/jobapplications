using System;
using System.Collections.Generic;
using System.Text;

namespace JobApplications.Domain.GenericModel
{
   public class AddUpdateResponseModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string userId { get; set; }

        public string Result { get; set; }

        public string Email { get; set; }
        public string Name { get; set; }
    }

}
