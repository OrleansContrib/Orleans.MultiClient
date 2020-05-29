using System;
using System.Reflection;

namespace Orleans.MultiClient
{
    public interface IClusterClientFactory
    {
        IGrainFactory Create<TGrainInterface>();

        IGrainFactory Create(Type type);

        IGrainFactory Create(Assembly assembly);
    }
}
