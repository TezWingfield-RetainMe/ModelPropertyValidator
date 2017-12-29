using System.Collections.Generic;

namespace ModelValidatorDemo.API.Models
{
    public sealed class Response
    {
        public int StatusCode { get; set; }
        public Dictionary<string, string> Messages { get; set; }
    }
}