using Project.RenderReport.CRM.DTOS.Commands;
using System.Threading.Tasks;

namespace Project.RenderReport.CRM.Interfaces.Repository
{
    public interface IReportCRMRepository
    {
        Task<OrganizationCommand> SearchOrganization();
        Task<ContactCommand> SearchContact();
    }
}
