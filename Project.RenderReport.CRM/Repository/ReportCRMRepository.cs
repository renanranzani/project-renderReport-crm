using Newtonsoft.Json;
using Project.RenderReport.CRM.DTOS.Commands;
using Project.RenderReport.CRM.Interfaces.Repository;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Project.RenderReport.CRM.Repository
{
    public class ReportCRMRepository : IReportCRMRepository
    {
        public async Task<OrganizationCommand> SearchOrganization()
        {
            string urlApiOrganization = "https://crm.rdstation.com/api/v1/organizations?token=636f8f0d059f5d001757469d";

            var client = new HttpClient();
            var response = await client.GetAsync(urlApiOrganization);

            var conteudo = await response.Content.ReadAsStringAsync();

            dynamic obj = JsonConvert.DeserializeObject(conteudo);

            var command = new OrganizationCommand();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                command.ClientCode = obj.organizations[0].id;
                command.OrganizationName = obj.organizations[0].name;
                command.Segment = obj.organizations[0].organization_segments[0].name;
                command.Url = obj.organizations[0].url;
                command.Resume = obj.organizations[0].resume;
            }

            return command;
        }

        public async Task<ContactCommand> SearchContact()
        {
            string urlApiContact = "https://crm.rdstation.com/api/v1/contacts?token=636f8f0d059f5d001757469d";

            var client = new HttpClient();
            var response = await client.GetAsync(urlApiContact);

            var conteudo = await response.Content.ReadAsStringAsync();

            dynamic obj = JsonConvert.DeserializeObject(conteudo);

            var command = new ContactCommand();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                command.ContactName = obj.contacts[0].name;
                command.Responsibility = obj.contacts[0].title;
                command.Telephone = obj.contacts[0].phones[0].phone;
                command.Email = obj.contacts[0].emails[0].email;
                command.SecondEmail = obj.contacts[0].emails[1].email;
            }

            return command;
        }

    }
}
