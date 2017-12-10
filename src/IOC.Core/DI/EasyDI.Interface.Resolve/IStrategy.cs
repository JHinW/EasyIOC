﻿
namespace EasyDI.Definition.Resolve
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IStrategy
    {
        Func<IResolve, IResolvable> ResolvableFactory { get; }
    }
}
