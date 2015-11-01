using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Configuration;

namespace Jackson.Domain
{
  public class NHibernateHelper
  {
    private static ISessionFactory _sessionFactory;

    private static ISessionFactory SessionFactory
    {
      get
      {
        if (_sessionFactory == null)

          InitializeSessionFactory();
        return _sessionFactory;
      }
    }

    private static void InitializeSessionFactory()
    {
      _sessionFactory = Fluently.Configure()
        .Database(MsSqlConfiguration.MsSql2008
          .ConnectionString(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString)
          .ShowSql()
        )
        .Mappings(m => m.FluentMappings
           .AddFromAssemblyOf<ClientBusinessInfo>())
           .ExposeConfiguration(cfg => new SchemaExport(cfg)
           .Create(true, true))
           .BuildSessionFactory();
    }

    public static ISession OpenSession()
    {
      return SessionFactory.OpenSession();
    }
  }
}