using System.Xml.Linq;
using DataEf;


namespace BusinessLogic;
public class Login
{

    public bool LoginSubmit(string EmailID, string Password)
    {
        int usid = 0;
        DataEf.Entities.AbdulContext abdulContext = new DataEf.Entities.AbdulContext();

        var query = from b in abdulContext.Users where b.EmailId == EmailID && b.Password == Password select b;

        foreach (var q in query)
        {
            usid = q.UserId;

        }

        if (usid > 0)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}

public class LoginClass
{
    public string EmailID { get; set; }
    public string Password { get; set; }

}

