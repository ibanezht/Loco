using System;
using System.Threading.Tasks;

namespace Loco.SQLite
{
    public class SQLiteLocalStore<T> : ILocalStore<T> 
        where T : Model
    {
        #region ILocalStore<T> Members

        public Task AddAsync(T model)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}