using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppConcept.Domains
{
    public class ApplicationSettings
    {
        public ApplicationSettings(IConfiguration configuration)
        {
            configuration.Bind(this);
            DefaultConnectionString = configuration.GetConnectionString("default");
        }
        public string DefaultConnectionString { get; set; }
        public IDictionary<string, EncryptionKey> EncryptionKeys { get; set; }
    }
}
