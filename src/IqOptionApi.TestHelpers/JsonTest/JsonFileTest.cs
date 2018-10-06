using System;
using System.IO;

namespace IqOptionApi.TestHelpers.JsonTest {
    public class JsonFileTest : IDisposable {
        public void Dispose() {
        }

        public string LoadJson(string fileName) {
            var JSON = File.ReadAllText($"Json\\{fileName}");
            return JSON;
        }
    }
}