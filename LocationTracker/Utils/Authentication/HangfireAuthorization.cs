﻿using System;
using Hangfire.Dashboard;
using Microsoft.AspNetCore.Http;

namespace LocationTracker.Utils.Authentication
{
    public class HangfireAuthorization : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            var httpContext = context.GetHttpContext();
            return httpContext.User.Identity.IsAuthenticated;
        }
    }
}
