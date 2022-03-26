using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using IMSAPI.ExceptionHandling;
using IMSAPI.Models;
using IMSAPI.Models.UnboxFutureContext;

namespace IMSAPI.Controllers
{
    public class StoreAdminController : ApiController
    {
        public string connStr = ConfigurationManager.ConnectionStrings["StoreContext"].ConnectionString;

        #region Addresses

        [Route("api/StoreAdmin/DeleteAddress")]
        [HttpPost]
        public ApiResponse DeleteAddress(int addressId)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var addresses = context.Addresses.FirstOrDefault(e => e.AddressId == addressId);
                            if (addresses != null)
                            {
                                addresses.UpdatedUserId = -1;
                                addresses.UpdatedDateTime = DateTime.UtcNow;
                                addresses.Status = 0;
                                context.SaveChanges();
                            }

                            transaction.Commit();

                            return CommonUtils.CreateSuccessApiResponse(addressId);
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

        [Route("api/StoreAdmin/UpdateAddress")]
        [HttpPost]
        public ApiResponse UpdateIMSAddress(SaveAddress ObjOrganization)
        {
            using (var context = new StoreContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in ObjOrganization.Addresses)
                        {
                            if (item.AddressId > 0)
                            {
                                UpdateAddress(context, item);
                            }
                        }

                        transaction.Commit();
                        return CommonUtils.CreateSuccessApiResponse(ObjOrganization);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                    }
                }
            }
        }

        #endregion

        #region Organization

        [Route("api/StoreAdmin/ListOrganization")]
        [HttpGet]
        public ApiResponse GetAllOrganization()
        {
            using (StoreContext context = new StoreContext())
            {
                var resultList = context.Organizations.Where(e => e.Status == 1).ToList();
                return CommonUtils.CreateSuccessApiResponse(resultList);
            }
        }

        [Route("api/StoreAdmin/GetOrganizationByID")]
        [HttpGet]
        public ApiResponse GetOrganizationById(int organizationid)
        {
            using (var context = new StoreContext())
            {
                try
                {
                    var saveOrganization = new SaveOrganization
                    {
                        Addresses = new List<Addresses>(),
                        Organization = GetOrganization(organizationid)
                    };
                    var addressRelation = context.OrganizationAddress.Where(x => x.OrganizationId == organizationid).ToList();

                    foreach (var orgAddress in addressRelation.Select(relation => context.Addresses.FirstOrDefault(x => x.AddressId == relation.AddressId && x.Status == 1)).Where(orgAddress => orgAddress != null))
                    {
                        saveOrganization.Addresses.Add(orgAddress);
                    }

                    return CommonUtils.CreateSuccessApiResponse(saveOrganization);
                }
                catch (Exception ex)
                {
                    return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                }
            }
        }


        [Route("api/StoreAdmin/AddOrganization")]
        [HttpPost]
        public ApiResponse AddOrganization(Organization saveOrganization)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            saveOrganization.UpdatedUserId = -1;
                            saveOrganization.UpdatedDateTime = DateTime.UtcNow;
                            saveOrganization.Status = 1;
                            context.Organizations.Add(saveOrganization);
                            context.SaveChanges();
                            transaction.Commit();
                            return CommonUtils.CreateSuccessApiResponse(saveOrganization.OrganizationId);
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

        [Route("api/StoreAdmin/DeleteOrganization")]
        [HttpPost]
        public ApiResponse DeleteOrganization(int organizationId)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var organization = context.Organizations.FirstOrDefault(e => e.OrganizationId == organizationId);
                            if (organization != null)
                            {
                                organization.UpdatedUserId = -1;
                                organization.UpdatedDateTime = DateTime.UtcNow;
                                organization.Status = 0;
                                context.SaveChanges();
                            }

                            transaction.Commit();

                            return CommonUtils.CreateSuccessApiResponse(organizationId);
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

        [Route("api/StoreAdmin/UpdateOrganization")]
        [HttpPost]
        public ApiResponse UpdateOrganization(SaveOrganization ObjOrganization)
        {
            using (var context = new StoreContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    List<OrganizationAddress> addressRelation = new List<OrganizationAddress>();
                    var organization = new Organization();
                    try
                    {
                        organization = context.Organizations.FirstOrDefault(e => e.OrganizationId == ObjOrganization.Organization.OrganizationId);
                        organization.Id = ObjOrganization.Organization.Id;
                        organization.Name = ObjOrganization.Organization.Name;
                        organization.Description = ObjOrganization.Organization.Description;
                        organization.PurchaseOrderPrefix = ObjOrganization.Organization.PurchaseOrderPrefix;
                        organization.ReturnOrderPrefix = ObjOrganization.Organization.ReturnOrderPrefix;
                        organization.InventoryAdjustmentPrefix = ObjOrganization.Organization.InventoryAdjustmentPrefix;
                        organization.TransactionalWarehouseId = ObjOrganization.Organization.TransactionalWarehouseId;
                        organization.TaxRegistrationNumber = ObjOrganization.Organization.TaxRegistrationNumber;
                        organization.ItemConsumptionPrefix = ObjOrganization.Organization.ItemConsumptionPrefix;
                        organization.UpdatedUserId = -1;
                        organization.UpdatedDateTime = DateTime.UtcNow;
                        organization.Status = 1;

                        context.SaveChanges();

                        transaction.Commit();
                        return CommonUtils.CreateSuccessApiResponse(ObjOrganization);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                    }
                }
            }
        }

        [Route("api/StoreAdmin/AddOrganizationAddress")]
        [HttpPost]
        public ApiResponse AddOrganizationAddress(SaveAddress ObjOrganization)
        {
            using (var context = new StoreContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    List<OrganizationAddress> addressRelation = new List<OrganizationAddress>();
                    var organization = new Organization();
                    try
                    {
                        bool addRelation = false;
                        foreach (var item in ObjOrganization.Addresses)
                        {
                            if (item.AddressId == 0)
                            {
                                AddAddress(context, item);
                                addressRelation.Add(new OrganizationAddress
                                {
                                    AddressId = item.AddressId,
                                    OrganizationId = ObjOrganization.MasterId
                                });
                                addRelation = true;
                            }
                        }

                        if (addRelation)
                        {
                            foreach (var relation in addressRelation)
                            {
                                context.OrganizationAddress.Add(relation);
                                context.SaveChanges();
                            }
                        }
                        transaction.Commit();
                        return CommonUtils.CreateSuccessApiResponse(ObjOrganization);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                    }
                }
            }
        }

        private static void AddAddress(StoreContext context, Addresses item)
        {
            item.UpdatedUserId = -1;
            item.UpdatedDateTime = DateTime.UtcNow;
            item.Status = 1;
            context.Addresses.Add(item);
            context.SaveChanges();
        }

        #endregion

        #region Category

        [Route("api/StoreAdmin/ListCategory")]
        [HttpGet]
        public ApiResponse GetAllCategory(int organizationId)
        {
            using (var context = new StoreContext())
            {
                var resultList = context.Categories.Where(e => e.Status == 1 && e.OrganizationId == organizationId).ToList();
                return CommonUtils.CreateSuccessApiResponse(resultList);
            }
        }

        [Route("api/StoreAdmin/DeleteCategory")]
        [HttpPost]
        public ApiResponse DeleteCategory(int categoryId)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var category = context.Categories.FirstOrDefault(e => e.CategoryId == categoryId);
                            if (category != null)
                            {
                                category.UpdatedUserId = -1;
                                category.UpdatedDateTime = DateTime.UtcNow;
                                category.Status = 0;
                                context.SaveChanges();
                            }

                            transaction.Commit();

                            return CommonUtils.CreateSuccessApiResponse(categoryId);
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

        [Route("api/StoreAdmin/GetCategoryByID")]
        [HttpGet]
        public ApiResponse GetCategoryById(int categoryId)
        {
            using (var context = new StoreContext())
            {
                try
                {
                    var category = context.Categories.FirstOrDefault(e => e.CategoryId == categoryId);
                    return CommonUtils.CreateSuccessApiResponse(category);
                }
                catch (Exception ex)
                {
                    return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                }
            }
        }


        [Route("api/StoreAdmin/AddCategory")]
        [HttpPost]
        public ApiResponse AddCategory(Category saveCategory)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            saveCategory.UpdatedUserId = -1;
                            saveCategory.UpdatedDateTime = DateTime.UtcNow;
                            saveCategory.Status = 1;
                            context.Categories.Add(saveCategory);
                            context.SaveChanges();

                            transaction.Commit();
                            // To return inserted ID value only
                            return CommonUtils.CreateSuccessApiResponse(saveCategory.CategoryId);
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

        [Route("api/StoreAdmin/UpdateCategory")]
        [HttpPost]
        public ApiResponse UpdateCategory(Category objCategory)
        {
            using (var context = new StoreContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var category = context.Categories.FirstOrDefault(e => e.CategoryId == objCategory.CategoryId);
                        category.Id = objCategory.Id;
                        category.Name = objCategory.Name;
                        category.Description = objCategory.Description;
                        category.UpdatedUserId = 0;
                        category.UpdatedDateTime = DateTime.UtcNow;
                        category.Status = 1;

                        context.SaveChanges();
                        transaction.Commit();
                        return CommonUtils.CreateSuccessApiResponse(category);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                    }
                }
            }
        }

        #endregion

        #region UOM

        [Route("api/StoreAdmin/ListUnits")]
        [HttpGet]
        public ApiResponse GetAllUnits(int organizationId)
        {
            using (var context = new StoreContext())
            {
                var resultList = context.Units.Where(x => x.OrganizationId == organizationId).ToList();
                return CommonUtils.CreateSuccessApiResponse(resultList);
            }
        }

        [Route("api/StoreAdmin/GetUnitByID")]
        [HttpGet]
        public ApiResponse GetUnitById(int unitid)
        {
            using (var context = new StoreContext())
            {
                try
                {
                    var uom = context.Units.FirstOrDefault(e => e.Id == unitid);
                    return CommonUtils.CreateSuccessApiResponse(uom);
                }
                catch (Exception ex)
                {
                    return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                }
            }
        }

        [Route("api/StoreAdmin/DeleteUnit")]
        [HttpPost]
        public ApiResponse DeleteUnit(int unitid)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var uom = context.Units.FirstOrDefault(e => e.Id == unitid);
                            if (uom != null)
                            {
                                context.Units.Remove(uom);
                                context.SaveChanges();
                            }

                            transaction.Commit();

                            return CommonUtils.CreateSuccessApiResponse(unitid);
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

        [Route("api/StoreAdmin/AddUnit")]
        [HttpPost]
        public ApiResponse AddUnit(Unit saveUnit)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            context.Units.Add(saveUnit);
                            context.SaveChanges();

                            //one to one mapping for uom conversion entry adding
                            var uom = new UomConversion
                            {
                                Name = saveUnit.Name,
                                Description = saveUnit.Name,
                                FromUnitId = saveUnit.Id,
                                ToUnitId = saveUnit.Id,
                                OrganizationId = saveUnit.OrganizationId,
                                Ratio = 1
                            };
                            context.UomConversions.Add(uom);
                            context.SaveChanges();
                            transaction.Commit();

                            // To return inserted ID value only
                            return CommonUtils.CreateSuccessApiResponse(saveUnit.Id);
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

        [Route("api/StoreAdmin/UpdateUnit")]
        [HttpPost]
        public ApiResponse UpdateUnit(Unit objUnit)
        {
            using (var context = new StoreContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var uom = context.Units.FirstOrDefault(e => e.Id == objUnit.Id);
                        uom.Id = objUnit.Id;
                        uom.Name = objUnit.Name;
                        context.SaveChanges();

                        transaction.Commit();
                        return CommonUtils.CreateSuccessApiResponse(uom);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                    }
                }
            }
        }

        #endregion

        #region UOMConversion

        [Route("api/StoreAdmin/ListUOMConversion")]
        [HttpGet]
        public ApiResponse GetAllUOMConversion(int organizationId)
        {
            using (var context = new StoreContext())
            {
                var resultList = context.UomConversions.Where(x => x.OrganizationId == organizationId).ToList();
                return CommonUtils.CreateSuccessApiResponse(resultList);
            }
        }

        [Route("api/StoreAdmin/GetUomConversionByID")]
        [HttpGet]
        public ApiResponse GetUomConversionById(int uomId)
        {
            using (var context = new StoreContext())
            {
                try
                {
                    var uom = context.UomConversions.FirstOrDefault(e => e.Id == uomId);
                    return CommonUtils.CreateSuccessApiResponse(uom);
                }
                catch (Exception ex)
                {
                    return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                }
            }
        }

        [Route("api/StoreAdmin/DeleteUomConversion")]
        [HttpPost]
        public ApiResponse DeleteUomConversion(int uomConversionId)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var uom = context.UomConversions.FirstOrDefault(e => e.Id == uomConversionId);
                            if (uom != null)
                            {
                                context.UomConversions.Remove(uom);
                                context.SaveChanges();
                            }

                            transaction.Commit();

                            return CommonUtils.CreateSuccessApiResponse(uomConversionId);
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

        [Route("api/StoreAdmin/AddUomConversion")]
        [HttpPost]
        public ApiResponse AddUomConversion(UomConversion saveUomConversion)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            context.UomConversions.Add(saveUomConversion);
                            context.SaveChanges();
                            transaction.Commit();

                            // To return inserted ID value only
                            return CommonUtils.CreateSuccessApiResponse(saveUomConversion.Id);
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

        [Route("api/StoreAdmin/UpdateUomConversion")]
        [HttpPost]
        public ApiResponse UpdateUomConversion(UomConversion objUomConversion)
        {
            using (var context = new StoreContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var uomConversion = context.UomConversions.FirstOrDefault(e => e.Id == objUomConversion.Id);
                        uomConversion.Id = objUomConversion.Id;
                        uomConversion.Description = objUomConversion.Description;
                        uomConversion.Name = objUomConversion.Name;
                        uomConversion.FromUnitId = objUomConversion.FromUnitId;
                        uomConversion.ToUnitId = objUomConversion.ToUnitId;
                        uomConversion.Ratio = objUomConversion.Ratio;
                        context.SaveChanges();
                        transaction.Commit();
                        return CommonUtils.CreateSuccessApiResponse(uomConversion);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                    }
                }
            }
        }

        #endregion

        #region Items

        [Route("api/StoreAdmin/ListItems")]
        [HttpGet]
        public ApiResponse GetAllItems(int organizationId)
        {
            using (var context = new StoreContext())
            {
                var resultList = context.Items.Where(e => e.Status == 1 && e.OrganizationId == organizationId).ToList();
                var avgPriceList = GetItemsAvgPrice(organizationId);
                foreach (var item in resultList)
                {
                    var itemDetail = avgPriceList.FirstOrDefault(x => x.ItemId == item.ItemId);
                    if (itemDetail == null) continue;
                    item.AvgPrice = itemDetail.AvgPrice;
                    item.SourceOfOriginName = itemDetail.SourceOfOriginName;
                }

                return CommonUtils.CreateSuccessApiResponse(resultList);
            }
        }

        [Route("api/StoreAdmin/GetItemsByID")]
        [HttpGet]
        public ApiResponse GetItemsById(int itemid)
        {
            using (var context = new StoreContext())
            {
                try
                {
                    var item = context.Items.FirstOrDefault(e => e.ItemId == itemid);
                    return CommonUtils.CreateSuccessApiResponse(item);
                }
                catch (Exception ex)
                {
                    return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                }
            }
        }

        [Route("api/StoreAdmin/DeleteItem")]
        [HttpPost]
        public ApiResponse DeleteItem(int itemId)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var item = context.Items.FirstOrDefault(e => e.ItemId == itemId);
                            if (item != null)
                            {
                                item.UpdatedUserId = -1;
                                item.UpdatedDateTime = DateTime.UtcNow;
                                item.Status = 0;
                                context.SaveChanges();
                            }

                            transaction.Commit();

                            return CommonUtils.CreateSuccessApiResponse(itemId);
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

        [Route("api/StoreAdmin/AddItems")]
        [HttpPost]
        public ApiResponse AddItems(Items saveItems)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            saveItems.UpdatedUserId = -1;
                            saveItems.UpdatedDateTime = DateTime.UtcNow;
                            saveItems.Status = 1;
                            context.Items.Add(saveItems);
                            context.SaveChanges();
                            transaction.Commit();
                            // To return inserted ID value only
                            return CommonUtils.CreateSuccessApiResponse(saveItems.ItemId);
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

        [Route("api/StoreAdmin/UpdateItems")]
        [HttpPost]
        public ApiResponse UpdateItems(Items objItems)
        {
            using (var context = new StoreContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var items = context.Items.FirstOrDefault(e => e.ItemId == objItems.ItemId);
                        items.Id = objItems.Id;
                        items.ItemNo = objItems.ItemNo;
                        items.Name = objItems.Name;
                        items.Description = objItems.Description;
                        items.PurchaseUnitId = objItems.PurchaseUnitId;
                        items.InventoryUnitId = objItems.InventoryUnitId;
                        items.MinStock = objItems.MinStock;
                        items.MaxStock = objItems.MaxStock;
                        items.SourceOfOrigin = objItems.SourceOfOrigin;
                        items.Status = 1;
                        context.SaveChanges();
                        transaction.Commit();
                        return CommonUtils.CreateSuccessApiResponse(items);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                    }
                }
            }
        }

        #endregion

        #region Worker

        [Route("api/StoreAdmin/ListWorker")]
        [HttpGet]
        public ApiResponse GetAllWorker(int organizationId)
        {
            using (var context = new StoreContext())
            {
                var resultList = context.Workers.Where(e => e.Status == 1 && e.OrganizationId == organizationId).ToList();
                return CommonUtils.CreateSuccessApiResponse(resultList);
            }
        }

        [Route("api/StoreAdmin/GetWorkerByID")]
        [HttpGet]
        public ApiResponse GetWorkerById(int workerid)
        {
            using (var context = new StoreContext())
            {
                try
                {
                    var saveWorker = new SaveWorker
                    {
                        Addresses = new List<Addresses>(),
                        Worker = context.Workers.FirstOrDefault(e => e.WorkerId == workerid)
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

        [Route("api/StoreAdmin/DeleteWorker")]
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

        [Route("api/StoreAdmin/AddWorker")]
        [HttpPost]
        public ApiResponse AddWorker(SaveWorker saveWorker)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            saveWorker.Worker.UpdatedUserId = -1;
                            saveWorker.Worker.UpdatedDateTime = DateTime.UtcNow;
                            saveWorker.Worker.Status = 1;
                            saveWorker.Worker.IsBlocked = false;
                            context.Workers.Add(saveWorker.Worker);
                            context.SaveChanges();

                            transaction.Commit();
                            return CommonUtils.CreateSuccessApiResponse(saveWorker.Worker.WorkerId);
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

        [Route("api/StoreAdmin/UpdateWorker")]
        [HttpPost]
        public ApiResponse UpdateWorker(SaveWorker objWorker)
        {
            using (var context = new StoreContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    List<WorkerAddress> addressRelation = new List<WorkerAddress>();
                    Worker worker = new Worker();
                    try
                    {
                        worker = context.Workers.FirstOrDefault(e => e.WorkerId == objWorker.Worker.WorkerId);
                        worker.Name = objWorker.Worker.Name;
                        worker.PersonnelNumber = objWorker.Worker.PersonnelNumber;
                        worker.DOJ = objWorker.Worker.DOJ;
                        worker.DOB = objWorker.Worker.DOB;
                        worker.UserId = objWorker.Worker.UserId;
                        worker.Password = objWorker.Worker.Password;
                        worker.IsBlocked = objWorker.Worker.IsBlocked;
                        worker.OrganizationId = objWorker.Worker.OrganizationId;
                        worker.UpdatedUserId = -1;
                        worker.UpdatedDateTime = DateTime.UtcNow;
                        worker.Status = 1;
                        context.SaveChanges();

                        transaction.Commit();

                        return CommonUtils.CreateSuccessApiResponse(objWorker);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                    }
                }
            }
        }

        [Route("api/StoreAdmin/AddWorkerAddress")]
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

        #endregion

        #region Vendor

        [Route("api/StoreAdmin/ListVendor")]
        [HttpGet]
        public ApiResponse GetAllVendor(int organizationId)
        {
            using (StoreContext context = new StoreContext())
            {
                var resultList = context.Vendors.Where(e => e.Status == 1 && e.OrganizationId == organizationId).ToList();
                return CommonUtils.CreateSuccessApiResponse(resultList);
            }
        }

        [Route("api/StoreAdmin/GetVendorByID")]
        [HttpGet]
        public ApiResponse GetVendorById(int vendorid)
        {
            using (StoreContext context = new StoreContext())
            {
                try
                {
                    var saveVendor = new SaveVendor
                    {
                        Addresses = new List<Addresses>(),
                        Vendor = context.Vendors.FirstOrDefault(e => e.VendorId == vendorid)
                    };
                    var addressRelation = context.VendorAddresses.Where(x => x.VendorId == vendorid).ToList();

                    foreach (var relation in addressRelation)
                    {
                        var orgAddress = context.Addresses.FirstOrDefault(x => x.AddressId == relation.AddressId && x.Status == 1);
                        saveVendor.Addresses.Add(orgAddress);
                    }

                    return CommonUtils.CreateSuccessApiResponse(saveVendor);
                }
                catch (Exception ex)
                {
                    return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                }
            }
        }

        [Route("api/StoreAdmin/DeleteVendor")]
        [HttpPost]
        public ApiResponse DeleteVendor(int vendorid)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var item = context.Vendors.FirstOrDefault(e => e.VendorId == vendorid);
                            if (item != null)
                            {
                                item.UpdatedUserId = -1;
                                item.UpdatedDateTime = DateTime.UtcNow;
                                item.Status = 0;
                                context.SaveChanges();
                            }

                            transaction.Commit();

                            return CommonUtils.CreateSuccessApiResponse(vendorid);
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

        [Route("api/StoreAdmin/AddVendor")]
        [HttpPost]
        public ApiResponse AddVendor(SaveVendor saveVendor)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            saveVendor.Vendor.UpdatedUserId = -1;
                            saveVendor.Vendor.UpdatedDateTime = DateTime.UtcNow;
                            saveVendor.Vendor.Status = 1;
                            context.Vendors.Add(saveVendor.Vendor);
                            context.SaveChanges();

                            transaction.Commit();
                            return CommonUtils.CreateSuccessApiResponse(saveVendor.Vendor.VendorId);
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

        [Route("api/StoreAdmin/UpdateVendor")]
        [HttpPost]
        public ApiResponse UpdateVendor(SaveVendor objVendor)
        {
            using (var context = new StoreContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    List<VendorAddress> addressRelation = new List<VendorAddress>();
                    Vendor worker = new Vendor();
                    try
                    {
                        worker = context.Vendors.FirstOrDefault(e => e.VendorId == objVendor.Vendor.VendorId);
                        worker.Id = objVendor.Vendor.Id;
                        worker.Name = objVendor.Vendor.Name;
                        worker.AccountNumber = objVendor.Vendor.AccountNumber;
                        worker.UpdatedUserId = -1;
                        worker.UpdatedDateTime = DateTime.UtcNow;
                        worker.Status = 1;

                        context.SaveChanges();

                        bool addRelation = false;
                        if (objVendor.Addresses != null)
                        {
                            if (objVendor.Addresses.Any())
                            {
                                foreach (var item in objVendor.Addresses)
                                {
                                    if (item.AddressId == 0)
                                    {
                                        item.UpdatedUserId = -1;
                                        item.UpdatedDateTime = DateTime.UtcNow;
                                        item.Status = 1;
                                        context.Addresses.Add(item);
                                        context.SaveChanges();
                                        addressRelation.Add(new VendorAddress
                                        { AddressId = item.AddressId, VendorId = objVendor.Vendor.VendorId });
                                        addRelation = true;
                                    }
                                    else
                                    {
                                        UpdateAddress(context, item);
                                    }
                                }
                            }
                        }


                        if (addRelation)
                        {
                            foreach (var relation in addressRelation)
                            {
                                context.VendorAddresses.Add(relation);
                                context.SaveChanges();
                            }
                        }
                        transaction.Commit();
                        return CommonUtils.CreateSuccessApiResponse(objVendor);
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

        [Route("api/StoreAdmin/AddVendorAddress")]
        [HttpPost]
        public ApiResponse AddVendorAddress(SaveAddress objAddress)
        {
            using (var context = new StoreContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    List<VendorAddress> addressRelation = new List<VendorAddress>();
                    try
                    {
                        bool addRelation = false;
                        foreach (var item in objAddress.Addresses)
                        {
                            if (item.AddressId == 0)
                            {
                                AddAddress(context, item);
                                addressRelation.Add(new VendorAddress
                                {
                                    AddressId = item.AddressId,
                                    VendorId = objAddress.MasterId
                                });
                                addRelation = true;
                            }
                        }

                        if (addRelation)
                        {
                            foreach (var relation in addressRelation)
                            {
                                context.VendorAddresses.Add(relation);
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

        #endregion

        #region Warehouse

        [Route("api/StoreAdmin/ListWarehouse")]
        [HttpGet]
        public async Task<ApiResponse> GetAllWarehouse(int? organizationId)
        {
            using (var context = new StoreContext())
            {
                var result = context.Warehouses.Where(e => e.Status == 1);
                if (organizationId.HasValue && organizationId > 0)
                {
                    result = result.Where(x => x.OrganizationId == organizationId);
                }
                return CommonUtils.CreateSuccessApiResponse(await result.ToListAsync());
            }
        }

        [Route("api/StoreAdmin/GetWarehouseByOrganizationID")]
        [HttpGet]
        public ApiResponse GetWarehouseByOrganization(int organizationId)
        {
            using (var context = new StoreContext())
            {
                var resultList = context.Warehouses.Where(e => e.Status == 1 && e.OrganizationId == organizationId).ToList();
                return CommonUtils.CreateSuccessApiResponse(resultList);
            }
        }

        [Route("api/StoreAdmin/GetWarehouseByID")]
        [HttpGet]
        public ApiResponse GetWarehouseById(int warehouseid)
        {
            using (var context = new StoreContext())
            {
                try
                {
                    var saveWarehouse = new SaveWarehouse
                    {
                        Addresses = new List<Addresses>(),
                        Warehouse = context.Warehouses.FirstOrDefault(e => e.WarehouseId == warehouseid)
                    };
                    var addressRelation = context.WarehouseAddresses.Where(x => x.WarehouseId == warehouseid).ToList();

                    foreach (var relation in addressRelation)
                    {
                        var orgAddress = context.Addresses.FirstOrDefault(x => x.AddressId == relation.AddressId && x.Status == 1);
                        saveWarehouse.Addresses.Add(orgAddress);
                    }

                    return CommonUtils.CreateSuccessApiResponse(saveWarehouse);
                }
                catch (Exception ex)
                {
                    return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                }
            }
        }

        [Route("api/StoreAdmin/DeleteWarehouse")]
        [HttpPost]
        public ApiResponse DeleteWarehouse(int warehouseid)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var item = context.Warehouses.FirstOrDefault(e => e.WarehouseId == warehouseid);
                            if (item != null)
                            {
                                item.UpdatedUserId = -1;
                                item.UpdatedDateTime = DateTime.UtcNow;
                                item.Status = 0;
                                context.SaveChanges();
                            }

                            transaction.Commit();

                            return CommonUtils.CreateSuccessApiResponse(warehouseid);
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

        [Route("api/StoreAdmin/AddWarehouse")]
        [HttpPost]
        public ApiResponse AddWarehouse(SaveWarehouse saveWarehouse)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            saveWarehouse.Warehouse.UpdatedUserId = -1;
                            saveWarehouse.Warehouse.UpdatedDateTime = DateTime.UtcNow;
                            saveWarehouse.Warehouse.Status = 1;
                            context.Warehouses.Add(saveWarehouse.Warehouse);
                            context.SaveChanges();

                            transaction.Commit();
                            return CommonUtils.CreateSuccessApiResponse(saveWarehouse.Warehouse.WarehouseId);
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

        [Route("api/StoreAdmin/UpdateWarehouse")]
        [HttpPost]
        public ApiResponse UpdateWarehouse(SaveWarehouse objWarehouse)
        {
            using (var context = new StoreContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    List<WarehouseAddress> addressRelation = new List<WarehouseAddress>();
                    Warehouse worker = new Warehouse();
                    try
                    {
                        worker = context.Warehouses.FirstOrDefault(e =>
                            e.WarehouseId == objWarehouse.Warehouse.WarehouseId);
                        worker.Id = objWarehouse.Warehouse.Id;
                        worker.Name = objWarehouse.Warehouse.Name;
                        worker.OrganizationId = objWarehouse.Warehouse.OrganizationId;
                        worker.UpdatedUserId = -1;
                        worker.UpdatedDateTime = DateTime.UtcNow;
                        worker.Status = 1;

                        context.SaveChanges();

                        transaction.Commit();
                        return CommonUtils.CreateSuccessApiResponse(objWarehouse);
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

        [Route("api/StoreAdmin/AddWarehouseAddress")]
        [HttpPost]
        public ApiResponse AddWarehouseAddress(SaveAddress objAddress)
        {
            using (var context = new StoreContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    List<WarehouseAddress> addressRelation = new List<WarehouseAddress>();
                    try
                    {
                        bool addRelation = false;
                        foreach (var item in objAddress.Addresses)
                        {
                            if (item.AddressId == 0)
                            {
                                AddAddress(context, item);
                                addressRelation.Add(new WarehouseAddress
                                {
                                    AddressId = item.AddressId,
                                    WarehouseId = objAddress.MasterId
                                });
                                addRelation = true;
                            }
                        }

                        if (addRelation)
                        {
                            foreach (var relation in addressRelation)
                            {
                                context.WarehouseAddresses.Add(relation);
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

        #endregion

        #region ItemCategoryMapping

        [Route("api/StoreAdmin/ListItemCategory")]
        [HttpGet]
        public ApiResponse GetAllItemCategory(int organizationId)
        {
            try
            {
                var itemCategories = GetItemCategories(organizationId);

                return CommonUtils.CreateSuccessApiResponse(itemCategories);
            }
            catch (Exception ex)
            {
                ExceptionHandledLogger.Log(ex);
                return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
            }
        }

        private List<ItemCategory> GetItemCategories(int organizationId)
        {
            var sqlQuery =
                $"SELECT ic.ItemCategoryId, ic.CategoryId, c.[Name] AS CategoryName, ic.UpdatedUserId, ic.UpdatedDateTime, ic.[Status], ic.OrganizationId FROM dbo.ItemCategory ic " +
                $"INNER JOIN dbo.Category c ON ic.CategoryId = c.CategoryId " +
                $"WHERE ic.OrganizationId = {organizationId} AND ic.[Status] = 1";

            var itemCategories = new List<ItemCategory>();
            var con = new SqlConnection(connStr);
            con.Open();

            using (var command = new SqlCommand(sqlQuery, con))
            {
                command.CommandType = CommandType.Text;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tmpRecord = new ItemCategory()
                        {
                            ItemCategoryId = int.Parse(reader["ItemCategoryId"].ToString()),
                            CategoryId = int.Parse(reader["CategoryId"].ToString()),
                            CategoryName = reader["CategoryName"].ToString(),
                            UpdatedUserId = int.Parse(reader["UpdatedUserId"].ToString()),
                            UpdatedDateTime = DateTime.Parse(reader["UpdatedDateTime"].ToString()),
                            Status = short.Parse(reader["Status"].ToString()),
                            OrganizationId = int.Parse(reader["OrganizationId"].ToString()),
                        };
                        itemCategories.Add(tmpRecord);
                    }
                }
            }

            con.Close();
            return itemCategories;
        }

        [Route("api/StoreAdmin/GetItemCategoryById")]
        [HttpGet]
        public ApiResponse GetItemCategoryById(int itemCategoryId)
        {
            try
            {
                var saveItemCategory = new SaveItemCategory
                {
                    ItemCategory = new ItemCategory(),
                    ItemCategoryCollections = new List<ItemCategoryCollection>()
                };
                var sqlQuery = $"SELECT ic.ItemCategoryId, ic.CategoryId, c.[Name] AS CategoryName, ic.UpdatedUserId, ic.UpdatedDateTime, ic.[Status], ic.OrganizationId FROM dbo.ItemCategory ic " +
                               $"INNER JOIN dbo.Category c ON ic.CategoryId = c.CategoryId " +
                               $"WHERE ic.ItemCategoryId = { itemCategoryId } AND ic.[Status] = 1";

                var con = new SqlConnection(connStr);
                con.Open();

                using (var command = new SqlCommand(sqlQuery, con))
                {
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            saveItemCategory.ItemCategory.ItemCategoryId = int.Parse(reader["ItemCategoryId"].ToString());
                            saveItemCategory.ItemCategory.CategoryId = int.Parse(reader["CategoryId"].ToString());
                            saveItemCategory.ItemCategory.CategoryName = reader["CategoryName"].ToString();
                            saveItemCategory.ItemCategory.UpdatedUserId = int.Parse(reader["UpdatedUserId"].ToString());
                            saveItemCategory.ItemCategory.UpdatedDateTime = DateTime.Parse(reader["UpdatedDateTime"].ToString());
                            saveItemCategory.ItemCategory.Status = short.Parse(reader["Status"].ToString());
                            saveItemCategory.ItemCategory.OrganizationId = int.Parse(reader["OrganizationId"].ToString());
                        }
                    }
                }

                sqlQuery = $"SELECT c.ItemCategoryCollectionId, c.ItemCategoryId, c.CategoryId, c.ItemId, i.Name AS ItemName FROM dbo.ItemCategoryCollection c " +
                           $"INNER JOIN dbo.ItemCategory ic ON ic.ItemCategoryId = c.ItemCategoryId " +
                           $"INNER JOIN dbo.Items i ON i.ItemId = c.ItemId " +
                           $"WHERE ic.ItemCategoryId = { itemCategoryId } AND ic.[Status] = 1";


                using (var command = new SqlCommand(sqlQuery, con))
                {
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tmpRecord = new ItemCategoryCollection()
                            {
                                ItemCategoryCollectionId = int.Parse(reader["ItemCategoryCollectionId"].ToString()),
                                ItemCategoryId = int.Parse(reader["ItemCategoryId"].ToString()),
                                CategoryId = int.Parse(reader["CategoryId"].ToString()),
                                ItemId = int.Parse(reader["ItemId"].ToString()),
                                ItemName = reader["ItemName"].ToString()
                            };
                            saveItemCategory.ItemCategoryCollections.Add(tmpRecord);
                        }
                    }
                }

                con.Close();

                return CommonUtils.CreateSuccessApiResponse(saveItemCategory);
            }
            catch (Exception ex)
            {
                ExceptionHandledLogger.Log(ex);
                return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
            }
        }

        [Route("api/StoreAdmin/GetItemsWithOnHandQtyByItemCategoryId")]
        [HttpGet]
        public ApiResponse GetItemsWithOnHandQtyByCategoryId(int itemCategoryId, int warehouseId)
        {
            try
            {
                var saveItemCategory = GetItemCategoryCollections(itemCategoryId, warehouseId);

                return CommonUtils.CreateSuccessApiResponse(saveItemCategory);
            }
            catch (Exception ex)
            {
                ExceptionHandledLogger.Log(ex);
                return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
            }
        }

        private List<ItemCategoryCollection> GetItemCategoryCollections(int itemCategoryId, int warehouseId)
        {
            var saveItemCategory = new List<ItemCategoryCollection>();


            var con = new SqlConnection(connStr);
            con.Open();


            var sqlQuery =
                $" SELECT c.CategoryId, c.ItemCategoryId, s.ItemId, i.[Name] AS ItemName, SUM(s.Quantity) AS Quantity, u.[Name] AS UnitName, u.[Id] AS UnitId FROM dbo.ItemCategoryCollection c " +
                $" INNER JOIN dbo.ItemCategory ic ON ic.ItemCategoryId = c.ItemCategoryId " +
                $" INNER JOIN dbo.Items i ON i.ItemId = c.ItemId" +
                $" INNER JOIN dbo.Stock s ON s.ItemId = i.ItemId" +
                $" INNER JOIN dbo.UomConversion u ON u.Id = i.InventoryUnitId" +
                $" WHERE ic.ItemCategoryId = {itemCategoryId} AND ic.[Status] = 1 AND s.WarehouseId = {warehouseId} " +
                $"GROUP BY s.ItemId, i.[Name], c.ItemCategoryId, c.CategoryId, u.[Name], u.[Id]";


            using (var command = new SqlCommand(sqlQuery, con))
            {
                command.CommandType = CommandType.Text;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tmpRecord = new ItemCategoryCollection()
                        {
                            ItemCategoryId = int.Parse(reader["ItemCategoryId"].ToString()),
                            CategoryId = int.Parse(reader["CategoryId"].ToString()),
                            ItemId = int.Parse(reader["ItemId"].ToString()),
                            ItemName = reader["ItemName"].ToString(),
                            OnHandQty = double.Parse(reader["Quantity"].ToString()),
                            UnitName = reader["UnitName"].ToString(),
                            UnitId = int.Parse(reader["UnitId"].ToString()),
                        };
                        saveItemCategory.Add(tmpRecord);
                    }
                }
            }

            con.Close();
            return saveItemCategory;
        }

        [Route("api/StoreAdmin/AddItemCategory")]
        [HttpPost]
        public ApiResponse AddItemCategory(SaveItemCategory objItemCategory)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            objItemCategory.ItemCategory.UpdatedUserId = -1;
                            objItemCategory.ItemCategory.UpdatedDateTime = DateTime.UtcNow;
                            objItemCategory.ItemCategory.Status = 1;
                            context.ItemCategory.Add(objItemCategory.ItemCategory);
                            context.SaveChanges();

                            foreach (var itemCategoryCollection in objItemCategory.ItemCategoryCollections)
                            {
                                itemCategoryCollection.CategoryId = objItemCategory.ItemCategory.CategoryId;
                                itemCategoryCollection.ItemCategoryId = objItemCategory.ItemCategory.ItemCategoryId;
                                context.ItemCategoryCollection.Add(itemCategoryCollection);
                                context.SaveChanges();
                            }
                            transaction.Commit();
                            return CommonUtils.CreateSuccessApiResponse(objItemCategory.ItemCategory.ItemCategoryId);
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

        [Route("api/StoreAdmin/UpdateItemCategory")]
        [HttpPost]
        public ApiResponse UpdateItemCategory(SaveItemCategory objItemCategory)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var itemCategory = context.ItemCategory.FirstOrDefault(e =>
                                e.ItemCategoryId == objItemCategory.ItemCategory.ItemCategoryId && e.CategoryId == objItemCategory.ItemCategory.CategoryId);
                            itemCategory.UpdatedUserId = -1;
                            itemCategory.UpdatedDateTime = DateTime.UtcNow;
                            itemCategory.Status = 1;
                            context.SaveChanges();

                            //Delete the item collection
                            var itemCategoryCollectionList = context.ItemCategoryCollection.Where(x => x.CategoryId == objItemCategory.ItemCategory.CategoryId
                                                                                                       && x.ItemCategoryId == objItemCategory.ItemCategory.ItemCategoryId).ToList();
                            foreach (var relation in itemCategoryCollectionList)
                            {
                                var itemCategoryCollection = objItemCategory.ItemCategoryCollections.FirstOrDefault(x => x.CategoryId == relation.CategoryId
                                                                                                                         && x.ItemId == relation.ItemId
                                                                                                                         && x.ItemCategoryId == relation.ItemCategoryId);
                                if (itemCategoryCollection == null)
                                {
                                    var itemCollection = context.ItemCategoryCollection.FirstOrDefault(e => e.ItemCategoryId == relation.ItemCategoryId
                                                                                                        && e.ItemId == relation.ItemId && e.CategoryId == relation.CategoryId);
                                    if (itemCollection != null)
                                    {
                                        context.ItemCategoryCollection.Remove(itemCollection);
                                        context.SaveChanges();
                                    }
                                }
                            }

                            // Adding new item category collection
                            foreach (var itemCategoryCollection in objItemCategory.ItemCategoryCollections)
                            {
                                var item = context.ItemCategoryCollection.FirstOrDefault(e =>
                                    e.ItemCategoryId == objItemCategory.ItemCategory.ItemCategoryId && e.CategoryId == objItemCategory.ItemCategory.CategoryId
                                                                                                    && e.ItemId == itemCategoryCollection.ItemId);

                                if (item != null) continue;
                                itemCategoryCollection.CategoryId = objItemCategory.ItemCategory.CategoryId;
                                itemCategoryCollection.ItemCategoryId = objItemCategory.ItemCategory.ItemCategoryId;
                                context.ItemCategoryCollection.Add(itemCategoryCollection);
                                context.SaveChanges();
                            }

                            transaction.Commit();
                            return CommonUtils.CreateSuccessApiResponse(objItemCategory.ItemCategory.ItemCategoryId);
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

        [Route("api/StoreAdmin/GetItemsWithCategoryByWarehouseId")]
        [HttpGet]
        public ApiResponse GetItemsWithCategoryByWarehouseId(int warehouseId, int organizationId)
        {
            try
            {
                var saveItemConsumptionWithCategory = new SaveItemConsumptionWithCategory
                {
                    ConsumptionCategory = new List<ConsumptionCategory>()
                };

                List<ItemCategory> itemCategoryList = GetItemCategories(organizationId);
                foreach (var itemCategory in itemCategoryList)
                {
                    var consumptionCategory = new ConsumptionCategory();

                    consumptionCategory.CategoryName = itemCategory.CategoryName;
                    consumptionCategory.ItemCategoryId = itemCategory.ItemCategoryId;
                    var itemCollections = GetItemCategoryCollections(itemCategory.ItemCategoryId, warehouseId);
                    var consumptionItemList = new List<ConsumptionItems>();
                    foreach (var item in itemCollections)
                    {
                        var consumptionItem = new ConsumptionItems
                        {
                            UnitId = item.UnitId,
                            ItemId = item.ItemId,
                            ItemName = item.ItemName,
                            OnHandQty = item.OnHandQty,
                            UnitName = item.UnitName,
                            Quantity = 0
                        };
                        consumptionItemList.Add(consumptionItem);
                    }


                    consumptionCategory.ConsumptionItems = consumptionItemList;
                    saveItemConsumptionWithCategory.ConsumptionCategory.Add(consumptionCategory);
                }

                return CommonUtils.CreateSuccessApiResponse(saveItemConsumptionWithCategory);
            }
            catch (Exception ex)
            {
                ExceptionHandledLogger.Log(ex);
                return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
            }
        }

        #endregion

        #region Prefix

        [Route("api/StoreAdmin/GetPrefixByType")]
        [HttpGet]
        public ApiResponse GetPrefix(int organizationId, string type)
        {
            using (var context = new StoreContext())
            {
                var organization = context.Organizations.FirstOrDefault(e => e.OrganizationId == organizationId);
                var transactionType = type.ToLower();
                int count = 0;
                int charPrefixHashCount = 0;
                string formatString = string.Empty;
                string prefix;
                char patternChar = '#';
                switch (transactionType)
                {
                    case "po":
                        {
                            formatString = organization.PurchaseOrderPrefix;
                            count = context.PurchaseOrders.Count(x => x.OrganizationId == organizationId);
                            break;
                        }
                    case "pr":
                        {
                            formatString = organization.ReturnOrderPrefix;
                            count = context.PurchaseReceive.Count(x => x.OrganizationId == organizationId);
                            break;
                        }
                    case "ic":
                        {
                            formatString = organization.ItemConsumptionPrefix;
                            count = context.Consumption.Count(x => x.OrganizationId == organizationId);
                            break;
                        }
                    case "ia":
                        {
                            formatString = organization.InventoryAdjustmentPrefix;
                            count = context.InventoryAdjustment.Count(x => x.OrganizationId == organizationId);
                            break;
                        }
                    default:
                        prefix = new Random().Next(1, 1000).ToString();
                        break;
                }
                count++;
                charPrefixHashCount = formatString.Count(x => x == patternChar);
                var padValues = count.ToString().PadLeft(charPrefixHashCount, '0');
                prefix = formatString.Replace(patternChar.ToString().PadLeft(charPrefixHashCount, patternChar), padValues);
                return CommonUtils.CreateSuccessApiResponse(prefix);
            }
        }

        #endregion

        #region Purchase Order

        [Route("api/StoreAdmin/ListPurchaseOrder")]
        [HttpGet]
        public ApiResponse GetAllPurchaseOrder(int organizationId)
        {
            using (StoreContext context = new StoreContext())
            {
                var resultList = context.PurchaseOrders.Where(e => e.Status == 1 && e.OrganizationId == organizationId).ToList();
                return CommonUtils.CreateSuccessApiResponse(resultList);
            }
        }

        [Route("api/StoreAdmin/DeletePurchaseOrder")]
        [HttpGet]
        public ApiResponse DeletePurchaseOrder(int purchaseOrderId)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var item = context.PurchaseOrders.FirstOrDefault(e => e.PurchaseOrderId == purchaseOrderId);
                            if (item != null)
                            {
                                item.UpdatedUserId = -1;
                                item.UpdatedDateTime = DateTime.UtcNow;
                                item.Status = 0;
                                context.SaveChanges();
                            }

                            transaction.Commit();

                            return CommonUtils.CreateSuccessApiResponse(purchaseOrderId);
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

        [Route("api/StoreAdmin/GetPurchaseOrderByID")]
        [HttpGet]
        public ApiResponse GetPurchaseOrderById(int purchaseOrderId)
        {
            using (var context = new StoreContext())
            {
                try
                {
                    var savePurchaseOrder = new SavePurchaseOrder()
                    {
                        PurchaseOrderItems = context.PurchaseOrderItems.Where(x => x.PurchaseOrderId == purchaseOrderId).ToList(),
                        PurchaseOrder = context.PurchaseOrders.FirstOrDefault(e => e.PurchaseOrderId == purchaseOrderId),
                        IsPurchaseReceiveSaved = context.PurchaseReceive.Any(e => e.PurchaseOrderId == purchaseOrderId)
                    };

                    return CommonUtils.CreateSuccessApiResponse(savePurchaseOrder);
                }
                catch (Exception ex)
                {
                    return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                }
            }
        }

        [Route("api/StoreAdmin/AddPurchaseOrder")]
        [HttpPost]
        public ApiResponse AddPurchaseOrder(SavePurchaseOrder savePurchaseOrder)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            savePurchaseOrder.PurchaseOrder.UpdatedUserId = -1;
                            savePurchaseOrder.PurchaseOrder.UpdatedDateTime = DateTime.UtcNow;
                            savePurchaseOrder.PurchaseOrder.Status = 1;
                            savePurchaseOrder.PurchaseOrder.OrderStatus = 1;
                            savePurchaseOrder.PurchaseOrder.OrderDate = DateTime.UtcNow;
                            context.PurchaseOrders.Add(savePurchaseOrder.PurchaseOrder);
                            context.SaveChanges();

                            foreach (var purchaseOrderItem in savePurchaseOrder.PurchaseOrderItems)
                            {
                                purchaseOrderItem.PurchaseOrderId = savePurchaseOrder.PurchaseOrder.PurchaseOrderId;
                                purchaseOrderItem.UpdatedDateTime = DateTime.UtcNow;
                                purchaseOrderItem.UpdatedUserId = -1;
                                context.PurchaseOrderItems.Add(purchaseOrderItem);
                                context.SaveChanges();
                            }

                            transaction.Commit();
                            return CommonUtils.CreateSuccessApiResponse(savePurchaseOrder.PurchaseOrder.PurchaseOrderId);
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

        [Route("api/StoreAdmin/UpdatePurchaseOrder")]
        [HttpPost]
        public ApiResponse UpdatePurchaseOrder(SavePurchaseOrder savePurchaseOrder)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var purchaseOrder = context.PurchaseOrders.FirstOrDefault(x => x.PurchaseOrderId == savePurchaseOrder.PurchaseOrder.PurchaseOrderId);
                            purchaseOrder.VendorId = savePurchaseOrder.PurchaseOrder.VendorId;
                            purchaseOrder.NetAmount = savePurchaseOrder.PurchaseOrder.NetAmount;
                            purchaseOrder.PurchaseOrderNo = savePurchaseOrder.PurchaseOrder.PurchaseOrderNo;
                            purchaseOrder.UpdatedUserId = -1;
                            purchaseOrder.UpdatedDateTime = DateTime.UtcNow;
                            purchaseOrder.Status = 1;

                            context.SaveChanges();

                            foreach (var purchaseOrderItem in savePurchaseOrder.PurchaseOrderItems)
                            {
                                if (purchaseOrderItem.PurchaseOrderItemsId == 0)
                                {
                                    purchaseOrderItem.PurchaseOrderId = savePurchaseOrder.PurchaseOrder.PurchaseOrderId;
                                    purchaseOrderItem.UpdatedDateTime = DateTime.UtcNow;
                                    purchaseOrderItem.UpdatedUserId = -1;
                                    context.PurchaseOrderItems.Add(purchaseOrderItem);
                                    context.SaveChanges();
                                }
                                else
                                {
                                    var poItems = context.PurchaseOrderItems.FirstOrDefault(x =>
                                        x.PurchaseOrderItemsId == purchaseOrderItem.PurchaseOrderItemsId);

                                    poItems.PurchaseOrderId = purchaseOrderItem.PurchaseOrderId;
                                    poItems.NetAmount = purchaseOrderItem.NetAmount;
                                    poItems.LineNo = purchaseOrderItem.LineNo;
                                    poItems.UpdatedDateTime = DateTime.UtcNow;
                                    poItems.UpdatedUserId = -1;
                                    poItems.ItemId = purchaseOrderItem.ItemId;
                                    poItems.Quantity = purchaseOrderItem.Quantity;
                                    poItems.UnitId = purchaseOrderItem.UnitId;
                                    poItems.UnitPrice = purchaseOrderItem.UnitPrice;
                                    poItems.WarehouseId = purchaseOrderItem.WarehouseId;
                                    context.SaveChanges();
                                }
                            }

                            transaction.Commit();
                            return CommonUtils.CreateSuccessApiResponse(savePurchaseOrder.PurchaseOrder.PurchaseOrderId);
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

        #endregion

        #region Purchase Receive

        [Route("api/StoreAdmin/GetPurchaseReceiveByPurchaseOrder")]
        [HttpGet]
        public ApiResponse GetPurchaseReceiveByPurchaseOrder(int purchaseOrderId)
        {
            using (var context = new StoreContext())
            {
                try
                {
                    var savePurchaseOrder = new SavePurchaseReceive()
                    {
                        InvoiceNumber = context.Invoice.FirstOrDefault(x => x.PurchaseOrderId == purchaseOrderId)?.InvoiceNo,
                        PurchaseReceiveItems = null,
                        PurchaseReceive = context.PurchaseReceive.FirstOrDefault(e => e.PurchaseOrderId == purchaseOrderId)
                    };

                    savePurchaseOrder.PurchaseReceiveItems = context.PurchaseReceiveItems
                        .Where(x => x.PurchaseReceiveId == savePurchaseOrder.PurchaseReceive.PurchaseReceiveId)
                        .ToList();
                    return CommonUtils.CreateSuccessApiResponse(savePurchaseOrder);
                }
                catch (Exception ex)
                {
                    return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                }
            }
        }

        [Route("api/StoreAdmin/AddPurchaseReceive")]
        [HttpPost]
        public ApiResponse AddPurchaseReceive(SavePurchaseReceive savePurchaseOrder)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var purchaseReceiveNo = context.PurchaseOrders.FirstOrDefault(e => e.PurchaseOrderId == savePurchaseOrder.PurchaseReceive.PurchaseOrderId)?.PurchaseOrderNo ?? string.Empty;
                            savePurchaseOrder.PurchaseReceive.UpdatedUserId = -1;
                            savePurchaseOrder.PurchaseReceive.UpdatedDateTime = DateTime.UtcNow;
                            savePurchaseOrder.PurchaseReceive.Status = 1;
                            savePurchaseOrder.PurchaseReceive.PurchaseReceiveStatus = 1;
                            savePurchaseOrder.PurchaseReceive.PurchaseReceiveDate = DateTime.UtcNow;
                            savePurchaseOrder.PurchaseReceive.PurchaseReceiveNo = purchaseReceiveNo;
                            context.PurchaseReceive.Add(savePurchaseOrder.PurchaseReceive);
                            context.SaveChanges();

                            foreach (var purchaseOrderItem in savePurchaseOrder.PurchaseReceiveItems)
                            {
                                purchaseOrderItem.PurchaseReceiveId = savePurchaseOrder.PurchaseReceive.PurchaseReceiveId;
                                purchaseOrderItem.UpdatedDateTime = DateTime.UtcNow;
                                purchaseOrderItem.UpdatedUserId = -1;
                                context.PurchaseReceiveItems.Add(purchaseOrderItem);
                                context.SaveChanges();
                            }

                            transaction.Commit();
                            return CommonUtils.CreateSuccessApiResponse(savePurchaseOrder.PurchaseReceive.PurchaseReceiveId);
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

        [Route("api/StoreAdmin/SavePurchaseReceive")]
        [HttpPost]
        public ApiResponse SavePurchaseReceive(SavePurchaseReceive savePurchaseOrder)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var purchaseReceiveNo = context.PurchaseOrders.FirstOrDefault(e => e.PurchaseOrderId == savePurchaseOrder.PurchaseReceive.PurchaseOrderId)?.PurchaseOrderNo ?? string.Empty;
                            var purchaseReceive = context.PurchaseReceive.FirstOrDefault(x =>
                                x.PurchaseReceiveId == savePurchaseOrder.PurchaseReceive.PurchaseReceiveId);
                            purchaseReceive.NetAmount = savePurchaseOrder.PurchaseReceive.NetAmount;
                            purchaseReceive.OrganizationId = savePurchaseOrder.PurchaseReceive.OrganizationId;
                            purchaseReceive.PurchaseOrderId = savePurchaseOrder.PurchaseReceive.PurchaseOrderId;
                            purchaseReceive.PurchaseReceiveNo = purchaseReceiveNo;
                            purchaseReceive.VendorId = savePurchaseOrder.PurchaseReceive.VendorId;
                            purchaseReceive.NetAmount = savePurchaseOrder.PurchaseReceive.NetAmount;
                            purchaseReceive.PurchaseReceiveStatus = savePurchaseOrder.PurchaseReceive.PurchaseReceiveStatus;
                            purchaseReceive.PurchaseReceiveDate = savePurchaseOrder.PurchaseReceive.PurchaseReceiveDate;
                            purchaseReceive.UpdatedUserId = -1;
                            purchaseReceive.UpdatedDateTime = DateTime.UtcNow;
                            purchaseReceive.Status = 1;
                            context.SaveChanges();

                            foreach (var purchaseOrderItem in savePurchaseOrder.PurchaseReceiveItems)
                            {
                                var item = context.PurchaseReceiveItems.FirstOrDefault(x =>
                                    x.PurchaseReceiveItemsId == purchaseOrderItem.PurchaseReceiveItemsId);
                                item.BatchNo = purchaseOrderItem.BatchNo;
                                item.PurchaseReceiveId = purchaseOrderItem.PurchaseReceiveId;
                                item.NetAmount = purchaseOrderItem.NetAmount;
                                item.ItemId = purchaseOrderItem.ItemId;
                                item.LineNo = purchaseOrderItem.LineNo;
                                item.WarehouseId = purchaseOrderItem.WarehouseId;
                                item.Quantity = purchaseOrderItem.Quantity;
                                item.ReceiveQuantity = purchaseOrderItem.ReceiveQuantity;
                                item.UnitId = purchaseOrderItem.UnitId;
                                item.UnitPrice = purchaseOrderItem.UnitPrice;
                                item.UpdatedDateTime = DateTime.UtcNow;
                                item.UpdatedUserId = purchaseOrderItem.UpdatedUserId;

                                context.SaveChanges();
                            }

                            transaction.Commit();
                            return CommonUtils.CreateSuccessApiResponse(savePurchaseOrder.PurchaseReceive.PurchaseReceiveId);
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


        #endregion

        #region Invoice

        [Route("api/StoreAdmin/SaveInvoice")]
        [HttpPost]
        public ApiResponse SaveInvoice(SavePurchaseReceive savePurchaseOrder)
        {
            // save purchase receive
            var response = savePurchaseOrder.PurchaseReceive.PurchaseReceiveId > 0 ? SavePurchaseReceive(savePurchaseOrder) : AddPurchaseReceive(savePurchaseOrder);
            if (response.StatusCode != CommonUtils.ApiCallSuccess)
                return response;

            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            string transactionNo = string.Empty;
                            var purchaseOrder = context.PurchaseOrders.FirstOrDefault(e =>
                                e.PurchaseOrderId == savePurchaseOrder.PurchaseReceive.PurchaseOrderId);
                            if (purchaseOrder != null)
                            {
                                purchaseOrder.OrderStatus = 4;
                                transactionNo = purchaseOrder.PurchaseOrderNo;
                            }
                            context.SaveChanges();
                            var purchaseOrderReceive = context.PurchaseReceive.FirstOrDefault(e =>
                                e.PurchaseOrderId == savePurchaseOrder.PurchaseReceive.PurchaseOrderId);
                            if (purchaseOrderReceive != null)
                                purchaseOrderReceive.PurchaseReceiveStatus = 4;
                            context.SaveChanges();


                            var invoice = new Invoice
                            {
                                VendorId = savePurchaseOrder.PurchaseReceive.VendorId,
                                NetAmount = savePurchaseOrder.PurchaseReceive.NetAmount,
                                InvoiceNo = savePurchaseOrder.InvoiceNumber,
                                PurchaseOrderId = savePurchaseOrder.PurchaseReceive.PurchaseOrderId,
                                InvoiceStatus = 1,
                                InvoiceDate = DateTime.UtcNow,
                                UpdatedUserId = savePurchaseOrder.PurchaseReceive.UpdatedUserId,
                                UpdatedDateTime = DateTime.UtcNow,
                                Status = 1,
                                OrganizationId = savePurchaseOrder.PurchaseReceive.OrganizationId
                            };
                            context.Invoice.Add(invoice);
                            context.SaveChanges();

                            foreach (var purchaseOrderItem in savePurchaseOrder.PurchaseReceiveItems)
                            {
                                var item = new InvoiceItems
                                {
                                    BatchNo = purchaseOrderItem.BatchNo,
                                    InvoiceId = invoice.InvoiceId,
                                    NetAmount = purchaseOrderItem.NetAmount,
                                    ItemId = purchaseOrderItem.ItemId,
                                    LineNo = purchaseOrderItem.LineNo,
                                    WarehouseId = purchaseOrderItem.WarehouseId,
                                    Quantity = purchaseOrderItem.Quantity,
                                    ReceivedQuantity = purchaseOrderItem.ReceiveQuantity,
                                    UnitId = purchaseOrderItem.UnitId,
                                    UnitPrice = purchaseOrderItem.UnitPrice,
                                    InvoiceNo = transactionNo,
                                    InvoiceDate = DateTime.UtcNow,
                                    UpdatedDateTime = DateTime.UtcNow,
                                    UpdatedUserId = purchaseOrderItem.UpdatedUserId
                                };
                                context.InvoiceItems.Add(item);
                                context.SaveChanges();
                            }

                            var transactionItem = new Transactions
                            {
                                TransactionId = transactionNo,
                                Type = 3,
                                RelationId = invoice.InvoiceId,
                                OrganizationId = invoice.OrganizationId
                            };
                            context.Transactions.Add(transactionItem);
                            context.SaveChanges();

                            foreach (var purchaseOrderItem in savePurchaseOrder.PurchaseReceiveItems)
                            {
                                var ratio = Convert.ToDouble(context.UomConversions.FirstOrDefault(x => x.Id == purchaseOrderItem.UnitId)?.Ratio);
                                var convertedQty = purchaseOrderItem.ReceiveQuantity * ratio;
                                var onHandStock = context.Stocks.Where(x => x.ItemId == purchaseOrderItem.ItemId
                                                                            && x.WarehouseId == purchaseOrderItem.WarehouseId).ToList().Sum(i => i.Quantity);
                                var item = new Stock()
                                {
                                    ItemId = purchaseOrderItem.ItemId,
                                    WarehouseId = purchaseOrderItem.WarehouseId,
                                    WorkerId = purchaseOrderItem.UpdatedUserId,
                                    Quantity = convertedQty,
                                    OnHandQuantity = onHandStock + convertedQty,
                                    TransactionId = transactionItem.Id,
                                    UpdatedDateTime = DateTime.UtcNow,
                                    UpdatedUserId = purchaseOrderItem.UpdatedUserId,
                                    Status = 1,
                                };
                                context.Stocks.Add(item);
                                context.SaveChanges();
                            }

                            transaction.Commit();

                            return CommonUtils.CreateSuccessApiResponse(invoice.InvoiceId);
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

        #endregion

        #region ItemConsumption

        [Route("api/StoreAdmin/SaveItemConsumptionDeprecated")]
        [HttpPost]
        public ApiResponse SaveItemConsumption(SaveItemConsumption saveItemConsumption)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            saveItemConsumption.Consumption.UpdatedUserId = -1;
                            saveItemConsumption.Consumption.UpdatedDateTime = DateTime.UtcNow;
                            saveItemConsumption.Consumption.Status = 1;
                            saveItemConsumption.Consumption.ConsumptionDate = DateTime.UtcNow;
                            context.Consumption.Add(saveItemConsumption.Consumption);
                            context.SaveChanges();

                            int count = 0;
                            foreach (var consumptionItem in saveItemConsumption.ConsumptionItems)
                            {
                                count++;
                                consumptionItem.LineNo = count.ToString();
                                consumptionItem.UpdatedUserId = -1;
                                consumptionItem.UpdatedDateTime = DateTime.UtcNow;
                                consumptionItem.ConsumptionId = saveItemConsumption.Consumption.ConsumptionId;
                                context.ConsumptionItems.Add(consumptionItem);
                                context.SaveChanges();
                            }

                            var transactionItem = new Transactions
                            {
                                TransactionId = saveItemConsumption.Consumption.ConsumptionNo,
                                Type = 2,
                                RelationId = saveItemConsumption.Consumption.ConsumptionId,
                                OrganizationId = saveItemConsumption.Consumption.OrganizationId
                            };
                            context.Transactions.Add(transactionItem);
                            context.SaveChanges();

                            foreach (var consumptionItem in saveItemConsumption.ConsumptionItems)
                            {
                                var onHandStock = context.Stocks.Where(x => x.ItemId == consumptionItem.ItemId
                                                                                           && x.WarehouseId == saveItemConsumption.Consumption.WarehouseId).ToList().Sum(i => i.Quantity);
                                var item = new Stock()
                                {
                                    ItemId = consumptionItem.ItemId,
                                    WarehouseId = saveItemConsumption.Consumption.WarehouseId,
                                    WorkerId = consumptionItem.UpdatedUserId,
                                    Quantity = -consumptionItem.Quantity,
                                    OnHandQuantity = onHandStock - consumptionItem.Quantity,
                                    TransactionId = transactionItem.Id,
                                    UpdatedDateTime = DateTime.UtcNow,
                                    UpdatedUserId = consumptionItem.UpdatedUserId,
                                    Status = 1,
                                };
                                context.Stocks.Add(item);
                                context.SaveChanges();
                            }

                            transaction.Commit();

                            return CommonUtils.CreateSuccessApiResponse(saveItemConsumption.Consumption.ConsumptionId);
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


        [Route("api/StoreAdmin/SaveItemConsumption")]
        [HttpPost]
        public ApiResponse SaveItemConsumptionWithCategory(SaveItemConsumptionWithCategory saveItemConsumption)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            saveItemConsumption.Consumption.UpdatedUserId = -1;
                            saveItemConsumption.Consumption.UpdatedDateTime = DateTime.UtcNow;
                            saveItemConsumption.Consumption.Status = 1;
                            saveItemConsumption.Consumption.ConsumptionDate = DateTime.UtcNow;
                            context.Consumption.Add(saveItemConsumption.Consumption);
                            context.SaveChanges();

                            var transactionItem = new Transactions
                            {
                                TransactionId = saveItemConsumption.Consumption.ConsumptionNo,
                                Type = 2,
                                RelationId = saveItemConsumption.Consumption.ConsumptionId,
                                OrganizationId = saveItemConsumption.Consumption.OrganizationId
                            };
                            context.Transactions.Add(transactionItem);
                            context.SaveChanges();

                            int count = 0;
                            foreach (var consumptionCategory in saveItemConsumption.ConsumptionCategory)
                            {
                                foreach (var consumptionItem in consumptionCategory.ConsumptionItems)
                                {
                                    if (!(consumptionItem.Quantity > 0)) continue;
                                    count++;
                                    consumptionItem.LineNo = count.ToString();
                                    consumptionItem.UpdatedUserId = -1;
                                    consumptionItem.UpdatedDateTime = DateTime.UtcNow;
                                    consumptionItem.ConsumptionId = saveItemConsumption.Consumption.ConsumptionId;
                                    context.ConsumptionItems.Add(consumptionItem);
                                    context.SaveChanges();

                                    var onHandStock = context.Stocks.Where(x => x.ItemId == consumptionItem.ItemId
                                                                                && x.WarehouseId ==
                                                                                saveItemConsumption.Consumption
                                                                                    .WarehouseId).ToList().Sum(i =>
                                        i.Quantity);

                                    var item = new Stock()
                                    {
                                        ItemId = consumptionItem.ItemId,
                                        WarehouseId = saveItemConsumption.Consumption.WarehouseId,
                                        WorkerId = consumptionItem.UpdatedUserId,
                                        Quantity = -consumptionItem.Quantity,
                                        OnHandQuantity = onHandStock - consumptionItem.Quantity,
                                        TransactionId = transactionItem.Id,
                                        UpdatedDateTime = DateTime.UtcNow,
                                        UpdatedUserId = consumptionItem.UpdatedUserId,
                                        Status = 1,
                                    };
                                    context.Stocks.Add(item);
                                    context.SaveChanges();
                                }
                            }

                            transaction.Commit();

                            return CommonUtils.CreateSuccessApiResponse(saveItemConsumption.Consumption.ConsumptionId);
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

        #endregion

        #region InventoryAdjustment

        [Route("api/StoreAdmin/SaveInventoryAdjustment")]
        [HttpPost]
        public ApiResponse SaveInventoryAdjustment(SaveInventoryAdjustment saveInventoryAdjustment)
        {
            try
            {
                using (var context = new StoreContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            saveInventoryAdjustment.InventoryAdjustment.UpdatedUserId = -1;
                            saveInventoryAdjustment.InventoryAdjustment.UpdatedDateTime = DateTime.UtcNow;
                            saveInventoryAdjustment.InventoryAdjustment.Status = 1;
                            saveInventoryAdjustment.InventoryAdjustment.AdjustmentDate = DateTime.UtcNow;
                            context.InventoryAdjustment.Add(saveInventoryAdjustment.InventoryAdjustment);
                            context.SaveChanges();

                            Int16 count = 0;
                            foreach (var adjustmentItems in saveInventoryAdjustment.InventoryAdjustmentItems)
                            {
                                count++;
                                adjustmentItems.LineNo = count;
                                adjustmentItems.UpdatedUserId = -1;
                                adjustmentItems.UpdatedDateTime = DateTime.UtcNow;
                                adjustmentItems.InventoryAdjustmentId = saveInventoryAdjustment.InventoryAdjustment.InventoryAdjustmentId;
                                context.InventoryAdjustmentItems.Add(adjustmentItems);
                                context.SaveChanges();
                            }

                            var transactionItem = new Transactions
                            {
                                TransactionId = saveInventoryAdjustment.InventoryAdjustment.InventoryAdjustmentNo,
                                Type = 1,
                                RelationId = saveInventoryAdjustment.InventoryAdjustment.InventoryAdjustmentId,
                                OrganizationId = saveInventoryAdjustment.InventoryAdjustment.OrganizationId
                            };
                            context.Transactions.Add(transactionItem);
                            context.SaveChanges();

                            foreach (var consumptionItem in saveInventoryAdjustment.InventoryAdjustmentItems)
                            {
                                var onHandStock = context.Stocks.Where(x => x.ItemId == consumptionItem.ItemId
                                                                            && x.WarehouseId == consumptionItem.WarehouseId).ToList().Sum(i => i.Quantity);
                                var item = new Stock()
                                {
                                    ItemId = consumptionItem.ItemId,
                                    WarehouseId = consumptionItem.WarehouseId,
                                    WorkerId = consumptionItem.UpdatedUserId,
                                    Quantity = consumptionItem.Quantity,
                                    OnHandQuantity = onHandStock + consumptionItem.Quantity,
                                    TransactionId = transactionItem.Id,
                                    UpdatedDateTime = DateTime.UtcNow,
                                    UpdatedUserId = consumptionItem.UpdatedUserId,
                                    Status = 1,
                                };
                                context.Stocks.Add(item);
                                context.SaveChanges();
                            }

                            transaction.Commit();

                            return CommonUtils.CreateSuccessApiResponse(saveInventoryAdjustment.InventoryAdjustment.InventoryAdjustmentId);
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

        [Route("api/StoreAdmin/GetInventoryAdjustmentByID")]
        [HttpGet]
        public ApiResponse GetInventoryAdjustmentById(int inventoryAdjustmentId)
        {
            using (var context = new StoreContext())
            {
                try
                {
                    var saveInventoryAdjustment = new SaveInventoryAdjustment()
                    {
                        InventoryAdjustmentItems = context.InventoryAdjustmentItems.Where(x => x.InventoryAdjustmentId == inventoryAdjustmentId).ToList(),
                        InventoryAdjustment = context.InventoryAdjustment.FirstOrDefault(e => e.InventoryAdjustmentId == inventoryAdjustmentId),
                    };

                    return CommonUtils.CreateSuccessApiResponse(saveInventoryAdjustment);
                }
                catch (Exception ex)
                {
                    return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                }
            }
        }
        #endregion

        #region Login

        [Route("api/StoreAdmin/Login")]
        [HttpPost]
        public ApiResponse Login(UserLogin userLogin)
        {
            using (var context = new StoreContext())
            {
                try
                {
                    if (userLogin.UserId == "admin" && userLogin.Password == "admin")
                    {
                        return CommonUtils.CreateSuccessApiResponse(new UserDetail() { DefaultWarehouseId = 0, OrganizationId = 0, UserId = -1, UserName = "" });
                    }
                    var worker = context.Workers.FirstOrDefault(e =>
                        e.UserId == userLogin.UserId && e.Password == userLogin.Password && e.IsBlocked == false &&
                        e.Status == 1);

                    if (worker == null) return CommonUtils.CreateFailureApiResponse("Login Failed", -1);
                    var org = context.Organizations.FirstOrDefault(x => x.OrganizationId == worker.OrganizationId);
                    var userDetail = new UserDetail
                    {
                        OrganizationId = worker.OrganizationId,
                        UserId = worker.WorkerId,
                        UserName = worker.Name,
                        DefaultWarehouseId = Convert.ToInt32(org?.TransactionalWarehouseId)
                    };
                    return CommonUtils.CreateSuccessApiResponse(userDetail);
                }
                catch (Exception ex)
                {
                    return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
                }
            }
        }

        #endregion

        #region ItemsUsageDetails

        private List<Items> GetItemsAvgPrice(int organizationId)
        {
            try
            {
                var itemList = new List<Items>();

                var con = new SqlConnection(connStr);
                con.Open();

                var sqlQuery =
                    $"  ;with cteRowNumber as (SELECT poi.ItemId, ROUND(AVG(poi.UnitPrice),2) AS AvgPrice FROM dbo.PurchaseOrderItems poi " +
                    $" INNER JOIN dbo.PurchaseOrder po ON po.PurchaseOrderId = poi.PurchaseOrderId " +
                    $" WHERE po.OrganizationId = {organizationId} GROUP BY poi.ItemId) " +
                    $" select i.ItemId, CAST(ISNULL(cte.AvgPrice, 0) as decimal(10, 2)) AS AvgPrice, ISNULL(v.[Name], '') AS SourceOfOriginName from dbo.Items i " +
                    $" left join cteRowNumber cte ON i.ItemId = cte.ItemId left join dbo.Vendor v ON v.VendorId = i.SourceOfOrigin " +
                    $"  where i.OrganizationId = {organizationId} ";


                using (var command = new SqlCommand(sqlQuery, con))
                {
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tmpRecord = new Items()
                            {
                                ItemId = int.Parse(reader["ItemId"].ToString()),
                                AvgPrice = double.Parse(reader["AvgPrice"].ToString()),
                                SourceOfOriginName = reader["SourceOfOriginName"].ToString(),
                            };
                            itemList.Add(tmpRecord);
                        }
                    }
                }

                con.Close();

                return itemList;
            }
            catch (Exception ex)
            {
                ExceptionHandledLogger.Log(ex);
                return new List<Items>();
            }
        }

        [Route("api/StoreAdmin/GetVendorPriceListByItemId")]
        [HttpGet]
        public ApiResponse GetVendorPriceListByItemId(int itemId, int organizationId)
        {
            try
            {
                var vendorPriceLists = new List<VendorPriceList>();

                var con = new SqlConnection(connStr);
                con.Open();

                var sqlQuery = $" ;with cteRowNumber as ( " +
                               $" select poi.ItemId, poi.UnitPrice, po.VendorId, po.OrderDate, " +
                               $" row_number() over(partition by poi.ItemId, po.VendorId order by poi.PurchaseOrderItemsId desc) as RowNum " +
                               $" from dbo.PurchaseOrderItems poi " +
                               $" inner join dbo.PurchaseOrder po on poi.PurchaseOrderId = po.PurchaseOrderId " +
                               $" where po.OrganizationId = {organizationId} ) " +
                               $" select cte.ItemId, cte.UnitPrice, cte.VendorId, v.[Name] AS VendorName, v.Id AS VendorNo, cte.OrderDate " +
                               $" from cteRowNumber cte " +
                               $" inner join dbo.Vendor v ON v.VendorId = cte.VendorId " +
                               $" where RowNum = 1 and cte.ItemId = {itemId}";


                using (var command = new SqlCommand(sqlQuery, con))
                {
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tmpRecord = new VendorPriceList()
                            {
                                VendorNo = reader["VendorNo"].ToString(),
                                VendorName = reader["VendorName"].ToString(),
                                UnitPrice = double.Parse(reader["UnitPrice"].ToString()),
                                OrderDate = DateTime.Parse(reader["OrderDate"].ToString()),
                            };
                            vendorPriceLists.Add(tmpRecord);
                        }
                    }
                }

                con.Close();

                return CommonUtils.CreateSuccessApiResponse(vendorPriceLists);
            }
            catch (Exception ex)
            {
                ExceptionHandledLogger.Log(ex);
                return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
            }
        }

        [Route("api/StoreAdmin/GetAllTransactionsByItemId")]
        [HttpGet]
        public ApiResponse GetAllTransactionsByItemId(int itemId, int organizationId)
        {
            try
            {
                var transactionDetails = new List<TransactionDetail>();

                var con = new SqlConnection(connStr);
                con.Open();

                var sqlQuery = $"SELECT i.ItemNo,inv.InvoiceDate AS TransactionDate, 'Purchase Order' AS Reference, tr.TransactionId AS RefNo, invi.Quantity, invi.BatchNo AS LotNo FROM dbo.Transactions tr " +
                    $" INNER JOIN dbo.Invoice inv ON inv.InvoiceId = tr.RelationId AND tr.[Type] = 3 " +
                $" INNER JOIN dbo.InvoiceItems invi ON inv.InvoiceId = invi.InvoiceId " +
                $" INNER JOIN dbo.Items i ON i.ItemId = invi.ItemId " +
                $" WHERE invi.ItemId = {itemId} AND inv.OrganizationId = {organizationId} " +
                $" UNION ALL " +
                $" SELECT i.ItemNo,inv.AdjustmentDate AS TransactionDate, 'Adjustment' AS Reference, tr.TransactionId AS RefNo, invi.Quantity, invi.Reason AS LotNo FROM dbo.Transactions tr " +
                $" INNER JOIN dbo.InventoryAdjustment inv ON inv.InventoryAdjustmentId = tr.RelationId AND tr.[Type] = 1 " +
                $" INNER JOIN dbo.InventoryAdjustmentItems invi ON inv.InventoryAdjustmentId = invi.InventoryAdjustmentId " +
                $" INNER JOIN dbo.Items i ON i.ItemId = invi.ItemId " +
                $" WHERE invi.ItemId = {itemId} AND inv.OrganizationId = {organizationId} " +
                $" UNION ALL " +
                $" SELECT i.ItemNo,inv.ConsumptionDate AS TransactionDate, 'Item Consumption' AS Reference, tr.TransactionId AS RefNo, invi.Quantity, '' AS LotNo FROM dbo.Transactions tr " +
                $" INNER JOIN dbo.Consumption inv ON inv.ConsumptionId = tr.RelationId AND tr.[Type] = 2 " +
                $" INNER JOIN dbo.ConsumptionItems invi ON inv.ConsumptionId = invi.ConsumptionId " +
                $" INNER JOIN dbo.Items i ON i.ItemId = invi.ItemId " +
                $" WHERE invi.ItemId = {itemId} AND inv.OrganizationId = {organizationId}";


                using (var command = new SqlCommand(sqlQuery, con))
                {
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tmpRecord = new TransactionDetail()
                            {
                                ItemNo = reader["ItemNo"].ToString(),
                                Reference = reader["Reference"].ToString(),
                                RefNo = reader["RefNo"].ToString(),
                                LotNo = reader["LotNo"].ToString(),
                                Quantity = double.Parse(reader["Quantity"].ToString()),
                                TransactionDate = DateTime.Parse(reader["TransactionDate"].ToString()),
                            };
                            transactionDetails.Add(tmpRecord);
                        }
                    }
                }

                con.Close();

                return CommonUtils.CreateSuccessApiResponse(transactionDetails);
            }
            catch (Exception ex)
            {
                ExceptionHandledLogger.Log(ex);
                return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
            }
        }

        [Route("api/StoreAdmin/GetCategoryByItemId")]
        [HttpGet]
        public ApiResponse GetCategoryByItemId(int itemId, int organizationId)
        {
            try
            {
                var itemCategoryDetails = new List<CategoryItemDetails>();

                var con = new SqlConnection(connStr);
                con.Open();

                var sqlQuery = $" SELECT c.[Name] AS CategoryName, i.ItemNo FROM dbo.ItemCategoryCollection ic " +
                               $" INNER JOIN dbo.Category c ON c.CategoryId = ic.CategoryId " +
                               $" INNER JOIN dbo.Items i ON i.ItemId = ic.ItemId " +
                               $" WHERE ic.ItemId = {itemId} AND i.OrganizationId = {organizationId}";


                using (var command = new SqlCommand(sqlQuery, con))
                {
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tmpRecord = new CategoryItemDetails()
                            {
                                CategoryName = reader["CategoryName"].ToString(),
                                ItemNo = reader["ItemNo"].ToString(),
                            };
                            itemCategoryDetails.Add(tmpRecord);
                        }
                    }
                }

                con.Close();

                return CommonUtils.CreateSuccessApiResponse(itemCategoryDetails);
            }
            catch (Exception ex)
            {
                ExceptionHandledLogger.Log(ex);
                return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
            }
        }

        [Route("api/StoreAdmin/GetOnHandQtyByItemId")]
        [HttpGet]
        public ApiResponse GetOnHandQtyByItemId(int itemId, int organizationId)
        {
            try
            {
                var itemOnHandQtyList = new List<ItemOnHandQty>();

                var con = new SqlConnection(connStr);
                con.Open();

                var sqlQuery = $" ;with cteRowNumber as ( select s.ItemId,  s.OnHandQuantity, s.WarehouseId, " +
                $" row_number() over(partition by s.ItemId , s.WarehouseId order by s.StockId desc) as RowNum from dbo.Stock s " +
                $" INNER JOIN dbo.Items i ON i.ItemId = s.ItemId " +
                $" where s.ItemId = {itemId} AND i.OrganizationId = {organizationId}) " +
                $" select cte.ItemId, w.[Name] AS WarehouseName, u.[Name] AS Unit, cte.OnHandQuantity , i.ItemNo from cteRowNumber cte  " +
                $" INNER JOIN dbo.Items i ON i.ItemId = cte.ItemId " +
                $" INNER JOIN dbo.UomConversion u ON u.Id = i.InventoryUnitId " +
                $" INNER JOIN dbo.WareHouse w ON w.WarehouseId = cte.WarehouseId where cte.RowNum = 1 ";


                using (var command = new SqlCommand(sqlQuery, con))
                {
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var itemOnHandQty = new ItemOnHandQty();
                            itemOnHandQty.ItemId = int.Parse(reader["ItemId"].ToString());
                            itemOnHandQty.ItemNo = reader["ItemNo"].ToString();
                            itemOnHandQty.WarehouseName = reader["WarehouseName"].ToString();
                            itemOnHandQty.Unit = reader["Unit"].ToString();
                            itemOnHandQty.OnHandQuantity = double.Parse(reader["OnHandQuantity"].ToString());
                            itemOnHandQtyList.Add(itemOnHandQty);
                        }
                    }
                }

                con.Close();

                return CommonUtils.CreateSuccessApiResponse(itemOnHandQtyList);
            }
            catch (Exception ex)
            {
                ExceptionHandledLogger.Log(ex);
                return CommonUtils.CreateFailureApiResponse(GetErrorMessage(ex));
            }
        }


        [Route("api/StoreAdmin/ListInventoryAdjustment")]
        [HttpGet]
        public ApiResponse GetAllInventoryAdjustments(int organizationId)
        {
            using (StoreContext context = new StoreContext())
            {
                var resultList = context.InventoryAdjustment.Where(e => e.Status == 1 && e.OrganizationId == organizationId).ToList();
                return CommonUtils.CreateSuccessApiResponse(resultList);
            }
        }
        #endregion

        #region Private Methods

        private Organization GetOrganization(int organizationId)
        {
            try
            {
                var organization = new Organization();

                var con = new SqlConnection(connStr);
                con.Open();

                var sqlQuery =
                    $" SELECT [Org].[OrganizationId] AS [OrganizationId], [Org].[Id] AS [Id], [Org].[Name] AS [Name], [Org].[Description] AS [Description], [Org].[PurchaseOrderPrefix] AS [PurchaseOrderPrefix],  " +
                    $" [Org].[ReturnOrderPrefix] AS [ReturnOrderPrefix], [Org].[InventoryAdjustmentPrefix] AS [InventoryAdjustmentPrefix], [Org].[ItemConsumptionPrefix] AS [ItemConsumptionPrefix], [Org].[TransactionalWarehouseId] AS [TransactionalWarehouseId], " +
                    $" ISNULL([w].[Name], '') AS [TransactionalWarehouse], [Org].[TaxRegistrationNumber] AS [TaxRegistrationNumber], [Org].[UpdatedUserId] AS [UpdatedUserId], [Org].[UpdatedDateTime] AS [UpdatedDateTime], " +
                    $" [Org].[Status] AS [Status] FROM [dbo].[Organization] AS [Org] LEFT JOIN [dbo].[Warehouse] AS [w] ON [w].[WarehouseId] = [Org].[TransactionalWarehouseId] " +
                    $" WHERE [Org].[Status] = 1 AND [Org].[OrganizationId] = {organizationId} ";


                using (var command = new SqlCommand(sqlQuery, con))
                {
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            organization.OrganizationId = int.Parse(reader["OrganizationId"].ToString());
                            organization.Id = reader["Id"].ToString();
                            organization.Name = reader["Name"].ToString();
                            organization.Description = reader["Description"].ToString();
                            organization.PurchaseOrderPrefix = reader["PurchaseOrderPrefix"].ToString();
                            organization.ReturnOrderPrefix = reader["ReturnOrderPrefix"].ToString();
                            organization.InventoryAdjustmentPrefix = reader["InventoryAdjustmentPrefix"].ToString();
                            organization.TransactionalWarehouseId = int.Parse(reader["TransactionalWarehouseId"].ToString());
                            organization.TransactionalWarehouse = reader["TransactionalWarehouse"].ToString();
                            organization.TaxRegistrationNumber = reader["TaxRegistrationNumber"].ToString();
                            organization.ItemConsumptionPrefix = reader["ItemConsumptionPrefix"].ToString();
                            organization.UpdatedUserId = int.Parse(reader["UpdatedUserId"].ToString());
                            organization.UpdatedDateTime = DateTime.Parse(reader["UpdatedDateTime"].ToString());
                            organization.Status = short.Parse(reader["Status"].ToString());
                        }
                    }
                }

                con.Close();
                return organization;

            }
            catch (Exception ex)
            {
                ExceptionHandledLogger.Log(ex);
                return new Organization();
            }
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
        #endregion
    }
}
