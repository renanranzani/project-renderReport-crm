using Microsoft.Office.Interop.Excel;
using Project.RenderReport.CRM.DTOS.Entities;
using Project.RenderReport.CRM.Interfaces.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.RenderReport.CRM.Services
{
    public class RenderToExcelService : IRenderToExcelService
    {
        public async Task<ReturnAllEntities> RenderToExcel(ReturnAllEntities dataSource)
        {

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel |* .xls",
                InitialDirectory = @"c:\temp", 
                FileName = "Dados_CRM_" + DateTime.Now.ToString() + ".xls",
                ValidateNames = true
            })
            {

                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                Worksheet ws = (Worksheet)app.ActiveSheet;
                app.Visible = false;
                ws.Cells[1, 1] = "CódigoCliente";
                ws.Cells[1, 2] = "Empresa";
                ws.Cells[1, 3] = "Segmento";
                ws.Cells[1, 4] = "URL";
                ws.Cells[1, 5] = "Resumo";
                ws.Cells[1, 6] = "Contato";
                ws.Cells[1, 7] = "Cargo";
                ws.Cells[1, 8] = "Telefone";
                ws.Cells[1, 9] = "Email1";
                ws.Cells[1, 10] = "Email2";

                ws.Cells[1] = dataSource.ClientCode;
                ws.Cells[2] = dataSource.OrganizationName;
                ws.Cells[3] = dataSource.Segment;
                ws.Cells[4] = dataSource.Url;
                ws.Cells[4] = dataSource.Resume;
                ws.Cells[4] = dataSource.ContactName;
                ws.Cells[4] = dataSource.Responsibility;
                ws.Cells[4] = dataSource.Telephone;
                ws.Cells[4] = dataSource.Email;
                ws.Cells[4] = dataSource.SecondEmail;

                wb.SaveAs(sfd.FileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange,
                XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                app.Quit();

                return dataSource;
            }
        }
    }
}
