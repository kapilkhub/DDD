using ContractBC.ContractAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastrcture.Data
{
	public class ContractContext : DbContext
	{
        public ContractContext(DbContextOptions options): base(options)
        {
           
        }

        public DbSet<Contract> Contracts => Set<Contract>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//mapping value objects 
			//value objects doesn't have key properties and therefore EFCore cannot map. 
			//however, these value objects entity mus be provided by the entity who is owning them
			
			modelBuilder.Entity<ContractVersion>().OwnsMany(v => v.Authors ).ToTable("ContractVersion_Authors").OwnsOne(v => v.Name);

			modelBuilder.Entity<Contract>().Property(c => c.ContractNumber).HasField("_contractNumber");
			modelBuilder.Entity<Contract>().Property(c => c.DateInitiated).HasField("_initiated");
			modelBuilder.Entity<ContractVersion>().Property("_hasRevisedSpecSet");
			modelBuilder.Entity<ContractVersion>().ToTable("ContractVersions");

			modelBuilder.Entity<ContractVersion>().ComplexProperty(v => v.Specs).Property(p => p.PriceForAddlAuthorCopiesUSD).HasColumnType("decimal(18,5)");
		}
	}
}
