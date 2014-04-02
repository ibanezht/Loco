using System.Threading.Tasks;

namespace Loco
{
    public interface ISynchronizedStore<T> : ISynchronizedStore
        where T : Model
    {
        Task AddAsync(T model);
    }

    public interface ISynchronizedStore { }
}