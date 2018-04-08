using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Description;
using Thrita.Telegtools.EntityFramework;
using Thrita.Telegtools.Ftp;
using Thrita.Telegtools.WebApi.Models;

namespace Thrita.Telegtools.WebApi.Controllers
{
    public class AttachmentsController : ApiController
    {
        private readonly IChannelTools _cTools;

        public AttachmentsController()
        {
            _cTools = new WebChannelTools();
        }

        [Route("{channelName}/save-attachments"), HttpPost]
        [ResponseType(typeof(TelegtoolsJob))]
        public async Task<HttpResponseMessage> SaveAttachments(string channelName, [FromBody]AttachmentRequest req)
        {
            if (req == null || !ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

            IAttachmentTools attachment = new TelegFtpTools(req.FtpUrl, req.FtpUser, req.FtpPassword);
            var manager = new JobAttachmentManager(_cTools, attachment);
            var job = await manager.CreateJobAsync(channelName, req.FromId, req.ToId);

            HostingEnvironment.QueueBackgroundWorkItem(ct => manager.ExecuteJobAsync(job.Id));

            return Request.CreateResponse(HttpStatusCode.Accepted, job);
        }
    }
}