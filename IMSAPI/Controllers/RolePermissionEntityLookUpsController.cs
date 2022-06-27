using IMSAPI.Dto.RolePermissionEntityLookUps;
using IMSAPI.Models;
using IMSAPI.Models.UnboxFutureContext;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace IMSAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Role_PermissionEntityLookUp")]
    [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
    public class RolePermissionEntityLookUpsController : ApiController
    {
        public RolePermissionEntityLookUpsController()
        {

        }
        [Route("GetRolePermissionEntityLookUps")]
        public IEnumerable<Role_PermissionEntityLookUp> GetPermissionEntityLookUp()
        {
            var context = new StoreContext();
            return context.Role_PermissionEntityLookUps.ToList();
        }

        [Route("CreateRolePermissionEntityLookUp")]
        public async Task<IHttpActionResult> Create(CreateRolePermissionEntityLookUp model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                using (var context = new StoreContext())
                {
                    foreach (var roleId in model.RoleIds)
                    {
                        var role_PermissionEntityLookUp = new Role_PermissionEntityLookUp() { PermissionEntityLookupId = model.PermissionEntityLookUpId, RoleId = roleId };
                        context.Role_PermissionEntityLookUps.Add(role_PermissionEntityLookUp);
                        await context.SaveChangesAsync();
                    }
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("GetRolePermissionEntityLookUp/{id}")]
        public Role_PermissionEntityLookUp GetRolePermissionEntityLookUp(int id)
        {
            using (var context = new StoreContext())
            {
                var role = context.Role_PermissionEntityLookUps.FirstOrDefault(x => x.Id == id);
                return role;
            }
        }

        [Route("UpdateRolePermissionEntityLookUp/{id}")]
        public async Task<IHttpActionResult> Update(CreateRolePermissionEntityLookUp model, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                using (var context = new StoreContext())
                {
                    foreach (var roleId in model.RoleIds)
                    {
                        var oldData = context.Role_PermissionEntityLookUps.Where(x => x.PermissionEntityLookupId == model.PermissionEntityLookUpId);
                        context.Role_PermissionEntityLookUps.RemoveRange(oldData);
                        await context.SaveChangesAsync();

                        var role_PermissionEntityLookUp = new Role_PermissionEntityLookUp() { PermissionEntityLookupId = model.PermissionEntityLookUpId, RoleId = roleId };
                        context.Role_PermissionEntityLookUps.Add(role_PermissionEntityLookUp);
                        await context.SaveChangesAsync();
                    }
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("DeletePermissionEntityLookUp/{id}")]
        public async Task<IHttpActionResult> Remove(int id)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    var role = await context.Role_PermissionEntityLookUps.FirstOrDefaultAsync(x => x.Id == id);
                    var result = context.Role_PermissionEntityLookUps.Remove(role);
                    if (result.Id > 0)
                    {
                        return GetErrorResult(result.Id > 0);
                    }

                    return Ok();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("Permission")]
        public async Task<List<string>> GetPermission()
        {
            try
            {
                using (var context = new StoreContext())
                {

                    var userRoles = context.AppUserRoles.Where(x => x.UserId == Convert.ToInt32(User.Identity.GetUserId()));
                    return await (from userRole in userRoles
                                  join role_PermissionEntityLookUps in context.Role_PermissionEntityLookUps on userRole.RoleId equals role_PermissionEntityLookUps.RoleId
                                  join permissionEntityLookUp in context.PermissionEntityLookUps on role_PermissionEntityLookUps.PermissionEntityLookupId equals permissionEntityLookUp.Id
                                  join permissionEntity in context.PermissionEntities on permissionEntityLookUp.PermissionEntityId equals permissionEntity.Id
                                  join lookup in context.Lookups on permissionEntityLookUp.LookupId equals lookup.Id
                                  select string.Join(".", permissionEntity.PermissionName, lookup.PermissionName)).AsNoTracking().ToListAsync();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("{id}")]
        public RolePermissionSearchResponse GetRoleRightByRole(int id)
        {
            var response = new RolePermissionSearchResponse();
            try
            {
                using (var context = new StoreContext())
                {
                    //response.RoleId = id;                    
                    var entities = context.PermissionEntities.ToList();
                    var permissionLookupEntities = context.PermissionEntityLookUps.Include(x => x.Lookup).ToList();
                    var rolePermissionEntityLookups = context.Role_PermissionEntityLookUps.Where(x => x.RoleId == id).ToList();
                    var result = entities.Select(x => new PermissionTreeView()
                    {
                        Text = x.Name,
                        Value = x.Id,
                        Children = permissionLookupEntities.Where(y => y.PermissionEntityId == x.Id).Select(z => new PermissionTreeView()
                        {
                            Value = z.Id,
                            Text = z.Lookup.Name,
                            Checked = rolePermissionEntityLookups.Any(a => a.PermissionEntityLookupId == z.Id)
                        }).ToList()
                    });

                    response.PermissionList = result;
                    //_userRepository.GetRightList().Where(x => !x.ParentId.HasValue).Select(x => RoleRightMap.GetRightTreeView(x, roleId)).ToArray();
                    if (response.PermissionList == null)
                        return new RolePermissionSearchResponse { Result = RolePermissionSearchResult.CannotGetListPermission };
                    response.Result = RolePermissionSearchResult.Success;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        [Route("SaveRolePermission")]
        public SaveRolePermissionResult SaveRolePermissionByRole(SaveRolePermissionRequest request)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    var rolePermissionEntityLookups = context.Role_PermissionEntityLookUps.Where(x => x.RoleId == request.RoleId).ToList();
                    context.Role_PermissionEntityLookUps.RemoveRange(rolePermissionEntityLookups);
                    context.SaveChanges();

                    foreach (var rolePermission in request.PermissionEntityLookUps)
                    {
                        var model = new Role_PermissionEntityLookUp()
                        {
                            RoleId = request.RoleId,
                            PermissionEntityLookupId = rolePermission
                        };
                        context.Role_PermissionEntityLookUps.Add(model);
                        context.SaveChanges();
                    }
                    return SaveRolePermissionResult.Success;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private IHttpActionResult GetErrorResult(bool result)
        {
            if (result == false)
            {
                return InternalServerError();
            }

            if (!result)
            {

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
