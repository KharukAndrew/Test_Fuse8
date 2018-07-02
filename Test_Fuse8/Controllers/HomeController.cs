using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Test_Fuse8.Models;
using Test_Fuse8.ViewModels;
using Test_Fuse8.Services;
using System.Threading.Tasks;

namespace Test_Fuse8.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new Period());
        }

        [HttpPost]
        public async Task<ActionResult> Report(Period period)
        {
            if (period.End == new DateTime())
            {
                period.End = DateTime.Now;
            }
            else
            {
                period.End = period.End.AddSeconds(86399);
            }   

            IEnumerable<OrderDetail> list;

            using (NorthwindDb db = new NorthwindDb())
            {
                list = await db.OrderDetails
                    .Include(o => o.Order)
                    .Where(o => o.Order.OrderDate >= period.Start)
                    .Where(o => o.Order.OrderDate <= period.End)                   
                    .Include(o => o.Product).ToListAsync();
            }

            var report = new List<Report>();

            foreach (var order in list)
            {
                report.Add(new Report
                {
                    Number = order.Order.ID,
                    OrderDate = order.Order.OrderDate,
                    Article = order.Product.ID,
                    Name = order.Product.Name,
                    Quantity = order.Quantity,
                    UnitPrice = order.UnitPrice,
                    Cost = order.Quantity * order.UnitPrice
                });
            }

            CreatingExcelDoc.CreateDoc(report, period);

            ViewBag.Period = period;

            return View("Report", report);
        }

        public ActionResult Mail()
        {
            return View(new EmailSettings());
        }

        [HttpPost]
        public ActionResult Mail(EmailSettings settings)
        {
            if (ModelState.IsValid)
            {
                SendingMail.SendEmail(settings);
                return View("Sent");
            }

            return View(settings);            
        }
    }
}