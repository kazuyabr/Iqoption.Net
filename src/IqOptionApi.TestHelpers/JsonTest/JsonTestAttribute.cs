using System;

namespace IqOptionApi.TestHelpers.JsonTest {
    public class JsonTestAttribute : Attribute {
        public JsonTestAttribute(string fileName) {
            FileName = fileName;
        }

        public string FileName { get; }
    }
}