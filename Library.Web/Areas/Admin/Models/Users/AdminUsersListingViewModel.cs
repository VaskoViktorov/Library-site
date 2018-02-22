namespace Library.Web.Areas.Admin.Models.Users
{
    using Common.Mapping;
    using Data.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services.Admin.Models;
    using System.Collections.Generic;
    using LibraryBlog.Models.Search;
    public class AdminUsersListingViewModel : SearchFormModel, IMapFrom<User>
    {
        public IEnumerable<AdminUserServiceListingModel> Users { get; set; }

        public Dictionary<string, List<string>> UserRoles { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}