using EasyDI.Core;
using EasyDI.ReV2.Definitions;
using EasyDI.ReV2.Statics;
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
            var resolvableFactory = ResolvableHelper.CreateResolveFactory(baseType);
            var resolvable = resolvableFactory(this);
            return resolvable.IsResolvable();
        }

        public bool CanBeResolved(Type baseType, out IResolvable resolvable)
        {
            var resolvableFactory = ResolvableHelper.CreateResolveFactory(baseType);
            resolvable = resolvableFactory(this);
            return resolvable.IsResolvable();
        }

        public EasyTypeDescriptorItem DescriptorResolve(Type baseType)
        {
            return _baseTypeToDescriptorItemDelegate(baseType);
        }

        public bool IsIndexed(Type baseType)
        {
            return _resolveCheckDelegate(baseType);
        }

        public CompiledDescriptorDef Track<CompiledDescriptorDef>(Type type)
        {

            if(!CanBeResolved(type, out var resolvable))
            {
                throw new InvalidOperationException($"The Type {nameof(type)} cannot be resolved!");
            }
            // resolvable

            // var items = _baseTypeToDescriptorItemDelegate(type);

            throw new NotImplementedException();
        }


         
    }
}
