using EasyDI.Core;
using EasyDI.Re.Extensions;
using System;
using System.Collections.Generic;
using static EasyDI.Core.Delegates;

namespace EasyDI.Re.Abstractions
{
    public abstract class ResolverBase : IResolver
    {
        private BaseTypeToDescriptorItemDelegate _baseTypeToDescriptorItemDelegate;

        private ResolveCheckDelegate _resolveCheckDelegate;

        private HashSet<Type> _resolvingTypeSet;


        protected ResolverBase(
            BaseTypeToDescriptorItemDelegate baseTypeToDescriptorItemDelegate,
            ResolveCheckDelegate resolveCheckDelegate
            )
        {
            _baseTypeToDescriptorItemDelegate = baseTypeToDescriptorItemDelegate;
            _resolveCheckDelegate = resolveCheckDelegate;
            _resolvingTypeSet = new HashSet<Type>();
        }

        public virtual object GetInstance(Type baseType)
        {
            var factory = baseType
                .AsResolvableType(this)
                .AsInstanceFactory();
            // var factory = TypeHelper.BaseType2InstanceFactory(baseType, this);
            return factory(this);
        }

        public bool CanBeResolved(Type baseType)
        {
            return _resolveCheckDelegate(baseType);
        }

        public EasyTypeDescriptorItem DecriptorResolve(Type baseType)
        {
            //if (CanBeResolve(baseType)) throw new InvalidOperationException("Error: Can not be resolved!");

            return _baseTypeToDescriptorItemDelegate(baseType);
        }

        public abstract void ResolvingTypes(HashSet<Type> resolvingTypeSet);

        public virtual bool IsResolving(Type baseType)
        {
            return _resolvingTypeSet.Contains(baseType);
        }

        public virtual void AddToScopeSet(Type baseType)
        {
            _resolvingTypeSet.Add(baseType);
        }
    }
}
