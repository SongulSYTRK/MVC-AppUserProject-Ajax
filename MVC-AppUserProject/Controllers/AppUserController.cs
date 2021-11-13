using MVC_AppUserProject.Models.DataTransferObjects;
using MVC_AppUserProject.Models.Entities.Abstract;
using MVC_AppUserProject.Models.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_AppUserProject.Controllers
{
    public class AppUserController:BaseController
    {
        #region Create


        [HttpGet]
        public ActionResult Create()
        {
            CreateAppUserDTO model = new CreateAppUserDTO();
            model.UserRole = db.UserRoles.Where(x => x.status != Status.Passive).ToList();
            return View(model);
        }


        [HttpPost]
        public ActionResult Create(CreateAppUserDTO model)
        {
            model.UserRole = db.UserRoles.Where(x => x.status != Status.Passive).ToList();
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser();
                appUser.FirstName = model.FirstName;
                appUser.LastName = model.LastName;
                appUser.UserRoleId = model.UserRoleId;

               db.AppUsers.Add(appUser);
               db.SaveChanges();
               ViewBag.alert = 1;
               return View(model);
            }

            else

            {
                ViewBag.alert = 2;
                return View(model);
            }

        }
        #endregion




        #region list

        public ActionResult List()
        {
            var appUserList = db.AppUsers.Where(x => x.status != Status.Passive).ToList();
            return View(appUserList);
        }
        #endregion



        #region Detail
        public ActionResult Details(int id)
        {
            return View(db.AppUsers.FirstOrDefault(x => x.Id == id));
        }
        #endregion



        #region Update

        [HttpGet]
        public ActionResult Update(int id)
        {
            AppUser appUser = db.AppUsers.FirstOrDefault(x=>x.Id==id);
            UpdateAppUserDTO model = new UpdateAppUserDTO();
            model.FirstName = appUser.FirstName;
            model.LastName = appUser.LastName;
            model.UserRole=db.UserRoles.Where(x => x.status != Status.Passive).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(UpdateAppUserDTO model)
        {
            AppUser appUser = db.AppUsers.FirstOrDefault(x => x.Id == model.Id);
            if (ModelState.IsValid)
            {
                appUser.FirstName = model.FirstName;
                appUser.LastName = model.LastName;
                appUser.UserRoleId = model.UserRoleId;
                appUser.UpdateDate = DateTime.Now;
                appUser.status = Status.Modified;                
                db.SaveChanges();
                ViewBag.alert = 1;
                return RedirectToAction("List");
            }
            else 
            {
                ViewBag.alert = 2;
                return View(model);
            }

        }
        #endregion


        #region Delete
        //public ActionResult Delete (int id)
        //{
        //    AppUser appUser = db.AppUsers.FirstOrDefault(x=>x.Id==id);
        //    appUser.status = Status.Passive;
        //    appUser.DeleteDate = DateTime.Now;
        
        //    db.SaveChanges();
        //    ViewBag.alert = 1;
        //    return RedirectToAction("List");
        //}
        public JsonResult Delete(int id)
        {
            AppUser appUser = db.AppUsers.FirstOrDefault(x => x.Id == id);
            appUser.status = Status.Passive;
            appUser.DeleteDate = DateTime.Now;
            db.SaveChanges();
            ViewBag.alert = 1;
            return Json("");
        }
        #endregion
    }
}