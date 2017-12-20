using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetworkingHelper.Contracts;
using NetworkingHelper.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkingHelper.Web.Tests.Controllers.EventControllerTests
{
    [TestClass]
    public abstract class EventControllerTestsBase
    {
        protected EventController Controller;

        protected FakeEventService Service;

        [TestInitialize]
        public virtual void Arrange()
        {
            Service = new FakeEventService();

            Controller = new EventController(
                new Lazy<IEvent>(() => Service));
        }
    }
}
