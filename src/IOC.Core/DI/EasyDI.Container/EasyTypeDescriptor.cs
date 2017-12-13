

namespace EasyDI.Container
{    
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EasyDI.Definition.Common;

    public class EasyTypeDescriptor
    {
        public ServiceLifetime Lifetime { get; }

        public Type ServiceType { get; }

        public Type ImplementationType { get; }

        public ObjectDelegate ImplementationFactory { get; }

        public object ImplementationInstance { get; }

        private EasyTypeDescriptor(Type serviceType)
        {
            ServiceType = serviceType;
        }

        private EasyTypeDescriptor(
            ServiceLifetime lifetime,
            Type serviceType)
        {
            Lifetime = lifetime;
            ServiceType = serviceType;
        }

        public EasyTypeDescriptor(
            ServiceLifetime lifetime,
            Type serviceType,
            Type implementationType) : this(lifetime, serviceType)
        {
            ServiceType = serviceType;
            ImplementationType = implementationType;
        }

        public EasyTypeDescriptor(
            ServiceLifetime lifetime,
            Type serviceType,
            ObjectDelegate factory) : this(lifetime, serviceType)
        {
            ImplementationFactory = factory;
        }

        public EasyTypeDescriptor(
            ServiceLifetime lifetime,
            Type serviceType,
            object instance) : this(lifetime, serviceType)
        {
            ImplementationInstance = instance;
        }

        public static EasyTypeDescriptor Create(ServiceLifetime lifetime, Type serviceType, Type implementationType)
        {
            return new EasyTypeDescriptor(lifetime, serviceType, implementationType);
        }

        public static EasyTypeDescriptor Create(ServiceLifetime lifetime, Type serviceType, ObjectDelegate factory)
        {
            return new EasyTypeDescriptor(lifetime, serviceType, factory);
        }

        public static EasyTypeDescriptor Create(ServiceLifetime lifetime, Type serviceType, object instance)
        {
            return new EasyTypeDescriptor(lifetime, serviceType, instance);
        }
    }
}
