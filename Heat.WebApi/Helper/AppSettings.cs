using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heat.WebApi.Helper
{
    public class AppSettings
    {
        public string SecretKey { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
    }
}