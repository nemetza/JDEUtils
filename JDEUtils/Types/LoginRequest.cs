using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDEUtils.Types
{
    public class LoginRequest
    {
        public string username { get; set; }
        public string password { get; set; }
        public string deviceName { get; set; }
        public string environment { get; set; }
        public string role { get; set; }
    }
}
