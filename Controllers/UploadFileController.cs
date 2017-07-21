using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Sign.HelperClasses;

namespace Sign.Controllers
{
    public class UploadFileController : Controller
    {
        readonly FilesHelper _filesHelper;

        String serverMapPath = "/Files/somefiles/";

        private string UrlBase = "/Files/somefiles/";

        String DeleteURL = "/FileUpload/DeleteFile/?file=";

        String DeleteType = "GET";

        public UploadFileController(IHostingEnvironment hostenvirment)
        {
            string rootpath = hostenvirment.WebRootPath + @"\Files\somefiles\";
            _filesHelper = new FilesHelper(DeleteURL, DeleteType,rootpath  , UrlBase, serverMapPath);
        }

        [HttpPost]
        public JsonResult Upload()
        {
            var resultList = new List<ViewDataUploadFilesResult>();
            
            _filesHelper.UploadWholeFile(Request, resultList);

            JsonFiles files = new JsonFiles(resultList);

            bool isEmpty = !resultList.Any();
            if (isEmpty)
            {
                return Json("Error ");
            }

            //here save image file name by extions to retrive it other time
            return Json(files);
        }

        public IActionResult Index()
        {
    
            return View();
        }

        
    }
}