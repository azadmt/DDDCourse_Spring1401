using System;
using System.Collections.Generic;

namespace Framework.Core
{
    public interface IContainer
    {
        T Resolve<T>();

        IEnumerable<T> ResolveAll<T>();

        IDisposable BeginScope();
    }

}
