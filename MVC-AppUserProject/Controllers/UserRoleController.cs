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
    public class UserRoleController : BaseController
    {
        #region CREATE

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Create(CreateUserRoleDTO model)
        {
            model.UserRoles = db.UserRoles.Where(x => x.status != Status.Passive).ToList();
            if(ModelState.IsValid)
            {
                UserRole userRole = new UserRole();
                userRole.RoleName = model.RoleName;
                userRole.Salery = model.Salery;
                userRole.Description = model.Description;
                userRole.CreateDate = DateTime.Now;
                db.UserRoles.Add(userRole);
                db.SaveChanges();
                ViewBag.alert = 1;
                return Json(userRole);

            }
            else
            {
                return Json(model);
            }
        }
        #endregion



        #region LİST
        public ActionResult List()
        {
            var RoleList = db.UserRoles.Where(x => x.status != Status.Passive).ToList();
            return View(RoleList);
        }
        #endregion


        #region DELETE
        public JsonResult Delete(int id)
        {
            UserRole userrole = db.UserRoles.FirstOrDefault(x=>x.Id==id);
            userrole.status = Status.Passive;
            userrole.DeleteDate = DateTime.Now;
            db.SaveChanges();
            ViewBag.alert = 1;
            return Json("");

        }

        #endregion

        #region DETAİL
        public ActionResult Details(int id)
        {
            return View(db.UserRoles.FirstOrDefault(x => x.Id == id));
        }

        #endregion

        #region UPDATE
        public ActionResult Update(int id)
        {
            UserRole UserRole = db.UserRoles.FirstOrDefault(x => x.Id == id);
            UpdateUserRoleDTO model = new UpdateUserRoleDTO();
            model.RoleName = UserRole.RoleName;
            model.Description = UserRole.Description;
            model.Salery = UserRole.Salery;
            model.UserRole = db.UserRoles.Where(x =>x.status != Status.Passive).ToList();
            return View(model);
        }

        [HttpPost]
        public JsonResult Update(UpdateUserRoleDTO model)
        {
            UserRole UserRole = db.UserRoles.FirstOrDefault(x => x.Id == model.Id);
            if (ModelState.IsValid)
            {
                UserRole.RoleName = model.RoleName;
                UserRole.Description = model.Description;
                UserRole.Salery = model.Salery;
                UserRole.UpdateDate = DateTime.Now;
                UserRole.status = Status.Modified;
                db.SaveChanges();
                ViewBag.alert = 1;
                return Json(UserRole)
            }
            else
            {
                ViewBag.alert = 2;
                return Json(model);
            }
        }
            #endregion
        }
}