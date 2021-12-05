using System;
using System.Threading.Tasks;

using R5T.D0048;
using R5T.T0064;


namespace R5T.D0102.I001
{
    [ServiceImplementationMarker]
    public class ConfigurationSerializationFilePathProvider : IConfigurationSerializationFilePathProvider, IServiceImplementation
    {
        private IConfigurationSerializationFileNameProvider ConfigurationSerializationFileNameProvider { get; }
        private IOutputFilePathProvider OutputFilePathProvider { get; }


        public ConfigurationSerializationFilePathProvider(
            IConfigurationSerializationFileNameProvider configurationSerializationFileNameProvider,
            IOutputFilePathProvider outputFilePathProvider)
        {
            this.ConfigurationSerializationFileNameProvider = configurationSerializationFileNameProvider;
            this.OutputFilePathProvider = outputFilePathProvider;
        }

        public async Task<string> GetServiceCollectionSerializationFilePath()
        {
            var configurationSerializationFileName = await this.ConfigurationSerializationFileNameProvider.GetConfigurationSerializationFileName();

            var output = await this.OutputFilePathProvider.GetOutputFilePath(configurationSerializationFileName);
            return output;
        }
    }
}
