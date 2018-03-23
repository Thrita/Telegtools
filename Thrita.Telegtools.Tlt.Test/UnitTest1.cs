using NUnit.Framework;
using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using Thrita.Telegtools.EntityFramework;

namespace Thrita.Telegtools.Tlt.Test
{
    [TestFixture]
    public class UnitTest1
    {
        const string CHANNEL_NAME = "k1inusa";

        [Test]
        public void Save_A_TelegramPost_To_Database()
        {
            var post = new TelegramPost
            {
                Id = 1,
                Author = "a",
                Body = "TEST",
                PossibleTitle = "T",
                DateString = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                ViewCount = "0",
                WebRaw = "<test>"
            };

            int actual;

            using (var ctx = new TelegtoolsContext())
            {
                ctx.TelegramPosts.Add(post);
                actual = ctx.SaveChanges();
            }

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void TestMethod2()
        {
            var method = typeof(Program).GetMethod("SetTitleBody", BindingFlags.Static | BindingFlags.NonPublic);
            var post = new TelegramPost();
            method?.Invoke(obj: null, parameters: new Object[] { post, "title<br>body" });
        }

        [Test]
        public void TestMethod3()
        {
            var method = typeof(Program).GetMethod("GatherChannelHistoryFromWeb", BindingFlags.Static | BindingFlags.NonPublic);
            object result = method?.Invoke(obj: null, parameters: new Object[] { CHANNEL_NAME, 5319 });
            var post = result as TelegramPost;
        }

        [Test]
        public void LoadImage()
        {
            var method = typeof(Program).GetMethod("GatherChannelHistoryFromWeb", BindingFlags.Static | BindingFlags.NonPublic);

            for (int postId = 1; postId < 100; postId++)
            {
                var post =
                    method?.Invoke(obj: null, parameters: new Object[] { CHANNEL_NAME, postId })
                        as TelegramPost;

                if (post?.AttachmentUri == null)
                    continue;

                try
                {
                    var path = UploadPath(post);
                    var req = WebRequest.Create(post.AttachmentUri);

                    using (var response = req.GetResponse())
                    {
                        using (var stream = response.GetResponseStream())
                        {
                            if (stream != null)
                            {
                                //var image = Image.FromStream(stream);
                                UploadFileToFtp(stream, path);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        [Test]
        public void UpLoadVodeo()
        {
            bool actual = true;
            //var program = new PrivateObject("Thrita.Telegtools.Tlt", "Thrita.Telegtools.Tlt.Program");
            var method = typeof(Program).GetMethod("GatherChannelHistoryFromWeb", BindingFlags.Static | BindingFlags.NonPublic);

            for (int postId = 5300; postId <= 5400; postId++)
            {
                var post =
                    method?.Invoke(obj: null, parameters: new Object[] { CHANNEL_NAME, postId })
                        as TelegramPost;

                if (post?.AttachmentUri == null)
                    continue;

                try
                {
                    var path = UploadPath(post);
                    var req = WebRequest.Create(post.AttachmentUri);

                    using (var response = req.GetResponse())
                    {
                        using (var stream = response.GetResponseStream())
                        {
                            if (stream != null)
                            {
                                //var image = Image.FromStream(stream);
                                UploadFileToFtp(stream, path);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.ToString());
                    actual = false;
                }
            }

            Assert.IsTrue(actual);
        }

        private string UploadPath(TelegramPost post)
        {
            if (post?.AttachmentUri == null) return string.Empty;
            var dotIndex = post.AttachmentUri.ToString().LastIndexOf('.');
            if (dotIndex == -1) return string.Empty;
            var ext = post.AttachmentUri.ToString().Substring(dotIndex);
            return $"/{post.Date.Year}/{post.Id}{ext}";
        }

        private void UploadFileToFtp(Stream stream, string path)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string ftpurl = appSettings["ftp_url"];
            string ftpusername = appSettings["ftp_username"];
            string ftppassword = appSettings["ftp_password"];

            try
            {
                string ftpfullpath = Path.Combine(ftpurl + path);
                var ftp = (FtpWebRequest)WebRequest.Create(ftpfullpath);
                ftp.Credentials = new NetworkCredential(ftpusername, ftppassword);
                ftp.KeepAlive = true;
                ftp.UseBinary = true;
                ftp.Method = WebRequestMethods.Ftp.UploadFile;

                byte[] buffer = ReadFully(stream);

                using (var ftpstream = ftp.GetRequestStream())
                {
                    ftpstream.Write(buffer, 0, buffer.Length);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static byte[] ReadFully(Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
