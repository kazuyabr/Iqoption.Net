using System;

namespace IqOptionApi.TestHelpers.JsonTest {
    public class JsonTestAttribute : Attribute {
        public string FileName { get; }

        public JsonTestAttribute(string fileName) {
            FileName = fileName;
        }
    }
}