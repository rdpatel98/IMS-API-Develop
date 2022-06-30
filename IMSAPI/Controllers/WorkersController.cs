using IMSAPI.Dto.Roles;
using IMSAPI.ExceptionHandling;
using IMSAPI.Models;
using IMSAPI.Models.UnboxFutureContext;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
    [RoutePrefix("api/Worker")]
    [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
    public class WorkersController : ApiController
    {
        public string connStr = ConfigurationManager.ConnectionStrings["StoreContext"].ConnectionString;
        public WorkersController()
        {

        }

        private ApplicationRoleManager _roleManager;
        private ApplicationUserManager _userManager;

        public WorkersController(ApplicationRoleManager roleManager,
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

        [Route("ListWorker")]
        [HttpGet]
        public ApiResponse GetAllWorker()
        {
            using (var context = new StoreContext())
            {

                var resultList = context.Workers.Where(e => e.Status == 1).AsEnumerable()
                    .Select(x => new CreateWorkerDto()
                    {
                        Name = x.Name,
                        DOB = x.DOB,
                        DOJ = x.DOJ,
                        Password = x.Password,
                        PersonnelNumber = x.PersonnelNumber,
                        Status = 1,
                        UpdatedDateTime = DateTime.UtcNow,
                        UpdatedUserId = -1,
                        OrganizationIds = GetOrganizationIdsbyWorker(x.WorkerId),
                        IsBlocked = false,
                        RoleId = Convert.ToInt32(GetRoleIdbyWorker(x.WorkerId)),
                        Email = Convert.ToString(GetEmailbyWorker(x.WorkerId)),
                        UserId = x.UserId,
                        WorkerId = x.WorkerId
                    }).ToList();
                return CommonUtils.CreateSuccessApiResponse(resultList);
            }
        }

        private int GetRoleIdbyWorker(int workerid)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    var user = UserManager.Users.FirstOrDefault(x => x.WorkerId == workerid);
                    if (user != null)
                    {
                        var userRole = UserManager.GetRoles(user.Id).FirstOrDefault();
                        var role = RoleManager.FindByName(userRole);
                        return role.Id;
                    }
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private List<int> GetOrganizationIdsbyWorker(int workerid)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    var user = UserManager.Users.FirstOrDefault(x => x.WorkerId == workerid);
                    //var user = UserManager.FindById(Convert.ToInt32(User.Identity.GetUserId()));


                    if (user != null)
                    {
                        var userOrganizationIds = context.UserOrganizations.Where(x => x.UserId == user.Id).Select(x => x.OrganizationId);
                        //var userRole = UserManager.GetRoles(user.Id).FirstOrDefault();
                        //var role = RoleManager.FindByName(userRole);
                        //return role.Id;
                        return userOrganizationIds.ToList();
                    }
                    return new List<int>();




                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string GetEmailbyWorker(int workerid)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    var user = UserManager.Users.FirstOrDefault(x => x.WorkerId == workerid);
                    if (user != null)
                    {
                        return user.Email;
                    }
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Route("GetWorkerByID")]
        [HttpGet]
        public ApiResponse GetWorkerById(int workerid)
        {
            using (var context = new StoreContext())
            {
                try
                {
                    var user = UserManager.Users.FirstOrDefault(x => x.WorkerId == workerid);
                    var userRole = UserManager.GetRoles(user.Id).FirstOrDefault();
                    var role = RoleManager.FindByName(userRole);
                    var saveWorker = new SaveWorker
                    {
                        Addresses = new List<Addresses>(),

                        Worker = context.Workers.Where(e => e.WorkerId == workerid).Select(x => new CreateWorkerDto()
                        {
                            Name = x.Name,
                            DOB = x.DOB,
                            DOJ = x.DOJ,
                            Password = x.Password,
                            PersonnelNumber = x.PersonnelNumber,
                            Status = 1,
                            UpdatedDateTime = DateTime.UtcNow,
                            UpdatedUserId = -1,
                            //OrganizationId = x.OrganizationId,
                            IsBlocked = false,
                            RoleId = role.Id,
                            Email = user.Email,
                            UserId = x.UserId,
                            WorkerId = workerid
                        }).FirstOrDefault()
                    };
                    var addressRelation = context.WorkerAddresses.Where(x => x.WorkerId == workerid).ToList();

                    foreach (var relation in addressRelation)
                    {
                        var orgAddress = context.Addresses.FirstOrDefault(x => x.AddressId == relation.AddressId && x.Status == 1);
                        saveWorker.Addresses.Add(orgAddress);
                    }

                    return CommonUtils.CreateSuccessApiResponse(saveWorker);
                }
                catch (Exception ex)
                {
                    return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                }
            }
        }

        [Route("DeleteWorker")]
        [HttpPost]
        public ApiResponse DeleteWorker(int workerid)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var item = context.Workers.FirstOrDefault(e => e.WorkerId == workerid);
                            if (item != null)
                            {
                                item.UpdatedUserId = -1;
                                item.UpdatedDateTime = DateTime.UtcNow;
                                item.Status = 0;
                                context.SaveChanges();
                            }

                            transaction.Commit();

                            return CommonUtils.CreateSuccessApiResponse(workerid);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            ExceptionHandledLogger.Log(ex);
                            return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandledLogger.Log(ex);
                return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
            }
        }

        [Route("AddWorker")]
        [HttpPost]
        public ApiResponse AddWorker(SaveWorker saveWorker)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    var result = false;
                    var passwordHash = UserManager.PasswordHasher.HashPassword(saveWorker.Worker.Password);
                    var securityStamp = Guid.NewGuid().ToString();
                    var sqlQuery =
                        $"DECLARE @workId INT;" +
                        $"DECLARE @userId INT;" +
                        $"insert into Worker Values('{saveWorker.Worker.Name}','{saveWorker.Worker.PersonnelNumber}','{saveWorker.Worker.DOJ.ToString("yyyy-MM-dd hh:mm:ss")}','{saveWorker.Worker.DOB.ToString("yyyy-MM-dd hh:mm:ss")}','{saveWorker.Worker.UserId}','{saveWorker.Worker.Password}',{-1},'{DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss")}',{1},{0})" +
                        $"SET @workId = SCOPE_IDENTITY()" +
                        $"INSERT [dbo].[AspNetUsers] ([Email], [EmailConfirmed], [PasswordHash], [SecurityStamp],[PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled]," +
                        $"[AccessFailedCount], [UserName],[WorkerId])   " +
                        $"VALUES(N'{saveWorker.Worker.Email}', 1,N'{passwordHash}',N'{securityStamp}', NULL, 0, 0, NULL, 0, 0, N'{saveWorker.Worker.UserId}', @workId)" +
                        $"SET @userId = SCOPE_IDENTITY()" +
                        $"insert into AspNetUserRoles values(@userId,{saveWorker.Worker.RoleId})";
                    if (saveWorker.Worker.OrganizationIds != null && saveWorker.Worker.OrganizationIds.Any())
                    {
                        foreach (var organizationId in saveWorker.Worker.OrganizationIds)
                        {
                            sqlQuery = sqlQuery +
                                $"insert into UserOrganizations values(@userId,{organizationId})";
                        }
                    }
                    var con = new SqlConnection(connStr);
                    con.Open();

                    using (var command = new SqlCommand(sqlQuery, con))
                    {
                        command.CommandType = CommandType.Text;

                        using (var reader = command.ExecuteReader())
                        {
                            result = true;
                        }
                    }

                    con.Close();
                    return CommonUtils.CreateSuccessApiResponse(result);
                    //using (var transaction = context.Database.BeginTransaction())
                    //{
                    //    try
                    //    {
                    //        var user = UserManager.FindById(Convert.ToInt32(User.Identity.GetUserId()));
                    //        var worker = new Worker()
                    //        {
                    //            Name = saveWorker.Worker.Name,
                    //            DOB = saveWorker.Worker.DOB,
                    //            DOJ = saveWorker.Worker.DOJ,
                    //            Password = saveWorker.Worker.Password,
                    //            PersonnelNumber = saveWorker.Worker.PersonnelNumber,
                    //            Status = 1,
                    //            UserId = saveWorker.Worker.UserId,
                    //            UpdatedDateTime = DateTime.UtcNow,
                    //            UpdatedUserId = -1,
                    //            OrganizationId = saveWorker.Worker.OrganizationId,
                    //            IsBlocked = false
                    //        };
                    //        var work = context.Workers.Add(worker);
                    //        context.SaveChanges();
                    //        if (work.WorkerId > 0)
                    //        {
                    //            var newUser = new ApplicationUser()
                    //            {
                    //                UserName = work.UserId,
                    //                Email = work.UserId,
                    //                EmailConfirmed = true,
                    //                OrganizationId = user.OrganizationId,
                    //                WorkerId = work.WorkerId
                    //            };
                    //            var result = CreateUser(newUser, saveWorker.Worker.Password, saveWorker.Worker.RoleId);
                    //            //var result = UserManager.CreateAsync(newUser, saveWorker.Worker.Password).Result;
                    //            if (result)
                    //            {
                    //                var createdUser = UserManager.Users.FirstOrDefault(x => x.UserName == newUser.UserName);
                    //                var defaultrole = RoleManager.FindByIdAsync(saveWorker.Worker.RoleId).Result;
                    //                if (defaultrole != null)
                    //                {
                    //                    IdentityResult roleresult = UserManager.AddToRole(createdUser.Id, defaultrole.Name);
                    //                }
                    //            }
                    //        }
                    //        transaction.Commit();
                    //        return CommonUtils.CreateSuccessApiResponse(work.WorkerId);
                    //    }

                    //    catch (Exception ex)
                    //    {
                    //        transaction.Rollback();
                    //        ExceptionHandledLogger.Log(ex);
                    //        return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                ExceptionHandledLogger.Log(ex);
                return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
            }
        }
        //private bool CreateUser(ApplicationUser user,string password,int RoleId)
        //{
        //    var result = false;
        //    var passwordHash = UserManager.PasswordHasher.HashPassword(password);
        //    var securityStamp = Guid.NewGuid().ToString();
        //    var sqlQuery =
        //        $"INSERT [dbo].[AspNetUsers] ([Email], [EmailConfirmed], [PasswordHash], [SecurityStamp],[PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled]," +
        //        $"[AccessFailedCount], [UserName],[OrganizationId],[WorkerId])   " +
        //        $"VALUES(N'{user.Email}', 1,N'{passwordHash}',N'{securityStamp}', NULL, 0, 0, NULL, 0, 0, N'{user.UserName}', {user.OrganizationId}, {user.WorkerId})";

        //    var con = new SqlConnection(connStr);
        //    con.Open();

        //    using (var command = new SqlCommand(sqlQuery, con))
        //    {
        //        command.CommandType = CommandType.Text;

        //        using (var reader = command.ExecuteReader())
        //        {
        //            result = true;
        //        }
        //    }

        //    con.Close();
        //    return result;
        //}
        [Route("UpdateWorker")]
        [HttpPost]
        public ApiResponse UpdateWorker(SaveWorker objWorker)
        {
            using (var context = new StoreContext())
            {
                var result = false;
                var passwordHash = UserManager.PasswordHasher.HashPassword(objWorker.Worker.Password);
                var securityStamp = Guid.NewGuid().ToString();
                var sqlQuery =
                    $"Update WORKER set Name = '{objWorker.Worker.Name}',PersonnelNumber = '{objWorker.Worker.PersonnelNumber}' , " +
                    $"DOJ='{objWorker.Worker.DOJ.ToString("yyyy-MM-dd hh:mm:ss")}',DOB='{objWorker.Worker.DOB.ToString("yyyy-MM-dd hh:mm:ss")}'," +
                    $"UserId = '{objWorker.Worker.UserId}',Password = '{objWorker.Worker.Password}',UpdatedUserId=-1," +
                    $"UpdatedDateTime='{DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss")}',Status=1,IsBlocked=0 Where WorkerId = {objWorker.Worker.WorkerId} " +
                    $"Update ASPNETUSERS set Email = '{objWorker.Worker.Email}', EmailConfirmed = 1, PasswordHash = N'{passwordHash}', SecurityStamp = N'{securityStamp}'," +
                    $"UserName =  N'{objWorker.Worker.UserId}' Where WorkerId = '{objWorker.Worker.WorkerId}' " +
                    $"Update ASPNETUSERROLES set RoleId = {objWorker.Worker.RoleId} Where UserId = (select Top 1 Id  from AspNetUsers Where WorkerId = {objWorker.Worker.WorkerId})" +
                    $"delete from UserOrganizations WHere UserId = (select Top 1 Id  from AspNetUsers Where WorkerId = {objWorker.Worker.WorkerId})";
                if (objWorker.Worker.OrganizationIds.Any())
                {
                    foreach (var organizationId in objWorker.Worker.OrganizationIds)
                    {
                        sqlQuery = sqlQuery +
                            $"insert into UserOrganizations values((select Top 1 Id  from AspNetUsers Where WorkerId = {objWorker.Worker.WorkerId}),{organizationId})";
                    }
                }
                var con = new SqlConnection(connStr);
                con.Open();

                using (var command = new SqlCommand(sqlQuery, con))
                {
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        result = true;
                    }
                }

                con.Close();
                return CommonUtils.CreateSuccessApiResponse(result);
                //using (var transaction = context.Database.BeginTransaction())
                //{
                //    List<WorkerAddress> addressRelation = new List<WorkerAddress>();
                //    Worker worker = new Worker();
                //    try
                //    {
                //        worker = context.Workers.FirstOrDefault(e => e.WorkerId == objWorker.Worker.WorkerId);
                //        worker.Name = objWorker.Worker.Name;
                //        worker.PersonnelNumber = objWorker.Worker.PersonnelNumber;
                //        worker.DOJ = objWorker.Worker.DOJ;
                //        worker.DOB = objWorker.Worker.DOB;
                //        worker.UserId = objWorker.Worker.UserId;
                //        worker.Password = objWorker.Worker.Password;
                //        worker.IsBlocked = objWorker.Worker.IsBlocked;
                //        worker.OrganizationId = objWorker.Worker.OrganizationId;
                //        worker.UpdatedUserId = -1;
                //        worker.UpdatedDateTime = DateTime.UtcNow;
                //        worker.Status = 1;
                //        context.SaveChanges();

                //        transaction.Commit();

                //        return CommonUtils.CreateSuccessApiResponse(objWorker);
                //    }
                //    catch (Exception ex)
                //    {
                //        transaction.Rollback();
                //        return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                //    }
                //}
            }
        }

        [Route("AddWorkerAddress")]
        [HttpPost]
        public ApiResponse AddWorkerAddress(SaveAddress objAddress)
        {
            using (var context = new StoreContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    List<WorkerAddress> addressRelation = new List<WorkerAddress>();
                    try
                    {
                        bool addRelation = false;
                        foreach (var item in objAddress.Addresses)
                        {
                            if (item.AddressId == 0)
                            {
                                AddAddress(context, item);
                                addressRelation.Add(new WorkerAddress
                                {
                                    AddressId = item.AddressId,
                                    WorkerId = objAddress.MasterId
                                });
                                addRelation = true;
                            }
                        }

                        if (addRelation)
                        {
                            foreach (var relation in addressRelation)
                            {
                                context.WorkerAddresses.Add(relation);
                                context.SaveChanges();
                            }
                        }
                        transaction.Commit();
                        return CommonUtils.CreateSuccessApiResponse(objAddress);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                    }
                }
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
        private static void UpdateAddress(StoreContext context, Addresses item)
        {
            var orgAddress = new Addresses();
            orgAddress = context.Addresses.FirstOrDefault(x => x.AddressId == item.AddressId);
            orgAddress.AddressId = item.AddressId;
            orgAddress.Address1 = item.Address1;
            orgAddress.Address2 = item.Address2;
            orgAddress.State = item.State;
            orgAddress.City = item.City;
            orgAddress.Phone = item.Phone;
            orgAddress.Pincode = item.Pincode;
            orgAddress.Email = item.Email;
            orgAddress.UpdatedUserId = -1;
            orgAddress.UpdatedDateTime = DateTime.UtcNow;
            orgAddress.Status = 1;
            context.SaveChanges();
        }

        private string GetErrorMessage(Exception exception)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine(exception.Message);
            sb.AppendLine(exception.StackTrace);

            if (exception.InnerException == null) return sb.ToString();
            sb.AppendLine(exception.InnerException.Message);
            sb.AppendLine(exception.InnerException.StackTrace);
            if (exception.InnerException.InnerException != null)
                sb.AppendLine(exception.InnerException.InnerException.Message);
            if (exception.InnerException.InnerException != null)
                sb.AppendLine(exception.InnerException.InnerException.StackTrace);

            return sb.ToString();
        }

        private static void AddAddress(StoreContext context, Addresses item)
        {
            item.UpdatedUserId = -1;
            item.UpdatedDateTime = DateTime.UtcNow;
            item.Status = 1;
            context.Addresses.Add(item);
            context.SaveChanges();
        }
    }
}
