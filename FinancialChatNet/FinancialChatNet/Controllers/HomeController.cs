using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transversal.Models;
using RabbitMQ.Client;
using RabbitMQ.Util;
using Transversal.RabbitMQ;
using Data;
using System.Web.UI.WebControls;
using Data.Interfaces;

namespace FinancialChatNet.Controllers
{
    public class HomeController : Controller
    {
        private IUserDataAccess userDataAccess;
        private IMessagesDataAccess messageDataAccess;

        public IUserDataAccess UserDataAccess
        {
            get
            {
                return userDataAccess ?? new UserDataAccess();
            }

            set {
                userDataAccess = value;
            }
        }

        public IMessagesDataAccess MessageDataAccess
        {
            get
            {
                return messageDataAccess ?? new MessagesDataAccess();
            }

            set {
                messageDataAccess = value;
            }
        }

       
        

        public ActionResult Index()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpPost]
        public JsonResult sendmsg(string message, string friend)
        {
            rabbitMq obj = new rabbitMq();
            IConnection con = obj.GetConnection();
            bool flag = obj.send(con, message, friend, Session["username"].ToString());
            return Json(null);
        }

        [HttpPost]
        public JsonResult receive()
        {
            try
            {
                rabbitMq obj = new rabbitMq();
                IConnection con = obj.GetConnection();
                string userqueue = Session["username"].ToString();
                string message = obj.receive(con, userqueue);
                return Json(message);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult login(FormCollection fc)
        {
            string email = fc["txtemail"].ToString();
            string password = fc["txtpassword"].ToString();
            UserModel user = UserDataAccess.login(email, password);
            if (user.id > 0)
            {
                ViewData["status"] = 1;
                ViewData["msg"] = "login Successful...";
                Session["username"] = user.email;
                Session["id"] = user.id.ToString();
                return RedirectToAction("Index");
            }
            else
            {

                ViewData["status"] = 2;
                ViewData["msg"] = "Invalid Email or Password...";
                return View();
            }
        }

        [HttpPost]
        public JsonResult friendlist()
        {
            List<UserModel> users = UserDataAccess.getListUser(Session["id"].ToString());
            List<ListItem> userlist = new List<ListItem>();
            foreach (var item in users)
            {
                userlist.Add(new ListItem
                {
                    Value = item.email.ToString(),
                    Text = item.email.ToString()

                });
            }
            return Json(userlist);
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(FormCollection fc)
        {            
            if(fc["txtpassword"].ToString() != fc["txtpassword2"].ToString())
            {
                ViewData["status"] = 2;
                ViewData["msg"] = "The passwords do not match...";
                return View();
            }

            bool createState = UserDataAccess.createUser(fc["txtemail"].ToString(), fc["txtpassword"].ToString());

            if (createState)
            {
                ViewData["status"] = 1;
                ViewData["msg"] = "User created Successful...";
                return RedirectToAction("Index");
            } else
            {
                ViewData["status"] = 2;
                ViewData["msg"] = "Error, the user was not created...";
                return View();
            }
        }
        
        public JsonResult getMyMessage() {
            return Json(MessageDataAccess.getMessageByProducer(Session["username"].ToString()));
        }

        [HttpPost]
        public JsonResult saveMessage(string consumer, string message) {
            MessageModel messageAdd = new MessageModel();
            messageAdd.producer = Session["username"].ToString();
            messageAdd.consumer = consumer;
            messageAdd.message = message;
            MessageDataAccess.addMessage(messageAdd);
            return Json(true);
        }

        public ActionResult userProfile()
        {
            return View();
        }
        
    }
}