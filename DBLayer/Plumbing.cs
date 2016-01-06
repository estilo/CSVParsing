using System;
using DBLayer.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace DBLayer
{
    public class Plumbing
    {
        public static ISessionFactory CreateSessionFactory()
        {
            ISessionFactory isessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard
                .ConnectionString(t=> t.FromConnectionStringWithKey("defaultconnection")))
                .Mappings(m => m
                .FluentMappings.AddFromAssemblyOf<Employee>())
                .BuildSessionFactory();

            return isessionFactory;
        }
    }
}