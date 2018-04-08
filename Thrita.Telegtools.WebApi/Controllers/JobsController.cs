using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Description;
using Thrita.Telegtools.EntityFramework;
using Thrita.Telegtools.WebApi.Models;

namespace Thrita.Telegtools.WebApi.Controllers
{
    public class JobsController : ApiController
    {
        private readonly JobManager _jobMan;

        public JobsController()
        {
            _jobMan = new JobManager(new WebChannelTools());
        }

        [Route("{channelName}/jobs/{jobId:long:min(1)}")]
        [ResponseType(typeof(TelegtoolsJob))]
        public async Task<IHttpActionResult> GetJob(string channelName, long jobId)
        {
            var job = await _jobMan.GetJobAsync(jobId, includeLogs: true);

            if (job == null || !string.Equals(job.ChannelName, channelName,
                    StringComparison.InvariantCultureIgnoreCase))
                return NotFound();

            return Ok(job);
        }

        [Route("{channelName}/jobs"), HttpPost]
        [ResponseType(typeof(TelegtoolsJob))]
        public async Task<HttpResponseMessage> CreateJob([FromUri]string channelName, [FromBody]JobRequest req)
        {
            if (req == null || !ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

            var job = await _jobMan.CreateJobAsync(channelName, req.FromId, req.ToId);
            HostingEnvironment.QueueBackgroundWorkItem(ct => _jobMan.ExecuteJobAsync(job.Id));
            
            return Request.CreateResponse(HttpStatusCode.Accepted, job);
        }
    }
}
