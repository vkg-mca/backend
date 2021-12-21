using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points.Server.Models
{
    public class ArgumentCode
    {
        public const string InvalidArgumet="ARG1.1";
        public const string InvalidArgumetRange = "ARG1.2";
    }

    public class SecurityCode
    {
        public const string FailedAuthntication = "SEC1.1";
        public const string FailedAuthorization = "SEC.2";
    }

    public class ServerCode
    {
        public const string InternalServerError = "ISE1.1";
    }
}
