using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Text;

namespace ClientesProdutos.Infrastructure.Persistence
{
    public class SQLServerDb : IDb,IDisposable
    {
       
        public static ISessionFactory sessionFactory;

        public ISession Session { get=> sessionFactory.OpenSession();  }
        
      
        private string ConnectionString;

        public SQLServerDb()
        {
            sessionFactory = CreateSessionFactory();
            //session = sessionFactory.OpenSession();
           
        }
        public SQLServerDb(string connextionString)
        {
            ConnectionString = connextionString;

            if(string.IsNullOrEmpty(connextionString))
                sessionFactory = CreateSessionFactory();
            else
                sessionFactory = CreateSessionFactory(ConnectionString);

           // session = sessionFactory.OpenSession();
           
        }
        IDbConnection IDb.Connection()
        {
            return Session.Connection;
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var dbPath = ConfigurationManager.ConnectionStrings["dbSql"].ConnectionString;

            return sessionFactory ?? (sessionFactory =
                Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(dbPath))
                .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(cfg => new SchemaExport(cfg).SetOutputFile("DBSql").Create(false, true))
                .BuildSessionFactory());
        }
        private static ISessionFactory CreateSessionFactory(string connectionString)
        {
           

            return sessionFactory ?? (sessionFactory =
                Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString))
                .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                //.ExposeConfiguration(cfg => new SchemaExport(cfg).SetOutputFile("DBSql").Create(false, true))
                .BuildSessionFactory());
        }



        public void Dispose()
        {
            Session?.Dispose();              
            sessionFactory?.Dispose();
        }

       
       
    }
}
