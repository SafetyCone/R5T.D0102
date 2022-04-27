using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0102
{
    [ServiceImplementationMarker]
    public class ConstructorBasedConfigurationSerializationFileNameProvider : IConfigurationSerializationFileNameProvider, IServiceImplementation
    {
        private string ConfigurationSerializationFileName { get; }


        public ConstructorBasedConfigurationSerializationFileNameProvider(
            [NotServiceComponent] string configurationSerializationFileName)
        {
            this.ConfigurationSerializationFileName = configurationSerializationFileName;
        }

        public Task<string> GetConfigurationSerializationFileName()
        {
            return Task.FromResult(this.ConfigurationSerializationFileName);
        }
    }
}
