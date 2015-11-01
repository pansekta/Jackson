namespace Jackson.Domain
{
  public class UserDetails
  {
    public virtual int Id { get; set; }
    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
    public virtual string Email { get; set; }
    public virtual string Login { get; set; }
    public virtual string Password { get; set; }
  }
}