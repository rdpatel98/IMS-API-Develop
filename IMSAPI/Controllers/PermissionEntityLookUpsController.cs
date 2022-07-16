using IMSAPI.Dto.PermissionEntityLookUps;
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
    [RoutePrefix("api/PermissionEntityLookUp")]
    [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
    public class PermissionEntityLookUpsController : ApiController
    {
        public PermissionEntityLookUpsController()
        {

        }

        [Route("GetPermissionEntityLookUps")]
        public IEnumerable<PermissionEntityLookUp> GetPermissionEntityLookUp()
        {
            var context = new StoreContext();
            return context.PermissionEntityLookUps.ToList();
        }

        [Route("GetPermissionEntityLookUpList")]
        public IEnumerable<PermissionEntityLookUpList> GetPermissionEntityLookUpList()
        {
            var context = new StoreContext();
            var result = new List<PermissionEntityLookUpList>();
            var permissions = context.PermissionEntityLookUps.Include(x=>x.PermissionEntity).Select(x=>x.PermissionEntity).Distinct().ToList();
            foreach(var permission in permissions)
            {
                var data = new PermissionEntityLookUpList()
                {
                    EntityId = permission.Id,
                    EntityName = permission.Name,
                    LookUpNames = string.Join(", ",context.PermissionEntityLookUps.Include(x=>x.Lookup).Where(x=>x.PermissionEntityId == permission.Id).Select(x=>x.Lookup.Name).ToList())
                };
                result.Add(data);
            }
            return result;
        }

        [Route("GetPermissionEntities")]
        public IEnumerable<PermissionEntity> GetPermissionEntities()
        {
            var context = new StoreContext();
            return context.PermissionEntities.ToList();
        }

        [Route("GetLookUps")]
        public IEnumerable<Lookup> GetLookUps()
        {
            var context = new StoreContext();
            return context.Lookups.ToList();
        }

        [Route("CreatePermissionEntityLookUp")]
        public async Task<IHttpActionResult> Create(CreatePermissionEntityLookUp model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                using (var context = new StoreContext())
                {
                    foreach(var lookup in model.LookUpIds)
                    {
                        var isExistData = context.PermissionEntityLookUps.Any(x => x.PermissionEntityId == model.EntityId && x.LookupId == lookup);
                        if(!isExistData)
                        {
                            var permissionEntityLookUp = new PermissionEntityLookUp() { PermissionEntityId = model.EntityId, LookupId = lookup };
                            context.PermissionEntityLookUps.Add(permissionEntityLookUp);
                            await context.SaveChangesAsync();
                        }
                    }
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("GetPermissionEntityLookUp/{id}")]
        public PermissionEntityLookUp GetPermissionEntityLookUp(int id)
        {
            using (var context = new StoreContext())
            {
                var role = context.PermissionEntityLookUps.FirstOrDefault(x=>x.Id == id);
                return role;
            }
        }
       
        [Route("GetPermissionEntityLookUpByEntityId/{entityId}")]
        public CreatePermissionEntityLookUp GetPermissionEntityLookUpByEntityId(int entityId)
        {
            using (var context = new StoreContext())
            {
                var permissions = context.PermissionEntityLookUps
                    .Where(x => x.PermissionEntityId == entityId).Select(x=>x.LookupId).ToList();
                return new CreatePermissionEntityLookUp()
                {
                    EntityId = entityId,
                    LookUpIds = permissions
                };
            }
        }

        [Route("UpdatePermissionEntityLookUp")]
        public async Task<IHttpActionResult> Update(CreatePermissionEntityLookUp model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                using (var context = new StoreContext())
                {
                    var oldData = context.PermissionEntityLookUps.Include(x=>x.Role_PermissionEntityLookUps).Where(x => x.PermissionEntityId == model.EntityId).ToList();
                    foreach(var data in oldData.Select(x => x.Role_PermissionEntityLookUps))
                    {
                        context.Role_PermissionEntityLookUps.RemoveRange(data);
                        await context.SaveChangesAsync();
                    }
                    context.PermissionEntityLookUps.RemoveRange(oldData);
                    await context.SaveChangesAsync();

                    foreach (var lookup in model.LookUpIds)
                    {
                        var permissionEntityLookUp = new PermissionEntityLookUp() { PermissionEntityId = model.EntityId, LookupId = lookup };
                        context.PermissionEntityLookUps.Add(permissionEntityLookUp);
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

        [Route("DeletePermissionEntityLookUpByEntity/{entityId}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Remove(int entityId)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    var oldData = context.PermissionEntityLookUps.Include(x => x.Role_PermissionEntityLookUps).Where(x => x.PermissionEntityId == entityId).ToList();
                    foreach (var data in oldData.Select(x => x.Role_PermissionEntityLookUps))
                    {
                        context.Role_PermissionEntityLookUps.RemoveRange(data);
                        await context.SaveChangesAsync();
                    }
                    context.PermissionEntityLookUps.RemoveRange(oldData);
                    if (await context.SaveChangesAsync() > 0)
                    {
                        return GetErrorResult(await context.SaveChangesAsync() > 0);
                    }

                    return Ok();
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