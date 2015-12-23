using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Treat.Api.Authentication;
using Treat.Model;
using Treat.Service;

namespace Treat.Api.Controllers
{
    [BasicAuthenticationFilter]
    public class EventImageController : ApiController
    {
        private readonly IFileService _fileService;

        public EventImageController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        public HttpResponseMessage Post()
        {
            if (HttpContext.Current.Request.Files.Count != 1)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var file = HttpContext.Current.Request.Files[0];
            var content = new byte[file.ContentLength];
            file.InputStream.Read(content, 0, content.Length);

            _fileService.UploadEventImage(file.FileName, content);

            var eventImage = new EventImage {FileName = file.FileName};

            return Request.CreateResponse(HttpStatusCode.Created, eventImage);
        }
    }
}