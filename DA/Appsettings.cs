using Microsoft.Extensions.Configuration;
using System.IO;

namespace DA
{
    public class Appsettings
    {
        public IConfiguration Configuration { get; }

        public Appsettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public string GetConnectionString(string name)
        {
            string config = Configuration.GetConnectionString(name);
            return config;
        }
    }
}
