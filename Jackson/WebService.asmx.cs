using Jackson.Domain;
using System.ComponentModel;
using System.Web;
using System.Web.Services;

namespace Jackson
{
  /// <summary>
  /// Summary description for WebService1
  /// </summary>
  [WebService(Namespace = "http://tempuri.org/")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [ToolboxItem(false)]
  // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
  // [System.Web.Script.Services.ScriptService]
  public class WebService : System.Web.Services.WebService
  {
    private Methods _methods = new Methods();

    [WebMethod(EnableSession = true)]
    public string HelloWorld(string name)
    {
      Context.Session["login"] = name;
      return "Hello World " + name + " |Ip= " + HttpContext.Current.Request.UserHostAddress;
    }

    [WebMethod(EnableSession = true)]
    public string HelloWorldEmpty()
    {
      var name = Session["login"];
      return "Hello World " + name;
    }

    [WebMethod(EnableSession = true)]
    public bool Login(string login, string password)
    {
      var result = _methods.UserAuthentication(login, password);

      if (result)
      {
        Session["userName"] = login;
        Session["SessionIp"] = HttpContext.Current.Request.UserHostAddress;
      }

      return result;
    }

    [WebMethod(EnableSession = true)]
    public bool CreateUser(string email, string login, string password, string firstName, string lastName)
    {
      var result = _methods.CreateNewAccount(firstName, lastName, login, password, email);

      return result;
    }

    [WebMethod(EnableSession = true)]
    public UserDetails GetUserDetails(string login)
    {
      if ((string)Session["SessionIp"] != HttpContext.Current.Request.UserHostAddress || Session["userName"] == null)
        return null;

      var result = _methods.GetUserDetails(login);
      return result;
    }

    [WebMethod(EnableSession = true)]
    public ClientBusinessInfo GetClient(int id)
    {
      if ((string)Session["SessionIp"] != HttpContext.Current.Request.UserHostAddress || Session["userName"] == null)
        return null;

      var result = _methods.GetClientDetails(id);

      return result;
    }
  }
}