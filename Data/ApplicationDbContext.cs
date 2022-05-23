using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace testing.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser,IdentityRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
