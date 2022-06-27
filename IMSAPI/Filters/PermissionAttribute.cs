using IMSAPI.Models.UnboxFutureContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace IMSAPI.Filters
{
    public class PermissionAttribute : ActionFilterAttribute
    {
        public PermissionAttribute(params string[] permissions)
        {
            this.Permissions = permissions;
        }

        public string[] Permissions { get; set; }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var data = ClaimsPrincipal.Current.Identities.First().Claims.FirstOrDefault(x => x.Issuer.Equals("LOCAL AUTHORITY", StringComparison.OrdinalIgnoreCase))?.Value;
            var id = Convert.ToInt32(data);
            var contoller = (actionContext.ControllerContext.Controller as ApiController);
            using (var context = new StoreContext())
            {

                var userRoles = context.AppUserRoles.Where(x => x.UserId == id);
                var permissionSelect = (from userRole in userRoles
                                        join role_PermissionEntityLookUps in context.Role_PermissionEntityLookUps on userRole.RoleId equals role_PermissionEntityLookUps.RoleId
                                        join permissionEntityLookUp in context.PermissionEntityLookUps on role_PermissionEntityLookUps.PermissionEntityLookupId equals permissionEntityLookUp.Id
                                        join permissionEntity in context.PermissionEntities on permissionEntityLookUp.PermissionEntityId equals permissionEntity.Id
                                        join lookup in context.Lookups on permissionEntityLookUp.LookupId equals lookup.Id
                                        select new { permissionName = permissionEntity.PermissionName, lookupName = lookup.PermissionName }).AsNoTracking().AsEnumerable();
                var permissions = permissionSelect.AsEnumerable().Select(x => string.Join(".", x.permissionName, x.lookupName)).ToList();
                if (permissions.Any())
                {
                    foreach (var permission in Permissions)
                    {
                        if (!permissions.Contains(permission))
                        {
                            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                        }
                    }
                }
                else
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}