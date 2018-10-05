using System.Reflection;
using Newtonsoft.Json;
using NUnit.Framework;

namespace IqOptionApi.TestHelpers.JsonTest {
    public abstract class JsonTestSuiteFor<T> : Test {

        private string Json { get; set; }
        protected T Suite { get; private set; }

        [SetUp]
        public void Setup() {
            if (this.GetType()
                .GetCustomAttribute(typeof(JsonTestAttribute)) is JsonTestAttribute attr) {

                Json = System.IO.File.ReadAllText($"~/Json/{attr.FileName}");
            }

        }

        protected T TryToParseJson() {
            Shouldly.Should.NotThrow(() => Suite = JsonConvert.DeserializeObject<T>(Json));
            return Suite;
        }

    }
}