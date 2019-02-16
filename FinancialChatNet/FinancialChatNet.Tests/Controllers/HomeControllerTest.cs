using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinancialChatNet;
using FinancialChatNet.Controllers;
using System.Web;
using System.Web.SessionState;
using System.Reflection;
using System.IO;
using FakeHttpContext.Switchers;
using Moq;
using Data;
using Transversal.Models;
using Data.Interfaces;
using System.Web.Routing;

namespace FinancialChatNet.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {

        [TestMethod]
        public void Index()
        {
            var userDataAccessMock = new Mock<IUserDataAccess>();
            HomeController controller = new HomeController();
            ViewResult result = controller.Login() as ViewResult;
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void Login()
        {
            var userDataAccessMock = new Mock<IUserDataAccess>();
            HomeController controller = new HomeController();
            ViewResult result = controller.Login() as ViewResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void LoginSuccessfully()
        {           
            string user = "cra1982@gmail.com";
            string password = "123";
            UserModel userReturn = new UserModel();
            userReturn.password = "123";
            userReturn.id = 1;
            userReturn.email = "cra1982@gmail.com";
            HomeController controller = new HomeController();
            var context = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(x => x.Session).Returns(session.Object);
            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);
            var userDataAccessMock = new Mock<IUserDataAccess>();
            userDataAccessMock.Setup(x => x.login(user, password)).Returns(userReturn);
            
            controller.UserDataAccess = userDataAccessMock.Object;
            FormCollection form = new FormCollection();
            form["txtemail"] = user;
            form["txtpassword"] = password;
            RedirectToRouteResult viewReturn =  (RedirectToRouteResult)controller.login(form);
            Assert.AreEqual(viewReturn.RouteValues.First().Value, "Index");
            
        }


        [TestMethod]
        public void LoginUnSuccessfully()
        {
            string user = "cra1982@gmail.com";
            string password = "1234";
            UserModel userReturn = new UserModel();
            userReturn.id = 0;
            HomeController controller = new HomeController();
            var context = new Mock<HttpContextBase>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(x => x.Session).Returns(session.Object);
            var requestContext = new RequestContext(context.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);
            var userDataAccessMock = new Mock<IUserDataAccess>();
            userDataAccessMock.Setup(x => x.login(user, password)).Returns(userReturn);

            controller.UserDataAccess = userDataAccessMock.Object;
            FormCollection form = new FormCollection();
            form["txtemail"] = user;
            form["txtpassword"] = password;
            ViewResult viewReturn = (ViewResult)controller.login(form);
            ViewResult result = controller.Login() as ViewResult;
            Assert.AreEqual(viewReturn.ViewData["msg"], "Invalid Email or Password...");
        }

        [TestMethod]
        public void CreateUserSuccessfully()
        {
            HomeController controller = new HomeController();
            FormCollection form = new FormCollection();
            form["txtemail"] = "cra1982@gmail.com";
            form["txtpassword"] = "123";
            form["txtpassword2"] = "123";
            var userDataAccessMock = new Mock<IUserDataAccess>();
            userDataAccessMock.Setup(x => x.createUser(form["txtemail"], form["txtpassword"])).Returns(true);
            RedirectToRouteResult viewReturn = (RedirectToRouteResult)controller.CreateUser(form);
            Assert.AreEqual(viewReturn.RouteValues.First().Value, "Index");
        }

        [TestMethod]
        public void CreateUserUnsuccessfully()
        {
            HomeController controller = new HomeController();
            FormCollection form = new FormCollection();
            form["txtemail"] = "cra1982@gmail.com";
            form["txtpassword"] = "123";
            form["txtpassword2"] = "321";
            var userDataAccessMock = new Mock<IUserDataAccess>();
            userDataAccessMock.Setup(x => x.createUser(form["txtemail"], form["txtpassword"])).Returns(true);
            ViewResult viewReturn = controller.CreateUser(form) as ViewResult;
            Assert.AreEqual(viewReturn.ViewData["msg"], "The passwords do not match...");
        }
    }
}
