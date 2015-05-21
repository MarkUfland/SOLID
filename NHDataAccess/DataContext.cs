using DataAccessInterfaces;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHDataAccess
{
    public class DataContext : IDataContext
    {
        private ISession session;
        private ITransaction tx;
        private QueryTranslator queryTranslator;

        public DataContext()
            : this(new QueryTranslator())
        {

        }

        public DataContext(QueryTranslator queryTranslator)
        {

            session = SessionHelper.GetNewSession();
            this.queryTranslator = queryTranslator;
        }

        public bool IsDirty
        {
            get
            {
                return session.IsDirty();
            }
        }

        public bool IsInTransaction
        {
            get
            {
                return session.Transaction != null && session.Transaction.IsActive;
            }
        }

        public IList<T> GetAll<T>() where T : class, new()
        {
            return GetAll<T>(0, 0);
        }

        public IList<T> GetAll<T>(int pageIndex, int pageSize) where T : class, new()
        {
            var query = session.Query<T>();

            if (pageSize > 0)
            {
                query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            return query.ToList();
        }

        public IList<T> GetByCriteria<T>(Query query) where T : class, new()
        {
            return GetByCriteria<T>(query, 0, 0);
        }

        public IList<T> GetByCriteria<T>(Query query, int pageIndex, int pageSize) where T : class, new()
        {
            try
            {
                var nHibernateQuery = session.Query<T>().Where(queryTranslator.CreateLambda<T>(query));

                if (pageSize > 0)
                {
                    nHibernateQuery = nHibernateQuery.Skip((pageIndex - 1) * pageSize).Take(pageSize);
                }
                return nHibernateQuery.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public T GetById<T>(object id) where T : class, new()
        {
            return session.Load<T>(id);
        }

        public int GetCount<T>() where T : class, new()
        {
            try
            {
                var nHibernateQuery = session.Query<T>();

                return nHibernateQuery.Count();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetCount<T>(Query query) where T : class, new()
        {
            try
            {
                var nHibernateQuery = session.Query<T>().Where(queryTranslator.CreateLambda<T>(query));

                return nHibernateQuery.Count();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void Add(object item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            session.Save(item);
            if (!this.IsInTransaction)
            {
                session.Flush();
            }
        }

        public void Delete(object item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            session.Delete(item);
            if (!this.IsInTransaction)
            {
                session.Flush();
            }
        }

        public void Save(object item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            session.Update(item);
            if (!this.IsInTransaction)
            {
                session.Flush();
            }
        }

        public void BeginTransaction()
        {
            if (this.IsInTransaction)
            {
                throw new InvalidOperationException("A transaction is already opened");
            }
            else
            {
                try
                {
                    tx = session.BeginTransaction();
                }
                catch
                {
                    throw new TransactionException("Failed to begin the transaction");
                }
            }
        }

        public void Commit()
        {
            if (!this.IsInTransaction)
            {
                throw new InvalidOperationException("Operation requires an active transaction");
            }
            else
            {
                try
                {
                    tx.Commit();
                    tx.Dispose();
                }
                catch
                {
                    throw new TransactionException("The transaction failed to commit");
                }
            }
        }

        public void Rollback()
        {
            if (!this.IsInTransaction)
            {
                throw new InvalidOperationException("Operation requires an active transaction");
            }
            else
            {
                try
                {
                    tx.Rollback();
                    tx.Dispose();
                }
                catch
                {
                    throw new TransactionException("The transaction failed to rollback");
                }
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
