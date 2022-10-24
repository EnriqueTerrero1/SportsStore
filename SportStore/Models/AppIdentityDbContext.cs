﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SportStore.Models
{
    public class AppIdentityDbContext: IdentityDbContext<IdentityUser>
    {
             public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) 
            : base(options) { }


       
      public  DbSet<IdentityUser> identityUsers { get; set; }

    }
}
