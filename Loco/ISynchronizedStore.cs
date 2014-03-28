using System.Threading.Tasks;

namespace Loco
{
    public interface ISynchronizedStore<T> where T : Model
    {
        Task AddAsync(T model);
    }
}