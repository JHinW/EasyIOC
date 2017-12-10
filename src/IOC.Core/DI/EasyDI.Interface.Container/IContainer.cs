
namespace EasyDI.Definition.Container
{
    using System;
    using System.Collections.Generic;

    using EasyDI.Definition.Common;

    public interface IContainer<TDisp, TDispItem, TCompiledItem>
    {
        void AddMapping(Type key, TDisp disp);

        TDispItem RemoveMapping(Type key);

        TDispItem GetMappingDisp(Type key);

        IProvider CreateProvider();

        ITracker<TDispItem, TCompiledItem> CreateTracker();
    }
}
