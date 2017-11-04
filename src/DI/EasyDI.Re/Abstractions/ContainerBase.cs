using EasyDI.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace EasyDI.Re.Abstractions
{
    public abstract class ContainerBase: IContainer
    {
        private readonly ConcurrentDictionary<Type, EasyTypeDescriptorItem> _container;

        protected ContainerBase()
        {
            _container = new ConcurrentDictionary<Type, EasyTypeDescriptorItem>();
        }

        protected ContainerBase(IEnumerable<EasyTypeDescriptor> descriptors)
        {
            _container = new ConcurrentDictionary<Type, EasyTypeDescriptorItem>();
            foreach (var descriptor in descriptors)
            {
                this.AddDescriptor(descriptor.ServiceType, descriptor);
            }
        }

        public void AddDescriptor(Type key, EasyTypeDescriptor descriptor)
        {

            var item = new EasyTypeDescriptorItem();
            _container.AddOrUpdate(key, item.Add(descriptor), (_key, oldValue) => {
                return oldValue.Add(descriptor);
            });
        }

        public EasyTypeDescriptorItem this[Type index]
        {
            get
            {
                return _container[index];
            }
        }

        public EasyTypeDescriptorItem RemoveInstance(Type key)
        {
            _container.TryRemove(key, out EasyTypeDescriptorItem value);
            return value;
        }

        protected bool IsHasKey(Type key)
        {
            return _container.ContainsKey(key);
        }

        public abstract IResolver CreateTypeResolver();

        public abstract ITracker CreateTracker();

        public void Sync()
        {
            throw new NotImplementedException();
        }
    }
}
