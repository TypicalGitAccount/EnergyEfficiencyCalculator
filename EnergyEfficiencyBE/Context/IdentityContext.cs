﻿using EnergyEfficiencyBE.Models.Entities.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EnergyEfficiencyBE.Context
{
    public class IdentityContext : IdentityDbContext<AuthUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }
    }
}
