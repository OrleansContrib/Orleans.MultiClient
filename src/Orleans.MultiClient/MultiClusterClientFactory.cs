using Orleans.Runtime;
using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace Orleans.MultiClient
{
    public class MultiClusterClientFactory : IClusterClientFactory
    {
        private readonly ConcurrentDictionary<string, IGrainFactory> clusterClientCache = new ConcurrentDictionary<string, IGrainFactory>();
        private readonly IServiceProvider _serviceProvider;
        public MultiClusterClientFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IGrainFactory Create<TGrainInterface>()
        {
           return this.Create(typeof(TGrainInterface).Assembly);
        }

        public IGrainFactory Create(Type type)
        {
            return this.Create(type.Assembly);
        }

        public IGrainFactory Create(Assembly assembly)
        {
            var name = assembly.FullName;
            return clusterClientCache.GetOrAdd(name, (key) =>
            {
                IClusterClient client = this._serviceProvider.GetRequiredServiceByName<IClusterClientBuilder>(key).Build();
                if (client.IsInitialized)
                {
                    return client;
                }
                else
                {
                    throw new Exception("Can not initialized clusterClient");
                }
            });
        }
    }
}
