using Jackson.Domain;
using System;

namespace Jackson
{
  public class Methods
  {
    public Methods()
    {
    }

    public bool CreateNewAccount(string firstName, string lastName, string login, string password, string email)
    {
      try
      {
        using (var session = NHibernateHelper.OpenSession())
        {
          using (var transaction = session.BeginTransaction())
          {
            var userDetails = new UserDetails
            {
              Email = email,
              FirstName = firstName,
              LastName = lastName,
              Login = login,
              Password = password
            };
            session.Save(userDetails);
            transaction.Commit();
          }
        }

        return true;
      }
      catch (Exception e)
      {
        return false;
      }
    }

    public UserDetails GetUserDetails(string userName)
    {
      string login = userName.Trim();
      using (var session = NHibernateHelper.OpenSession())
      {
        var result = session.QueryOver<UserDetails>().Where(x => x.Login == login).SingleOrDefault<UserDetails>();

        return result;
      }
    }

    public bool UserAuthentication(string userName, string password)
    {
      bool auth = false;

      using (var session = NHibernateHelper.OpenSession())
      {
        var result = session.QueryOver<UserDetails>().Where(x => ((x.Login == userName) && (x.Password == password))).SingleOrDefault<UserDetails>();

        if (result != null)
          auth = true;
      }

      return auth;
    }

    public ClientBusinessInfo GetClientDetails(int id)
    {
      ClientBusinessInfo result;

      using (var session = NHibernateHelper.OpenSession())
      {
        result = session.QueryOver<ClientBusinessInfo>().Where(x => x.Id == id).SingleOrDefault<ClientBusinessInfo>();
      }

      return result;
    }
  }
}