using Microsoft.AspNetCore.Mvc;
using Project.RenderReport.CRM.DTOS.Entities;
using Project.RenderReport.CRM.Interfaces.Services;
using System.Threading.Tasks;

namespace Project.RenderReport.CRM.Controllers
{
    [ApiController]
    [Route("api/report")]
    public class ReportCRMController : ControllerBase
    {
        private readonly IReportCRMService _reportService;
        private readonly IGetLoginService _getLoginService;
        private readonly IPostLoginService _postLoginService;

        public ReportCRMController(IReportCRMService reportService, 
            IGetLoginService getLoginService, IPostLoginService postLoginService)
        {
            _reportService = reportService;
            _getLoginService = getLoginService;
            _postLoginService = postLoginService;
        }

        [HttpGet]
        public async Task<ReturnAllEntities> Get() => await _reportService.GetInfo();

        [HttpGet]
        [Route("connected")]
        public void GetLogin() => _getLoginService.ReturnLogin();

        [HttpPost]
        public void PostLogin() => _postLoginService.ConnectLogin();

    }
}
