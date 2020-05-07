using Xunit;
using System.Linq;
using CrawlerIntegrationTesting.Clues;
using Xunit.Abstractions;

namespace Tests.Integration.MockSql
{
    public class DataIngestion : IClassFixture<MockSqlTestFixture>
    {
        private readonly MockSqlTestFixture _fixture;
        private readonly ITestOutputHelper _output;

        public DataIngestion(MockSqlTestFixture fixture, ITestOutputHelper output)
        {
            _fixture = fixture;
            _output = output;
            
        }

        [Theory]
        [InlineData("/Provider/Root", 1)]
        [InlineData("/Organization", 1000)]
        [InlineData("/Person", 7000)]
        public void CorrectNumberOfEntityTypes(string entityType, int expectedCount)
        {
            var foundCount = _fixture.ClueStorage.CountOfType(entityType);
            Assert.Equal(expectedCount, foundCount);
        }

        [Fact]
        public void EntityCodesAreUnique()
        {            
            var count = _fixture.ClueStorage.Clues.Count();
            var unique = _fixture.ClueStorage.Clues.Distinct(new ClueComparer()).Count();

            //You could use this method to output info of all clues
            Assert.Equal(unique, count);
        }

        private void PrintClues()
        {
            foreach(var clue in _fixture.ClueStorage.Clues)
            {
                _output.WriteLine(clue.OriginEntityCode.ToString());
            }
        }
    }
}
