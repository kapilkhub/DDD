1. add nuget packages
     A. M.EFCore.Tools
     B. M.EFCore.SqlServer
2. add two classes 
	A. ContractContext --> inherit from DbContext
    B. ContractContextFactory -- inherit for IDesignTimeDbContextFactory

3. dotnet tool update --global dotnet-ef
4. dotnet ef dbcontext info 
5. Add private parameter less construtor to make EF core happy in all entity class.

6.mapping value objects 
value objects doesn't have key properties and therefore EFCore cannot map. 
however, these value objects entity mus be provided by the entity who is owning them.

<code>
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<ContractVersion>().ComplexProperty(v => v.Specs);
    modelBuilder.Entity<ContractVersion>().OwnsMany(v => v.Authors).OwnsOne(v => v.Name);
}
</code>

7. this time dbContext is identified.
     