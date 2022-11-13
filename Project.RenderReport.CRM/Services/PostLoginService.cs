using Project.RenderReport.CRM.Interfaces.Services;
using System.IO;
using System.Net;
using System.Text;

namespace Project.RenderReport.CRM.Services
{
    public class PostLoginService : IPostLoginService
    {
        public void ConnectLogin()
        {
            string formUrl = "https://accounts.rdstation.com.br/?redirect_to=https%3A%2F%2Fcrm.rdstation.com%2Fauth%2Fcallback&referer=https%3A%2F%2Fcrm.rdstation.com%2Fsignup%3Fhl%3Dpt-BR%26utm_source%3Dhttps%253A%252F%252Faccounts.rdstation.com.br%252F%26utm_medium%3Dreferral%26trial_origin%3Dlogin_page&time=1668255497&trial_origin=login_page&utm_medium=referral&utm_source=https%3A%2F%2Faccounts.rdstation.com.br%2F"; 
            string formParams = string.Format("email_address={0}&password={1}", "renanranzani@gmail.com", "Ren@365268");
            string cookieHeader;
            WebRequest req = WebRequest.Create(formUrl);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(formParams);
            req.ContentLength = bytes.Length;
            using (Stream os = req.GetRequestStream())
            {
                os.Write(bytes, 0, bytes.Length);
            }
            WebResponse resp = req.GetResponse();
            cookieHeader = resp.Headers["Set-cookie"];
        }
    }
}
