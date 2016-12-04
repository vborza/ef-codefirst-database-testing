using Xunit;

namespace Dal.Tests.Setup
{
    [CollectionDefinition("UseDb")]
    public class TestDbCollection : ICollectionFixture<TestDbFixture>
    {
    }
}
