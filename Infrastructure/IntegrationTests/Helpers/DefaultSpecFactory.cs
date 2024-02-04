using System.Text.Json;

namespace IntegrationTests.Helpers
{
	public static class DefaultSpecFactory
	{
		public static SpecificationSet Create()
		{
			string fileName = "DefaultSpecificationSet.json";
			string jsonString = File.ReadAllText(fileName);
			return JsonSerializer.Deserialize<SpecificationSet>(jsonString);
		}
	}
}
