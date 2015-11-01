using FluentNHibernate.Mapping;

namespace Jackson.Domain
{
  public class UserDetailsMap : ClassMap<UserDetails>
  {
    public UserDetailsMap()
    {
      Id(x => x.Id);
      Map(x => x.FirstName);
      Map(x => x.LastName);
      Map(x => x.Email);
      Map(x => x.Login);
      Map(x => x.Password);

      Table("UserDetails");
    }
  }
}