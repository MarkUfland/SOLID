using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    public interface IDataRepository
    {

    }

    public interface IDataRepository<T> : IDataRepository
    {
        /// <summary>
        /// Adds the given item to the database
        /// </summary>
        /// <param name="item">The item that's going to be added to the database</param>
        void Create(T item);
        void Update(T item);
        void Delete(T item);

        IList<T> GetAll();

        IList<T> GetByCriteria(String query);

        T GetByKey(object key);
    }
}
