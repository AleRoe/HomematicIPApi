using System.Collections.Generic;

namespace AleRoe.HomematicIpApi.Model
{
    public interface IModelCollection<T> : ICollection<T>
    {
        string GetKeyValue(T item);
    }
}