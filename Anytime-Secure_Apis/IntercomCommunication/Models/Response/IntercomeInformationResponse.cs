using System;
using System.Collections.Generic;
using System.Text;

namespace IntercomCommunication.Models.Response
{
    public class IntercomeInformationResponse
    {
        public string firmware_version { get; set; }
        public string api_version { get; set; }
        public string framework_version { get; set; }
        public string frontend_version { get; set; }
        public string device_type { get; set; }
        public string device_model { get; set; }
        public string device_name { get; set; }
        public string device_serial_number { get; set; }
    }

}
