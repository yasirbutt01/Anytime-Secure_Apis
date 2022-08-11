using System;
using System.Collections.Generic;
using System.Text;

namespace IntercomCommunication.Models.Response
{
    public class LoginResponse
    {
        public string token { get; set; }
        public string account_type { get; set; }
    }
}
