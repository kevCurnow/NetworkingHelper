using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetworkingHelper.Models.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NetworkingHelper.Web.Tests.Controllers.EventControllerTests
{
    [TestClass]
    public class CreatePost : EventControllerTestsBase
    {
        private ActionResult Act()
        {
            return Controller.Create(new EventCreateModel());
        }

        [TestMethod]
        public void ShouldReturnRedirectToRouteResult()
        {
            //Act
            var result = Act();

            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void ShouldCallCreateOnce()
        {
            var result = Act();

            Assert.AreEqual(1, Service.CreateEventCallCount);
        }
    }
}
