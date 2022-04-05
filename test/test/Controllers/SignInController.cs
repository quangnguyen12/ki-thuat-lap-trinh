using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;


namespace test.Controllers
{
    public class SignInController : Controller
    {
         DBusersignuploginEntities db = new DBusersignuploginEntities();    

        // GET: SignIn
        public ActionResult Dbuserinfo()
        {
            return View(db.tblUserInfoes.ToList());
        }
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(tblUserInfo tblUserinfo)
        {
            if (db.tblUserInfoes.Any(x=>x.usernameus==tblUserinfo.usernameus))
            {
                ViewBag.Notification = "Tai khoan nafy da duoc dang ki boi nguoi dung truoc";
                return View();
            }
            else
            {
                db.tblUserInfoes.Add(tblUserinfo);
                db.SaveChanges();
                Session ["IdUsSs"]= tblUserinfo.iduser.ToString();
                Session ["UsernameSs"] = tblUserinfo.usernameus.ToString();
                return RedirectToAction("Index", "Home");
            }
        }


    }
}