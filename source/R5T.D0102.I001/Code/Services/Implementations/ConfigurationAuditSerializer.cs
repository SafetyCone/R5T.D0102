using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using R5T.L0015.X001;using R5T.T0064;


namespace R5T.D0102.I001
{[ServiceImplementationMarker]
    public class ConfigurationAuditSerializer : IConfigurationAuditSerializer,IServiceImplementation
    {
        private IConfiguration Configuration { get; }
        private IConfigurationSerializationFilePathProvider ConfigurationSerializationFilePathProvider { get; }


        public ConfigurationAuditSerializer(
            IConfiguration configuration,
            IConfigurationSerializationFilePathProvider configurationSerializationFilePathProvider)
        {
            this.Configuration = configuration;
            this.ConfigurationSerializationFilePathProvider = configurationSerializationFilePathProvider;
        }

        public async Task SerializeConfiguration()
        {
            var configurationSerialiationFilePath = await this.ConfigurationSerializationFilePathProvider.GetServiceCollectionSerializationFilePath();

            FileHelper.EnsureDirectoryForFilePathExists(configurationSerialiationFilePath);

            await this.Configuration.DescribeToTextFile(configurationSerialiationFilePath);
        }
    }
}
