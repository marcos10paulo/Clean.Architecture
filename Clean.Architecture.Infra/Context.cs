using Clean.Architecture.Domain.Entities.InvoiceEntity;
using Clean.Architecture.Domain.Entities.InvoiceItemEntity;
using Clean.Architecture.Domain.Entities.UserEntity;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infra
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base (options)
        {
            DbContextOptionsBuilder<Context>
                dbContextOptionsBuilder = new ();
            dbContextOptionsBuilder.UseLazyLoadingProxies(false);
            dbContextOptionsBuilder.UseChangeTrackingProxies(false);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var navigation in entityType.GetNavigations())
                {
                    navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
                    navigation.SetIsEagerLoaded(false);
                }
            }

            //modelBuilder.Entity<UserCoreModel>().HasData(
            //    new UserCoreModel
            //    {
            //        Id = 1,
            //        Login = "admin",
            //        Password = new PasswordModel() { Value = "!7<:\u0012c`a" },
            //        Admin = true,
            //        Master = true,
            //        Blocked = false,
            //        TempBlocked = false,
            //        ChangedAt = DateTime.Now,
            //        LoginChange = true,
            //        NeverExpires = true,
            //        ExpiresIn = 1000
            //    });
        }
    }
}
