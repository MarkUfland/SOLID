using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NHDataAccess
{
    public class SessionHelper
    {
        private static Configuration cfg;
        private static ISessionFactory sessionFactory;

        static SessionHelper()
        {
            #region Using app config and mapping files

            //cfg = new Configuration();
            //cfg.Configure();
            //try
            //{
            //    sessionFactory = cfg.BuildSessionFactory();
            //}
            //catch (Exception ex)
            //{
            //    int a = 1;

            //}

            #endregion

            #region Using code based configuration and mapping files

            //try
            //{
            //    cfg = new Configuration();

            //    cfg.DataBaseIntegration(x =>
            //    {
            //        x.ConnectionString = @"Data Source=YLWIN81DEV1\SQLEXPRESS;Initial Catalog=SOLID2;Integrated Security=True";
            //        x.Dialect<MsSql2012Dialect>();
            //        x.Driver<SqlClientDriver>();
            //        x.LogSqlInConsole = true;
            //    });

            //    cfg.AddAssembly(Assembly.GetExecutingAssembly());

            //    sessionFactory = cfg.BuildSessionFactory();
            //}
            //catch (Exception ex)
            //{
            //    int a = 1;

            //}

            #endregion

            #region Using Fluent NHibernate for mapping and the configuration class to configure db

            try
            {
                cfg = new Configuration();
                cfg.DataBaseIntegration(x =>
                {
                    x.ConnectionString = @"Data Source=YLWIN81DEV1\SQLEXPRESS;Initial Catalog=SOLID2;Integrated Security=True";
                    x.Dialect<MsSql2012Dialect>();
                    x.Driver<SqlClientDriver>();
                    x.LogSqlInConsole = true;
                });

                sessionFactory = Fluently.Configure(cfg)
                    .Mappings(
                       m => m.FluentMappings.AddFromAssemblyOf<DataContext>())
                    .BuildSessionFactory();
            }
            catch (Exception ex)
            {
                int a = 1;
            }
            #endregion

            #region Using Fluent NHibernate for mapping and the configuration class to configure from app settings

            //try
            //{
            //    cfg = new Configuration();

            //    cfg.Configure(); // read config default style
            //    sessionFactory = Fluently.Configure(cfg)
            //        .Mappings(
            //           m => m.FluentMappings.AddFromAssemblyOf<DataContext>())
            //        .BuildSessionFactory();
            //}
            //catch (Exception ex)
            //{
            //    int a = 1;
            //}
            #endregion

            #region Using Fluent NHibernate for mapping and configuration with a connection string for app settings

            //sessionFactory = Fluently.Configure()
            //                            .Database(MsSqlConfiguration.MsSql2008
            //                                .ConnectionString(c => c
            //                                    .FromAppSetting("connectionString"))
            //                                .ShowSql())
            //                            .Mappings(m => m
            //                                .FluentMappings.AddFromAssemblyOf<DataContext>()
            //                                    .ExportTo(@"C:\HibernateFiles"))
            //                            .BuildSessionFactory();
            #endregion

            #region Using Fluent NHibernate for mapping and configuration with a database connection string factory providing the connection string

            //sessionFactory = Fluently.Configure()
            //                .Database(MsSqlConfiguration.MsSql2008
            //                    .ConnectionString(ConnectionStringFactory.GetConnectionString(DBEntities.SOLID))
            //                    .ShowSql())
            //                .Mappings(m => m
            //                    .FluentMappings.AddFromAssemblyOf<DataContext>()
            //                         .ExportTo(@"C:\HibernateFiles"))
            //                .BuildSessionFactory();
            #endregion
        }

        public static ISession GetNewSession()
        {
            return sessionFactory.OpenSession();
        }
    }
}
