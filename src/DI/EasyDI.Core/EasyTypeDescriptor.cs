using System;

namespace EasyDI.Core
{
    using TypeFactory = Func<IResolver, Object>;

    public class EasyTypeDescriptor
    {
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
            Type serviceType,
            Type implementationType) : this(serviceType)
        {
            ServiceType = serviceType;
            ImplementationType = implementationType;
        }

        public EasyTypeDescriptor(
            Type serviceType,
            TypeFactory factory) : this(serviceType)
        {
            ImplementationFactory = factory;
        }

        public EasyTypeDescriptor(
            Type serviceType,
            object instance) : this(serviceType)
        {
            ImplementationInstance = instance;
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
            TypeFactory factory) : this(lifetime, serviceType)
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

        public ServiceLifetime Lifetime { get; }

        public Type ServiceType { get; }

        public Type ImplementationType { get; }

        public TypeFactory ImplementationFactory { get; }

        public object ImplementationInstance { get; }

        public static EasyTypeDescriptor Create(Type serviceType, Type implementationType)
        {
            return new EasyTypeDescriptor(serviceType, implementationType);
        }

        public static EasyTypeDescriptor Create(Type serviceType, TypeFactory factory)
        {
            return new EasyTypeDescriptor(serviceType, factory);
        }

        public static EasyTypeDescriptor Create(Type serviceType, object instance)
        {
            return new EasyTypeDescriptor(serviceType, instance);
        }

        public static EasyTypeDescriptor Create(ServiceLifetime lifetime, Type serviceType, Type implementationType)
        {
            return new EasyTypeDescriptor(lifetime, serviceType, implementationType);
        }

        public static EasyTypeDescriptor Create(ServiceLifetime lifetime, Type serviceType, TypeFactory factory)
        {
            return new EasyTypeDescriptor(lifetime, serviceType, factory);
        }

        public static EasyTypeDescriptor Create(ServiceLifetime lifetime, Type serviceType, object instance)
        {
            return new EasyTypeDescriptor(lifetime, serviceType, instance);
        }
    }
}
