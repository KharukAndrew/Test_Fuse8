using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Web.Hosting;
using Test_Fuse8.ViewModels;
using System;

namespace Test_Fuse8.Services
{
    public class CreatingExcelDoc
    {
        public static void CreateDoc(List<Report> report, Period period)
        {
            using (var package = new ExcelPackage())
            {
                // Add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");

                var row = 1;
                var col = 1;

                // header
                worksheet.Cells[row, col].Value = "Report";
                row += 2;

                worksheet.Cells[row, col].Value = "from:";
                worksheet.Cells[row, col + 1].Value = period.Start.ToString();
                row++;

                worksheet.Cells[row, col].Value = "to:";
                worksheet.Cells[row, col + 1].Value = period.End.ToString();
                row += 2;

                worksheet.Cells[row, col].Value = "Number";
                worksheet.Cells[row, col + 1].Value = "OrderDate";
                worksheet.Cells[row, col + 2].Value = "Article";
                worksheet.Cells[row, col + 3].Value = "Name";
                worksheet.Cells[row, col + 4].Value = "Quantity";
                worksheet.Cells[row, col + 5].Value = "UnitPrice";
                worksheet.Cells[row, col + 6].Value = "Cost";

                row++;

                //body
                foreach (var item in report)
                {
                    worksheet.Cells[row, col].Value = item.Number;
                    worksheet.Cells[row, col + 1].Value = item.OrderDate.ToString();
                    worksheet.Cells[row, col + 2].Value = item.Article;
                    worksheet.Cells[row, col + 3].Value = item.Name;
                    worksheet.Cells[row, col + 4].Value = item.Quantity;
                    worksheet.Cells[row, col + 5].Value = item.UnitPrice;

                    //formula SUM
                    worksheet.Cells[row, col + 6].Formula = $"E{row}*F{row}";

                    worksheet.Cells[row, col + 5].Style.Numberformat.Format = @"#,##0.00_ ;\-#,##0.00_ ;0.00_ ;";
                    worksheet.Cells[row, col + 6].Style.Numberformat.Format = @"#,##0.00_ ;\-#,##0.00_ ;0.00_ ;";

                    row++;
                }

                using (var cells = worksheet.Cells[worksheet.Dimension.Address])
                {
                    cells.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    cells.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    cells.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    cells.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    cells.AutoFitColumns();
                }

                var bin = package.GetAsByteArray();
                string path = HostingEnvironment.MapPath("/Files/Report.xlsx");
                File.WriteAllBytes(path, bin);
            }
        }
    }
}