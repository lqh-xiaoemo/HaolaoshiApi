using IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Security
{
    public class ClaimsAccessor : IClaimsAccessor
    {
        protected IPrincipalAccessor PrincipalAccessor { get; set; }

        public ClaimsAccessor(IPrincipalAccessor principalAccessor)
        {
            PrincipalAccessor = principalAccessor;
        }
        /// <summary>
        /// 登录用户ID
        /// </summary>
        public int Id
        {
            get
            {
                var userId = PrincipalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == JwtClaimTypes.Id)?.Value;
                if (userId != null)
                {
                    int id = 0;
                    int.TryParse(userId, out id);
                    return id;
                }
                return 0;
            }
        }
        public string Name
        {
            get
            {
                var roleIds = PrincipalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == JwtClaimTypes.Name)?.Value;
                if (string.IsNullOrWhiteSpace(roleIds))
                {
                    return string.Empty;
                }

                return roleIds;
            }
        }
        /// <summary>
        /// 用户角色
        /// </summary>
        public string Role
        {
            get
            {
                var roleIds = PrincipalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == JwtClaimTypes.Role)?.Value;
                if (string.IsNullOrWhiteSpace(roleIds))
                {
                    return string.Empty;
                }

                return roleIds;
            }
        }
        public string Project
        {
            get
            {
                var roleIds = PrincipalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == "Project")?.Value;
                if (string.IsNullOrWhiteSpace(roleIds))
                {
                    return string.Empty;
                }

                return roleIds;
            }
        }
    }

    public interface IClaimsAccessor
    {
        /// <summary>
        /// 登录用户ID
        /// </summary>
        int Id { get; }
        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 用户角色
        /// </summary>
        string Role { get; }
        /// <summary>
        /// 其他身份
        /// </summary>
        string Project { get; }
    }
}
