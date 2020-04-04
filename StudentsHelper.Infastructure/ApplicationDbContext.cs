using Microsoft.EntityFrameworkCore;
using StudentsHelper.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Identity;

namespace StudentsHelper.Infastructure
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<MaterialTeacher> MaterialTeachers { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.HasDefaultSchema("auth");
            //put db configuration here
            base.OnModelCreating(builder);
        }

        
    }
    //public class ApplicationDbContext: IdentityDbContext<User>
    //{
    //    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    //        : base(options)
    //    {
    //    }

    //    protected override void OnModelCreating(ModelBuilder builder)
    //    {
    //        base.OnModelCreating(builder);
    //        // Customize the ASP.NET Identity model and override the defaults if needed.
    //        // For example, you can rename the ASP.NET Identity table names and more.
    //        // Add your customizations after calling base.OnModelCreating(builder);
    //    }
    //    public DbSet<Teacher> Teachers { get; set; }
    //    public DbSet<Review> Reviews { get; set; }
    //    public DbSet<Material> Materials { get; set; }
    //}
}
