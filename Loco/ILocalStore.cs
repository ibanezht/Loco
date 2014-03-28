using System.Threading.Tasks;

namespace Loco
{
    public interface ILocalStore<T> where T : Model
    {
        Task AddAsync(T model);
    }
}