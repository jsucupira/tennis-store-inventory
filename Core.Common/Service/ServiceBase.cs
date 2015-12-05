using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using Core.Common.Model;
using Core.Common.Security;

namespace Core.Common.Service
{
    public class ServiceBase
    {
        public static T ExecuteFaultHandledOperation<T>(Func<T> codeToExecute)
        {
            return codeToExecute.Invoke();
        }

        public static void ExecuteFaultHandledOperation(Action codeToExecute)
        {
            codeToExecute.Invoke();
        }

        public static string GetUserName()
        {
            string userName = "Unknown";
            ClaimsPrincipal user = Thread.CurrentPrincipal as ClaimsPrincipal;
            if (user != null)
            {
                if (user.HasClaim(t => t.Type.Equals("preferred_username")))
                    userName = user.FindFirst("preferred_username").Value;
                else if (user.Identity != null)
                    userName = user.Identity.Name;
            }
            return userName;
        }

        public static bool IsUserAdmin()
        {
            ClaimsPrincipal user = Thread.CurrentPrincipal as ClaimsPrincipal;
            if (user != null && user.HasClaim(t => t.Type.Equals("roles")))
            {
                List<Claim> roles = user.FindAll(t => t.Type == "roles").ToList();
                return roles.Any(t => t.Value.Equals(SecurityGroups.ADMINISTRATOR));
            }

            return false;
        }

    }
}