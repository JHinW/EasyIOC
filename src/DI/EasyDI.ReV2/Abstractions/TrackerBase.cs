using EasyDI.Core;
using EasyDI.ReV2.Definitions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using static EasyDI.Core.Delegates;

namespace EasyDI.ReV2.Abstractions
{
    public abstract class TrackerBase : ITracker
    {
        private readonly BaseTypeToDescriptorItemDelegate _baseTypeToDescriptorItemDelegate;

        private readonly ResolveCheckDelegate _resolveCheckDelegate;

        private readonly ConcurrentDictionary<Type, IList<CompiledDescriptorDef>> _compliedContainer;

        protected TrackerBase(
            BaseTypeToDescriptorItemDelegate baseTypeToDescriptorItemDelegate,
            ResolveCheckDelegate resolveCheckDelegate
            )
        {
            _baseTypeToDescriptorItemDelegate = baseTypeToDescriptorItemDelegate;
            _resolveCheckDelegate = resolveCheckDelegate;

            _compliedContainer = new ConcurrentDictionary<Type, IList<CompiledDescriptorDef>>();
        }

        public bool CanBeResolved(Type baseType)
        {
            return _resolveCheckDelegate(baseType);
        }

        public EasyTypeDescriptorItem DescriptorResolve(Type baseType)
        {
            return _baseTypeToDescriptorItemDelegate(baseType);
        }

        public CompiledDescriptorDef Track<CompiledDescriptorDef>(Type type)
        {

            var items = _baseTypeToDescriptorItemDelegate(type);

            throw new NotImplementedException();
        }
    }
}
