using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string> GetClaimsByClaimType(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            return claimsPrincipal.FindAll(claimType).Select(cp=>cp.Value).ToList();
        }

        public static List<string> GetClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimsByClaimType(ClaimTypes.Role);
        }
    }
}
