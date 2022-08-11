using System;
using System.Collections.Generic;
using System.Text;

namespace IntercomCommunication.Models.Response
{
    public class GetDeviceTime
    {
        public string device_time_unix { get; set; }
        public string device_timezone { get; set; }
    }
}
