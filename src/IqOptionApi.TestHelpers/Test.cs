using System;
using System.Reflection;
using AutofacContrib.NSubstitute;
using IqOptionApi.TestHelpers.JsonTest;

namespace IqOptionApi.TestHelpers
{
    public abstract class Test : IDisposable {

        protected AutoSubstitute AutoSubstitute { get; }

        public Test() {
            AutoSubstitute = new AutoSubstitute();
        }

        public void Dispose()
        {

        }

        protected T A<T>() {

            return AutoSubstitute.Resolve<T>();
        }
    }
}
