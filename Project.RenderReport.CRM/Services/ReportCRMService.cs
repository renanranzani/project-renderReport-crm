using Project.RenderReport.CRM.DTOS.Entities;
using Project.RenderReport.CRM.Interfaces.Repository;
using Project.RenderReport.CRM.Interfaces.Services;
using System.Threading.Tasks;

namespace Project.RenderReport.CRM.Services
{
    public class ReportCRMService : IReportCRMService
    {
        private readonly IReturnResultAllRepository _returnResultAllRepository;
        private readonly IRenderToExcelService _renderService;

        public ReportCRMService(IReturnResultAllRepository returnResultAllRepository,
            IRenderToExcelService renderService)
        {
            _returnResultAllRepository = returnResultAllRepository;
            _renderService = renderService;
        }

        public async Task<ReturnAllEntities> GetInfo()
        {
            var returnResponse = await _returnResultAllRepository.Response();

            var render = await _renderService.RenderToExcel(returnResponse);

            return render;
        }
    }
}
