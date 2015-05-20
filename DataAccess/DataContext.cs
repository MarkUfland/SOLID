using DataAccessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataContext : IDataContext
    {
        Dictionary<string, Type> mappers;

        public DataContext()
        {
            LoadTypes();
        }

        private void LoadTypes()
        {
            mappers = new Dictionary<string, Type>();

            Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in typesInThisAssembly)
            {

                if (type.GetInterfaces().Where(i => i.Name.Contains("IDataRepository")).Count() > 0 == true)
                {
                    mappers.Add(type.Name.ToUpper(), type);
                }
            }

        }

        private Type GetTypeToCreate(string typeName)
        {
            foreach (var calc in mappers)
            {
                if (calc.Key.Replace("REPOSITORY", string.Empty).Equals(typeName.ToUpper()))
                {
                    return mappers[calc.Key];
                }
            }
            return null;
        }



        public IDataRepository<T> GetDataMapper<T>()
        {
            Type t = GetTypeToCreate(typeof(T).Name);

            return Activator.CreateInstance(t) as IDataRepository<T>;

        }

        public bool IsDirty
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsInTransaction
        {
            get { throw new NotImplementedException(); }
        }

        public IList<T> GetAll<T>() where T : class, new()
        {
            return GetDataMapper<T>().GetAll();
        }

        public IList<T> GetAll<T>(int pageIndex, int pageSize) where T : class, new()
        {
            return GetDataMapper<T>().GetAll();
        }

        public IList<T> GetByCriteria<T>(Query query) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public IList<T> GetByCriteria<T>(Query query, int pageIndex, int pageSize) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(object id) where T : class, new()
        {
            return GetDataMapper<T>().GetByKey(id);
        }

        public int GetCount<T>() where T : class, new()
        {
            throw new NotImplementedException();
        }

        public int GetCount<T>(Query query) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public void Add(object item)
        {
            throw new NotImplementedException();
        }

        public void Delete(object item)
        {
            throw new NotImplementedException();
        }

        public void Save(object item)
        {
            throw new NotImplementedException();
        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
