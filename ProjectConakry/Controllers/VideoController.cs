﻿using ProjectConakry.BusinessServices;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace ProjectConakry.Web.Ariya.Controllers
{
    public class VideoController : Controller
    {
        private static IWantedUserManagementService _wantedUserManagementService;
        public VideoController(IWantedUserManagementService wantedUserManagementService)
        {
            _wantedUserManagementService = wantedUserManagementService;
        }

        [AllowAnonymous]
        public ActionResult Index(string customerId)
        {
            var wantedUser = _wantedUserManagementService.GetWantedUserByCustomerId(customerId);
            var memoryStream = new MemoryStream(wantedUser.EntryVideo);
            memoryStream.Seek(0, SeekOrigin.Begin);
            string mime = MimeMapping.GetMimeMapping(wantedUser.EntryVideoFileName);
            string fileExtension = Path.GetExtension(wantedUser.EntryVideoFileName);
            FileStream fileStream = System.IO.File.Create("media\\" + customerId + fileExtension);
            memoryStream.CopyTo(fileStream);
            fileStream.Close();
            //return File(wantedUser.EntryVideo, mime, wantedUser.EntryVideoFileName);            //(, MimeMapping.GetMimeMapping(wantedUser.EntryVideoFileName));
            return new FileStreamResult(memoryStream, mime);
        }
    }

    public class VideoResult : ActionResult
    {
        private readonly byte[] c_VideoBytes;
        private readonly string c_filename;
        private readonly string c_contenttype;
        public VideoResult(byte[] videoBytes, string filename, string contenttype)
        {
            c_VideoBytes = videoBytes;
            c_filename = filename;
            c_contenttype = contenttype;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Clear();
            context.HttpContext.Response.Buffer = true;
            context.HttpContext.Response.AppendHeader("Content-Disposition", "attachment; filename=" + c_filename);
            context.HttpContext.Response.ContentType = c_contenttype;           
            context.HttpContext.Response.BinaryWrite(c_VideoBytes);
            //context.HttpContext.Response.End();
        }
    }
}
