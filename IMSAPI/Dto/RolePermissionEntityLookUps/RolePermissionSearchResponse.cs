using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.Dto.RolePermissionEntityLookUps
{
    public class RolePermissionSearchResponse
    {
        public IEnumerable<PermissionTreeView> PermissionList { get; set; }
        public RolePermissionSearchResult Result { get; set; }
    }

    public enum RolePermissionSearchResult
    {
        Success = 1,
        CannotGetListPermission = 2
    }
    public class PermissionTreeView
    {
        public int Value { get; set; }
        public string Text { get; set; }
        public List<PermissionTreeView> Children { get; set; }
        public bool Checked { get; set; }
    }
}