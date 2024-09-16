using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OCR_DotNet_P5_ExpressVoitures.Models.Entities;

namespace OCR_DotNet_P5_ExpressVoitures.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Finish> Finishes { get; set; }
        public DbSet<BrandModel> BrandModels { get; set; }
        public DbSet<ModelFinish> ModelFinishes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BrandModel>()
                .HasNoKey();
            modelBuilder.Entity<ModelFinish>()
                .HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
    }
}
