namespace Library.Web.Areas.Admin.Controllers
{
    using Data.Models;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Models.Users;
    using Services.Admin;
    using System.Linq;
    using System.Threading.Tasks;

    using static WebConstants;

    public class UsersController : BaseController
    {
        private readonly IAdminUserService users;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsersController(IAdminUserService users, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.users = users;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var allUsers = await this.users.AllAsync();

            var roles = await this.roleManager
                .Roles
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                })
                .ToListAsync();

            var userRoles = await this.users.UsersInRoleAsync();

            return this.View(new AdminUsersListingViewModel
            {
                Users = allUsers,
                Roles = roles,
                UserRoles = userRoles
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddToRole(AddUserToRoleFormModel model)
        {

            var roleExists = await this.roleManager.RoleExistsAsync(model.Role);
            var user = await this.userManager.FindByIdAsync(model.UserId);
            var userExists = user != null;

            if (!roleExists || !userExists)
            {
                this.ModelState.AddModelError(string.Empty, ErrorMsgInvalidIdentity);
            }

            if (!this.ModelState.IsValid)
            {
                this.RedirectToAction(nameof(this.Index));
            }

            if (this.Request.Form.ContainsKey(AddRequestKey))
            {
                if (await this.userManager.IsInRoleAsync(user, model.Role))
                {
                    this.TempData.AddWarningMessage(string.Format(WarrningUserAlreadyInRole, user.UserName, model.Role));

                    return this.RedirectToAction(nameof(this.Index));
                }

                await this.userManager.AddToRoleAsync(user, model.Role);

                this.TempData.AddSuccessMessage(string.Format(SuccessUserAddedToRole, user.UserName, model.Role));
            }

            if (this.Request.Form.ContainsKey(RemoveRequestKey))
            {
                if (!await this.userManager.IsInRoleAsync(user, model.Role))
                {
                    this.TempData.AddWarningMessage(string.Format(WarrningUserNotInRole, user.UserName, model.Role));

                    return this.RedirectToAction(nameof(this.Index));
                }

                await this.userManager.RemoveFromRoleAsync(user, model.Role);

                this.TempData.AddSuccessMessage(string.Format(SuccessUserRemovedFromRole, user.UserName, model.Role));
            }

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}