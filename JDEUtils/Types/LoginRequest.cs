using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDEUtils.Types
{
    public class LoginRequest
    {
        public LoginRequest(string username, string password, string deviceName, string environment, string role)
        {
            this.username = username;
            this.password = password;
            this.deviceName = deviceName;
            this.environment = environment;
            this.role = role;
        }
        public string username { get; set; }
        public string password { get; set; }
        public string deviceName { get; set; }
        public string environment { get; set; }
        public string role { get; set; }
    }
}
