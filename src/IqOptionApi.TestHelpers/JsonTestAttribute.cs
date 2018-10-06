using System;

namespace IqOptionApi.TestHelpers {
    public class JsonTestAttribute : Attribute {
        public JsonTestAttribute(string fileName) {
            FileName = fileName;
        }

        public string FileName { get; }
    }
}