

namespace EasyDI.Interface.Container
{
    using System;
    using System.Collections.Generic;

    using EasyDI.Interface.Common;

    public interface IContainer
    {
        void AddMapping<TDisp>(Type key, TDisp disp);

        void RemoveMapping(Type key);

        TDisp GetMappingDisp<TDisp>(Type key);

        TProvider CreateProvider<TProvider>() where TProvider : IProvider;

        Ttracker CreateTracker<Ttracker>() where Ttracker : ITracker;
    }
}
