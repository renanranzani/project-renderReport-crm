using Project.RenderReport.CRM.DTOS.Entities;
using Project.RenderReport.CRM.Interfaces.Repository;
using System.Threading.Tasks;

namespace Project.RenderReport.CRM.Repository
{
    public class ReturnResultAllRepository : IReturnResultAllRepository
    {
        private readonly IReportCRMRepository _reportCRMRepository;

        public ReturnResultAllRepository(IReportCRMRepository reportCRMRepository)
        {
            _reportCRMRepository = reportCRMRepository;
        }

        public async Task<ReturnAllEntities> Response()
        {
            var getOrganization = await _reportCRMRepository.SearchOrganization();
            var getContact = await _reportCRMRepository.SearchContact();

            var response = new ReturnAllEntities();
            response.ClientCode = getOrganization.ClientCode;
            response.OrganizationName = getOrganization.OrganizationName;
            response.Segment = getOrganization.Segment;
            response.Url = getOrganization.Url;
            response.Resume = getOrganization.Resume;
            response.ContactName = getContact.ContactName;
            response.Responsibility = getContact.Responsibility;
            response.Telephone = getContact.Telephone;
            response.Email = getContact.Email;
            response.SecondEmail = getContact.SecondEmail;

            return response;
        }
    }
}