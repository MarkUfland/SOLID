using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDataContext : IDisposable
    {
        IList<T> GetAll<T>();

        IList<T> GetByCriteria<T>(String query) where T : class, new();

        T GetById<T>(object id);

        void Add(object item);

        void Delete(object item);

        void Save(object item);
    }
}
