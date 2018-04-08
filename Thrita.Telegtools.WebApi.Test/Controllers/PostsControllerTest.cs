using NUnit.Framework;
using System.Threading.Tasks;
using System.Web.Http;
using Thrita.Telegtools.WebApi.Controllers;

namespace Thrita.Telegtools.WebApi.Test.Controllers
{
    [TestFixture]
    public class PostsControllerTest
    {
        private const string ChannelName = "telegram";

        [Test]
        public void GetPost_Test_01()
        {
            // Arrange
            PostsController controller = new PostsController();

            // Act
            Task<IHttpActionResult> task = controller.GetPost(ChannelName, 3);
            task.Wait();
            TelegramPost result =
                (task.Result as System.Web.Http.Results.OkNegotiatedContentResult<TelegramPost>)?.Content;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Id);
        }
    }
}
