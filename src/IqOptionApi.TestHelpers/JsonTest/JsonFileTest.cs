using System;
using System.Linq;

namespace IqOptionApi.TestHelpers.JsonTest {
    public class JsonFileTest : IDisposable {

        public JsonFileTest() {

        }
        public string LoadJson(string fileName) {

            var JSON = System.IO.File.ReadAllText($"Json\\{fileName}");
            return JSON;
        }


        public void Dispose() {

        }
    }
}