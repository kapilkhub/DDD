using ContractBC.ContractAggregate;
using ContractBC.ValueObjects;
using Infrastrcture.Data;
using IntegrationTests.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IntegrationTests
{
	public class ContractTests
	{
		Contract contract = new Contract(DateOnly.FromDateTime(DateTime.Today),
			new List<Author> { Author.UnsignedAuthor("kapil", "khubchandani", "kk.jecrc@gmail.com", "phone") }, "bookTitle"
			);

		ContractContext _context;
		public ContractTests()
		{
			var optionsBuilder = new DbContextOptionsBuilder<ContractContext>();
			optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PubContractDataIntegrationTest;Trusted_Connection=True;MultipleActiveResultSets=true;");
			optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging();

			_context = new ContractContext(optionsBuilder.Options);
			_context.Database.EnsureDeleted();
			_context.Database.EnsureCreated();
		}
		[Fact]
		public void NewContractStoresCorrectId()
		{
			var assignedId = contract.Id;
			_context.Contracts.Add(contract);
			_context.SaveChanges();
			_context.ChangeTracker.Clear();
			var insertedContract = _context.Contracts.FirstOrDefault();
			Assert.Equal(assignedId, insertedContract?.Id);


		}

		[Fact]
		public void NewContractHasVersionWithSpecDefaults()
		{
			_context.Contracts.Add(contract);
			_context.SaveChanges();
			_context.ChangeTracker.Clear();

			var contractFromDB = _context.Contracts.Include(c => c.Versions).FirstOrDefault();
			Assert.Equal(DefaultSpecFactory.Create(), contractFromDB!.Versions.First().Specs);
		}

		[Fact]
		public void NewContractHasDateInitiatedWhenQueried()
		{
			var calculatedDateInitiated = contract.DateInitiated;
			_context.Contracts.Add(contract);
			_context.SaveChanges();
			_context.ChangeTracker.Clear();

			var contractFromDB = _context.Contracts.FirstOrDefault();
			Assert.Equal(calculatedDateInitiated, contractFromDB!.DateInitiated);

		}

		[Fact]
		public void NewContractHasContractInitiatedWhenQueried()
		{
			var calculatedContractNumber = contract.ContractNumber;
			_context.Contracts.Add(contract);
			_context.SaveChanges();
			_context.ChangeTracker.Clear();

			var contractFromDB = _context.Contracts.FirstOrDefault();
			Assert.Equal(calculatedContractNumber, contractFromDB!.ContractNumber);

		}

		[Fact]
		public void SqlQuery_HasRevisedSpecSetIsFalseForNewContractWithNewVersion()
		{
			_context.Contracts.Add(contract);
			_context.SaveChanges();
			_context.ChangeTracker.Clear();

			var value =_context.Database.SqlQuery<bool>($"SELECT [_hasRevisedSpecSet] as [Value] FROM [ContractVersions]")
				.FirstOrDefault();

			Assert.False(value);
		}
	}
}