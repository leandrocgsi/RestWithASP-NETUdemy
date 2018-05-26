using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RestWithASPNETUdemy.Business;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class FilesController : Controller
    {
        private IFileBusiness _fileBusiness;

        public FilesController(IFileBusiness fileBusiness)
        {
            _fileBusiness = fileBusiness;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetPDFFile()
        {
            byte[] buffer = _fileBusiness.GetPDFFile();
            if (buffer != null)
            {
                HttpContext.Response.ContentType = "application/pdf";
                HttpContext.Response.Headers.Add("content-length", buffer.Length.ToString());
                HttpContext.Response.Body.Write(buffer, 0, buffer.Length);
            }
            return new ContentResult();
        }
    }
}