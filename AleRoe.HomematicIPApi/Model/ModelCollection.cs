using System.Collections.ObjectModel;

namespace AleRoe.HomematicIpApi.Model
{
    public abstract class ModelCollection<T> : Collection<T>, IModelCollection<T>
    {
        public abstract string GetKeyValue(T item);
    }
}