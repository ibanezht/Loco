using System.Threading.Tasks;

namespace Loco
{
    public interface ISyncStore<T> : ISyncStore
        where T : Model
    {
        Task AddAsync(T model);
    }

    public interface ISyncStore { }
}