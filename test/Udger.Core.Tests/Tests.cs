using Udger.Parser;
using Xunit;

namespace Udger.Core.Tests
{
    public class Tests
    {
        public Tests()
        {
        }

        [Fact]
        public void Init()
        {
            UdgerParser parser = new UdgerParser();
            parser.SetDataDir(@"C:\Users\nfreier\Downloads\reference");

            parser.ua = @"Mozilla/5.0 (compatible; SeznamBot/3.2; +http://fulltext.sblog.cz/)";
            parser.parse();
            var data = parser.userAgent;

            Assert.Equal("Search engine bot", data.CrawlerCategory);
            Assert.Equal("SeznamBot/3.2", data.Ua);
            Assert.Equal("3.2", data.UaVersion);
            Assert.Equal("3", data.UaVersionMajor);
        }
    }
}
