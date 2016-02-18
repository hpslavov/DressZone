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

namespace DressZone.Server.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : AdminBaseController
    {
        private IAdminUserService userService;

        public UserController(IAdminUserService service)
        {
            this.userService = service;
        }

        [HttpGet]
        public ActionResult All()
        {
            return View();
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
                user.Role = this.userService.GetRole(user.Email);
            }
            return Json(allUsers.ToDataSourceResult(categoriesModel));
        }

        public ActionResult UpdateExisting()
        {
            return null;
        }

        public ActionResult Delete()
        {
            return null;
        }
    }
}