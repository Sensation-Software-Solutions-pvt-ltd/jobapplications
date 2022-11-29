using System;
using System.Collections.Generic;
using System.Text;

namespace jobapplication.Utility
{
    public class Enums
    {
        public enum StatusCode
        {
            OK = 200,
            Created,
            Accepted,
            BadRequest = 400,
            Unauthorized,
            PaymentRequired,
            Forbidden,
            NotFound,
            InternalError = 500
        }
    }
}
