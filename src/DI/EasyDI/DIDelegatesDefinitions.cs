using EasyDI.Core;
using System;

namespace SF.Async.EasyDI
{
    public static class DIDelegatesDefinitions
    {

        public delegate ICompiler GetOrCreateDelegate(Type baseType, Func<ICompiler> factory);
    }
}
