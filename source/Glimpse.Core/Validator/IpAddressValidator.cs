﻿using System.Web;
using Glimpse.Core.Configuration;
using Glimpse.Core.Extensibility;

namespace Glimpse.Core.Validator
{
    [GlimpseValidator]
    internal class IpAddressValidator:IGlimpseValidator{
        public bool IsValid(HttpContextBase context, GlimpseConfiguration configuration, LifecycleEvent lifecycleEvent)
        {
            if (configuration.IpAddresses.Count == 0) return true; //no configured list, allow all IP's

            return configuration.IpAddresses.Contains(context.Request.UserHostAddress);
        }
    }
}