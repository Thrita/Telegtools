﻿using System.Web.Mvc;
using NUnit.Framework;
using Thrita.Telegtools.WebApi;
using Thrita.Telegtools.WebApi.Controllers;

namespace Thrita.Telegtools.WebApi.Test.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
