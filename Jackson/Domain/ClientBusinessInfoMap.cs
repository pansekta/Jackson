using FluentNHibernate.Mapping;

namespace Jackson.Domain
{
  public class ClientBusinessInfoMap : ClassMap<ClientBusinessInfo>
  {
    public ClientBusinessInfoMap()
    {
      Id(x => x.Id);
      Map(x => x.FirstName);
      Map(x => x.LastName);
      Map(x => x.Email);
      Map(x => x.Company);
      Map(x => x.JobPosition);
      Map(x => x.MonthsWithContract);
      Map(x => x.PersonalData);
      Map(x => x.Phone);
      Map(x => x.YearlyIncome);

      Table("ClientBussinesInfo");
    }
  }
}