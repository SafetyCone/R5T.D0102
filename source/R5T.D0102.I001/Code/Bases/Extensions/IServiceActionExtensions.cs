using System;

using Microsoft.Extensions.Configuration;

using R5T.D0048;
using R5T.T0062;
using R5T.T0063;


namespace R5T.D0102.I001
{
    public static class IServiceActionExtensions
    {
        /// <summary>       
        /// Adds the <see cref="ConfigurationAuditSerializer"/> implementation of <see cref="IConfigurationAuditSerializer "/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IConfigurationAuditSerializer> AddConfigurationAuditSerializerAction(this IServiceAction _,
            IServiceAction<IConfiguration> configurationAction,
            IServiceAction<IConfigurationSerializationFilePathProvider> configurationSerializationFilePathProviderAction)
        {
            var serviceAction = _.New<IConfigurationAuditSerializer>(services => services.AddConfigurationAuditSerializer(
                configurationAction,
                configurationSerializationFilePathProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ConfigurationSerializationFilePathProvider"/> implementation of <see cref="IConfigurationSerializationFilePathProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IConfigurationSerializationFilePathProvider> AddConfigurationSerializationFilePathProviderAction(this IServiceAction _,
            IServiceAction<IConfigurationSerializationFileNameProvider> configurationSerializationFileNameProviderAction,
            IServiceAction<IOutputFilePathProvider> outputFilePathProviderAction)
        {
            var serviceAction = _.New<IConfigurationSerializationFilePathProvider>(services => services.AddConfigurationSerializationFilePathProvider(
                configurationSerializationFileNameProviderAction,
                outputFilePathProviderAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ConstructorBasedConfigurationSerializationFileNameProvider"/> implementation of <see cref="IConfigurationSerializationFileNameProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IConfigurationSerializationFileNameProvider> AddConstructorBasedConfigurationSerializationFileNameProviderAction(this IServiceAction _,
            string configurationSerializationFileName)
        {
            var serviceAction = _.New<IConfigurationSerializationFileNameProvider>(services => services.AddConstructorBasedConfigurationSerializationFileNameProvider(
                configurationSerializationFileName));

            return serviceAction;
        }
    }
}
