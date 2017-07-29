using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.WebForms;
using Sign.Models.Business;

namespace SC_RS01.Controllers
{
    public class ReportController : Controller
    {
        private IHostingEnvironment _env;
        private RealStateDatabase _db;

        public ReportController(IHostingEnvironment environment , RealStateDatabase db)
        {
            _env = environment;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetSample1Report()
        {

            byte[] rendervalue = GetSample1ReportasStreem();

            return File(rendervalue, "application/pdf");
        }

        public byte[] GetSample1ReportasStreem()
        {
           // ReportDataSource reportDataSource = new ReportDataSource();
            //var data = _db.Customers.ToList();
            //reportDataSource.Name = "dt";
            //reportDataSource.Value = data;

            LocalReport local = new LocalReport
            {
                ReportPath = _env.WebRootPath + "/Report/Report1.rdlc",
                EnableExternalImages = true
            };
            //local.DataSources.Add(reportDataSource);



            //ReportParameter[] parameters = {
            //    new ReportParameter("sample",sample),
            //    new ReportParameter("muthmen", muthmenname),
            //    new ReportParameter("audit", aduitname),
            //    new ReportParameter("approver", appovename),
            //    new ReportParameter("totprice",  toWord.ConvertToArabic()),


            //    new ReportParameter("muthminsign",  sigurlmuthmen),
            //    new ReportParameter("Auditsign",  sigurlauditsign),
            //    new ReportParameter("Approvesign", sigurlapprovesign),


            //    new ReportParameter("idmuthmin",  muthmenid),
            //    new ReportParameter("idaudit",  aduitid),
            //    new ReportParameter("idapprove", appoveid),
            //    new ReportParameter("earthmap",  earthmap),
            //    new ReportParameter("map", map),
            //    new ReportParameter("zoommap", zoommap),
            //    new ReportParameter("images",images)


            //};

            //local.SetParameters(parameters);

            return local.Render("Pdf", "");
        }
    }
}