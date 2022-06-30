using IMSAPI.Dto.PermissionEntities;
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
    [RoutePrefix("api/PermissionEntity")]
    [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
    public class PermissionEntitysController : ApiController
    {
        public PermissionEntitysController()
        {

        }

        [Route("GetPermissionEntities")]
        public IEnumerable<PermissionEntity> GetPermissionEntitys()
        {
            using (var context = new StoreContext())
            {
                var permissionEntity =  context.PermissionEntities.ToList();
                return permissionEntity;
            };


        }

        [Route("CreatePermissionEntity")]
        public async Task<IHttpActionResult> Create(CreatePermissionEntity model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                using (var context = new StoreContext())
                {
                    var permissionEntity = new PermissionEntity() { Name = model.Name,PermissionName = model.Name.Replace(" ","_") };
                    context.PermissionEntities.Add(permissionEntity);
                    await context.SaveChangesAsync();
                    return Ok();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [Route("GetPermissionEntity/{id}")]
        public PermissionEntity GetPermissionEntity(int id)
        {
            using (var context = new StoreContext())
            {
                var permissionEntity = context.PermissionEntities.FirstOrDefault(x => x.Id == id);
                return permissionEntity;
            }
        }
        [Route("UpdatePermissionEntity/{id}")]
        public async Task<IHttpActionResult> Update(CreatePermissionEntity model, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var permissionEntity = context.PermissionEntities.FirstOrDefault(x => x.Id == id);
                            permissionEntity.Name = model.Name;
                            await context.SaveChangesAsync();
                            transaction.Commit();
                            return Ok();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Route("DeletePermissionEntity/{id}")]
        public async Task<IHttpActionResult> Remove(int id)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    var permissionEntity = context.PermissionEntities.FirstOrDefault(x => x.Id == id);
                    context.PermissionEntities.Remove(permissionEntity);
                    await context.SaveChangesAsync();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}