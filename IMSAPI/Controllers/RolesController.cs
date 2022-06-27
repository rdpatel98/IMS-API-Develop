using IMSAPI.Dto.Roles;
using IMSAPI.Models;
using IMSAPI.Models.UnboxFutureContext;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using static IMSAPI.Controllers.AccountController;

namespace IMSAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Role")]
    [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
    public class RolesController : ApiController
    {
        public RolesController()
        {

        }

        private ApplicationRoleManager _roleManager;
        private ApplicationUserManager _userManager;

        public RolesController(ApplicationRoleManager roleManager,
                               ApplicationUserManager userManager)
        {
            RoleManager = roleManager;
            UserManager = userManager;
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? Request.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [Route("GetRoles")]
        public IEnumerable<AppRole> GetRoles()
        {
            var context = new StoreContext();
            var user = UserManager.FindById(Convert.ToInt32(User.Identity.GetUserId()));
            var orgs = context.UserOrganizations.Where(x => x.UserId == user.Id).Select(x => x.OrganizationId).ToList();
            var roles = RoleManager.Roles.ToList();
            if (orgs.Any())
            {
                roles = roles.Where(x => x.OrganizationId.HasValue && orgs.Contains(x.OrganizationId.Value)).ToList();
            }
            
            return roles.ToList();
        }
        [Route("CreateRole")]
        public async Task<IHttpActionResult> Create(CreateRole model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var context = new StoreContext();
                //var user = UserManager.FindById(Convert.ToInt32(User.Identity.GetUserId()));
                var role = new AppRole() { Name = model.Name, OrganizationId = model.OrganizationId };

                IdentityResult result = await RoleManager.CreateAsync(role);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [Route("GetRole/{id}")]
        public AppRole GetRole(int id)
        {
            var role = RoleManager.FindById(id);
            return role;
        }
        [Route("UpdateRole/{id}")]
        public async Task<IHttpActionResult> Update(CreateRole model, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var context = new StoreContext();
                //var user = UserManager.FindById(Convert.ToInt32(User.Identity.GetUserId()));
                var role = await RoleManager.FindByIdAsync(id);
                role.Name = model.Name;
                role.OrganizationId = model.OrganizationId;
                IdentityResult result = await RoleManager.UpdateAsync(role);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("DeleteRole/{id}")]
        public async Task<IHttpActionResult> Remove(int id)
        {
            try
            {
                var role = await RoleManager.FindByIdAsync(id);
                var result = await RoleManager.DeleteAsync(role);
                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

    }
}
