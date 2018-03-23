using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Thrita.Telegtools.WebApi.Controllers
{
    [RoutePrefix("posts")]
    public class PostsController : ApiController
    {
        private readonly WebChannelTools _tools;

        public PostsController()
        {
            _tools = new WebChannelTools();
        }

        [Route("{channelName}/{postId:int:min(1)}")]
        [ResponseType(typeof(TelegramPost))]
        public async Task<IHttpActionResult> GetPost(string channelName, int postId)
        {
            try
            {
                var post = await _tools.GetPostAsync(channelName, postId);

                if (post == null)
                    return NotFound();

                return Ok(post);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("{channelName}/{fromId:int:min(1)}/{toId:int:min(1)}")]
        [ResponseType(typeof(IEnumerable<TelegramPost>))]
        public async Task<IHttpActionResult> Get(string channelName, int fromId, int toId)
        {
            var posts = new HashSet<TelegramPost>();

            try
            {
                for (int i = fromId; i <= toId; i++)
                {
                    try
                    {
                        var post = await _tools.GetPostAsync(channelName, i);

                        if(post!=null)
                            posts.Add(post);
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(posts);
        }
    }
}
