using DressZone.Server.Areas.Admin.Models.ViewModels.Users;
using DressZone.Server.Infrastructure.Mapping.Contracts;
using DressZone.Services.Contracts;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DressZone.Models.Account;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Security;

namespace DressZone.Server.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : AdminBaseController
    {
        private IAdminUserService userService;
        private ApplicationUserManager _userManager;

        public UserController(IAdminUserService service)
        {
            this.userService = service;
        }

        [HttpGet]
        public ActionResult All()
        {
            return View();
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        [HttpPost]
        public ActionResult All([DataSourceRequest]DataSourceRequest categoriesModel)
        {
            if (!this.ModelState.IsValid)
            {

            }
            var allUsers = this.userService.GetAll().To<GridViewUserViewModel>().ToList();
            foreach (var user in allUsers)
            {
                user.Role = this.userService.GetRole(user.Email).Name;
            }
            return Json(allUsers.ToDataSourceResult(categoriesModel));
        }

        [HttpPost]
        public ActionResult Create()
        {
            return null;
        }

        [HttpPost]
        public ActionResult UpdateExisting([DataSourceRequest]DataSourceRequest request, GridViewUserViewModel userModel)
        {
            var currentRole = this.userService.GetRole(userModel.Email);
            var userFromDb = userService.GetByEmail(userModel.Email);

            var userManager = this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            userManager.RemoveFromRole(userFromDb.Id, currentRole.Name);
            userManager.AddToRole(userFromDb.Id, userModel.Role);

            this.userService.EditUser(userFromDb);
           
            var resultViewModel = this.Mapper.Map<GridViewUserViewModel>(userFromDb);
            resultViewModel.Role = this.userService.GetRole(resultViewModel.Email).Name;

            var result = new[] { resultViewModel }.ToDataSourceResult(request, ModelState);
            return Json(result);

        }

        [HttpPost]
        public ActionResult Delete([DataSourceRequest]DataSourceRequest request, GridViewUserViewModel categoryModel)
        {
            if (categoryModel != null)
            {
            }
            var userToDelete = this.userService.GetByEmail(categoryModel.Email);
            var deletedUser = this.userService.Delete(userToDelete);
            var result = new[] { deletedUser }.ToDataSourceResult(request, ModelState);
            return Json(result);
        }
    }
}