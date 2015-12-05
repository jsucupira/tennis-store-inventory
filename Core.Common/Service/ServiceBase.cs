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
    public abstract class ServiceBase
    {
        protected static T ExecuteFaultHandledOperation<T>(Func<T> codeToExecute)
        {
            return codeToExecute.Invoke();
        }

        protected static void ExecuteFaultHandledOperation(Action codeToExecute)
        {
            codeToExecute.Invoke();
        }

        protected static string GetUserName()
        {
            string userName = "Unknown";
            ClaimsPrincipal user = Thread.CurrentPrincipal as ClaimsPrincipal;
            if (user != null && user.HasClaim(t => t.Type.Equals("preferred_username")))
                userName = user.FindFirst("preferred_username").Value;

            return userName;
        }

        protected static bool IsUserAdmin()
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