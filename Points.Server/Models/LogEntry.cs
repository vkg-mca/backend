using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points.Server.Models
{
    public class LogEntry
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }=DateTime.UtcNow ;
        public Dictionary<string, string> Context { get; set; }
        public LogEntry Inner { get; set; }

    }
}
