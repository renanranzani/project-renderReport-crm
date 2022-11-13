using Project.RenderReport.CRM.DTOS.Entities;
using System.Threading.Tasks;

namespace Project.RenderReport.CRM.Interfaces.Services
{
    public interface IReportCRMService
    {
        Task<ReturnAllEntities> GetInfo();
    }
}
