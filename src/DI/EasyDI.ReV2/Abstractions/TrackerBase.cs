using EasyDI.Core;
using System;
using System.Collections.Generic;
using System.Text;
using static EasyDI.Core.Delegates;

namespace EasyDI.ReV2.Abstractions
{
    public abstract class TrackerBase : ITracker
    {
        private readonly BaseTypeToDescriptorItemDelegate _baseTypeToDescriptorItemDelegate;

        private readonly ResolveCheckDelegate _resolveCheckDelegate;

        protected TrackerBase(
            BaseTypeToDescriptorItemDelegate baseTypeToDescriptorItemDelegate,
            ResolveCheckDelegate resolveCheckDelegate
            )
        {
            _baseTypeToDescriptorItemDelegate = baseTypeToDescriptorItemDelegate;
            _resolveCheckDelegate = resolveCheckDelegate;
        }

        public bool CanBeResolved(Type baseType)
        {
            return _resolveCheckDelegate(baseType);
        }

        public EasyTypeDescriptorItem DescriptorResolve(Type baseType)
        {
            return _baseTypeToDescriptorItemDelegate(baseType);
        }

        public object Track(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
