using System;

namespace IqOptionApi.TestHelpers {
    public abstract class TestFor<TSuite> : Test {
        private Lazy<TSuite> _lazySuite;
        protected TSuite Suite => _lazySuite.Value;

        public TestFor() {
            _lazySuite = new Lazy<TSuite>(CreateSuite);
        }

        protected virtual TSuite CreateSuite() {
            return AutoSubstitute.Resolve<TSuite>();
        }
    }
}