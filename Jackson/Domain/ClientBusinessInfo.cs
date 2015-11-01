namespace Jackson.Domain
{
  public class ClientBusinessInfo
  {
    public virtual int Id { get; set; }
    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
    public virtual string Email { get; set; }
    public virtual string Phone { get; set; }
    public virtual int YearlyIncome { get; set; }
    public virtual string JobPosition { get; set; }
    public virtual string Company { get; set; }
    public virtual string PersonalData { get; set; }
    public virtual string MonthsWithContract { get; set; }
  }
}