using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0102
{
    [ServiceDefinitionMarker]
    public interface IConfigurationSerializationFilePathProvider : IServiceDefinition
    {
        Task<string> GetServiceCollectionSerializationFilePath();
    }
}
