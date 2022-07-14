using IMSAPI.Dto.LookUps;
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
    [RoutePrefix("api/LookUp")]
    [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
    public class LookUpsController : ApiController
    {
        public LookUpsController()
        {

        }

        [Route("GetLookUps")]
        public IEnumerable<Lookup> GetLookUps()
        {
            using (var context = new StoreContext())
            {
                var lookups = context.Lookups.ToList();
                return lookups;
            };


        }

        [Route("CreateLookUp")]
        public async Task<IHttpActionResult> Create(CreateLookUp model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                using (var context = new StoreContext())
                {
                    var lookupExist = context.Lookups.Where(x => x.Name.ToLower() == model.Name.ToLower());
                    if (lookupExist.Any())
                    {
                        throw new Exception("LookUp Name already exist in system");
                    }
                    var lookup = new Lookup() { Name = model.Name, PermissionName = model.Name.Replace(" ", "_") };
                    context.Lookups.Add(lookup);
                    await context.SaveChangesAsync();
                    return Ok();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [Route("GetLookUp/{id}")]
        public Lookup GetLookUp(int id)
        {
            using (var context = new StoreContext())
            {
                var lookup = context.Lookups.FirstOrDefault(x => x.Id == id);
                return lookup;
            }
        }
        [Route("UpdateLookUp/{id}")]
        public async Task<IHttpActionResult> Update(CreateLookUp model, int id)
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
                            var lookup = context.Lookups.FirstOrDefault(x => x.Id == id);
                            lookup.Name = model.Name;
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

        [Route("DeleteLookUp/{id}")]
        public async Task<IHttpActionResult> Remove(int id)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    var lookup = context.Lookups.FirstOrDefault(x => x.Id == id);
                    context.Lookups.Remove(lookup);
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
