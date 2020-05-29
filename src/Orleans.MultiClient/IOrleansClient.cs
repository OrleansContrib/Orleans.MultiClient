using Orleans.Runtime;
using Orleans.Streams;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Orleans
{
    /// <summary>
    /// Orleans Client
    /// </summary>
    public interface IOrleansClient
    {
        /// <summary>
        /// get stream provider <see cref="IStreamProvider"/>
        /// </summary>
        /// <param name="assembly">Assembly of silo interface</param>
        /// <param name="name">stream provider name</param>
        /// <returns></returns>
        IStreamProvider GetStreamProvider(Assembly assembly, string name);
        /// <summary>
        /// get <see cref="ClusterClient"/>
        /// </summary>
        /// <param name="assembly">Assembly of silo interface</param>
        /// <returns></returns>
        IClusterClient GetClusterClient(Assembly assembly);
        void BindGrainReference(Assembly assembly, IAddressable grain);
        Task<TGrainObserverInterface> CreateObjectReference<TGrainObserverInterface>(IGrainObserver obj) where TGrainObserverInterface : IGrainObserver;
        Task DeleteObjectReference<TGrainObserverInterface>(IGrainObserver obj) where TGrainObserverInterface : IGrainObserver;
        TGrainInterface GetGrain<TGrainInterface>(Guid primaryKey, string grainClassNamePrefix = null) where TGrainInterface : IGrainWithGuidKey;
        TGrainInterface GetGrain<TGrainInterface>(long primaryKey, string grainClassNamePrefix = null) where TGrainInterface : IGrainWithIntegerKey;
        TGrainInterface GetGrain<TGrainInterface>(string primaryKey, string grainClassNamePrefix = null) where TGrainInterface : IGrainWithStringKey;
        TGrainInterface GetGrain<TGrainInterface>(Guid primaryKey, string keyExtension, string grainClassNamePrefix = null) where TGrainInterface : IGrainWithGuidCompoundKey;
        TGrainInterface GetGrain<TGrainInterface>(long primaryKey, string keyExtension, string grainClassNamePrefix = null) where TGrainInterface : IGrainWithIntegerCompoundKey;
    }
}
