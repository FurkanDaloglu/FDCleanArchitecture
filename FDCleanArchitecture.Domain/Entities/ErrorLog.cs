using FDCleanArchitecture.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDCleanArchitecture.Domain.Entities
{
    public sealed class ErrorLog:Entity
    {
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
        public string RequestPath { get; set; }
        public string RequestMethod { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
