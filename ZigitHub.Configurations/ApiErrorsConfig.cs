using System.Collections.Generic;

namespace ZigitHub.Configurations
{
    public class ApiErrorsConfig
    {
        public Dictionary<string, string> DefaultErrorMessagesByStatusCode { get; set; }
        public string DefaultErrorMessage { get; set; }
    }
}
