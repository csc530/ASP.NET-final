using ASPFinal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace careerPortals.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
    //decrlare a DBset object to easily perform CRUD operations

    public DbSet<Account> Accounts { get; set; }
    public DbSet<JobPost> JobPosts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
