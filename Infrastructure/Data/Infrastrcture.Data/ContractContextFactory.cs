using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastrcture.Data
{
	public class ContractContextFactory : IDesignTimeDbContextFactory<ContractContext>
	{
		public ContractContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder();
			optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PubContractDataMigrationsTest;Trusted_Connection=True;MultipleActiveResultSets=true;");

			return new ContractContext(optionsBuilder.Options);
		}
	}
}
