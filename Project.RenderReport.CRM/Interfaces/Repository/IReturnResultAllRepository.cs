using Project.RenderReport.CRM.DTOS.Entities;
using System.Threading.Tasks;

namespace Project.RenderReport.CRM.Interfaces.Repository
{
    public interface IReturnResultAllRepository
    {
        Task<ReturnAllEntities> Response();
    }
}
