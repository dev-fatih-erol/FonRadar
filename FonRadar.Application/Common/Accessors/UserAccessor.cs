﻿using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace FonRadar.Application.Common.Accessors
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _accessor;

        public UserAccessor(IHttpContextAccessor accessor)
        {
            _accessor = accessor ?? throw new ArgumentNullException(nameof(accessor));
        }

        public ClaimsPrincipal User => _accessor.HttpContext.User;

        public int UserId => Convert.ToInt32(_accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}

