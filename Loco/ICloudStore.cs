using System.Threading.Tasks;

namespace Loco
{
    public interface ICloudStore<T> where T : Model
    {
        Task AddAsync(T model);
    }
}