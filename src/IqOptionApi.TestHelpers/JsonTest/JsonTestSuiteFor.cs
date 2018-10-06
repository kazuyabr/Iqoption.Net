using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;

namespace IqOptionApi.TestHelpers.JsonTest {
    public abstract class JsonTestSuiteFor<T> : TestFor<T> {

        private IDictionary<string, string> JsonPathList;

        private string Json { get; set; }

        [SetUp]
        public void Setup() {
            JsonPathList = new Dictionary<string, string>();

            if (GetType()
                .GetCustomAttribute(typeof(JsonTestAttribute)) is JsonTestAttribute attr) {
                var path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Json");

                foreach (var f in Directory.GetFiles(path, "*.json", SearchOption.AllDirectories)
                    .Select(x => new {fileName = Path.GetFileNameWithoutExtension(x), Path = x}))
                    JsonPathList.Add(f.fileName, f.Path);

                Json = File.ReadAllText(JsonPathList[attr.FileName]);
            }
        }

        protected override T CreateSuite() {
            return JsonConvert.DeserializeObject<T>(Json);
        }

      
    }
}