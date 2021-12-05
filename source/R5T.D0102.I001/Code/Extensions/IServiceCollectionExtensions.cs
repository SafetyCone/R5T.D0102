using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.D0048;
using R5T.T0063;


namespace R5T.D0102.I001
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ConfigurationAuditSerializer"/> implementation of <see cref="IConfigurationAuditSerializer"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddConfigurationAuditSerializer(this IServiceCollection services,
            IServiceAction<IConfiguration> configurationAction,
            IServiceAction<IConfigurationSerializationFilePathProvider> configurationSerializationFilePathProviderAction)
        {
            services
                .Run(configurationAction)
                .Run(configurationSerializationFilePathProviderAction)
                .AddSingleton<IConfigurationAuditSerializer, ConfigurationAuditSerializer>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ConfigurationSerializationFilePathProvider"/> implementation of <see cref="IConfigurationSerializationFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddConfigurationSerializationFilePathProvider(this IServiceCollection services,
            IServiceAction<IConfigurationSerializationFileNameProvider> configurationSerializationFileNameProviderAction,
            IServiceAction<IOutputFilePathProvider> outputFilePathProviderAction)
        {
            services
                .Run(configurationSerializationFileNameProviderAction)
                .Run(outputFilePathProviderAction)
                .AddSingleton<IConfigurationSerializationFilePathProvider, ConfigurationSerializationFilePathProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ConstructorBasedConfigurationSerializationFileNameProvider"/> implementation of <see cref="IConfigurationSerializationFileNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddConstructorBasedConfigurationSerializationFileNameProvider(this IServiceCollection services,
            string configurationSerializationFileName)
        {
            services.AddSingleton<IConfigurationSerializationFileNameProvider>(_ => new ConstructorBasedConfigurationSerializationFileNameProvider(
                configurationSerializationFileName));

            return services;
        }
    }
}