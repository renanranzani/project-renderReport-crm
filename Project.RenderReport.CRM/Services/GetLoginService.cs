using Project.RenderReport.CRM.Interfaces.Services;
using System.IO;
using System.Net;

namespace Project.RenderReport.CRM.Services
{
    public class GetLoginService : IGetLoginService
    {
        public void ReturnLogin()
        {
            var cookieHeader = @"PHPSESSID=636f8f0d059f5d001757469d; path=/; rdstation.com.br,wowmine_referer=directenter; path=/; domain=.rdstation.com.br,lang=en; path=/;domain=.rdstation.com.br,adt_usertype=other,adt_host=-";
            string pageSource;
            string getUrl = "https://accounts.rdstation.com.br/";
            WebRequest getRequest = WebRequest.Create(getUrl);
            getRequest.Headers.Add("Cookie", cookieHeader);
            WebResponse getResponse = getRequest.GetResponse();

            using (StreamReader sr = new StreamReader(getResponse.GetResponseStream()))
            {
                pageSource = sr.ReadToEnd();
            }
        } 
    }
}
