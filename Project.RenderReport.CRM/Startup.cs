using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Project.RenderReport.CRM.Interfaces.Repository;
using Project.RenderReport.CRM.Interfaces.Services;
using Project.RenderReport.CRM.Repository;
using Project.RenderReport.CRM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.RenderReport.CRM
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<IRenderToExcelService, RenderToExcelService>();
            services.AddSingleton<IReportCRMService, ReportCRMService>();
            services.AddSingleton<IPostLoginService, PostLoginService>();
            services.AddSingleton<IGetLoginService, GetLoginService>();

            services.AddSingleton<IReportCRMRepository, ReportCRMRepository>();
            services.AddSingleton<IReturnResultAllRepository, ReturnResultAllRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
