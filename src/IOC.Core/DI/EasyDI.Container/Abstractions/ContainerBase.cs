
namespace EasyDI.Container.Abstractions
{
    using System;
    using System.Collections.Concurrent;

    using EasyDI.Definition.Container;
    using EasyDI.Definition.Common;

    public abstract class ContainerBase: 
        IContainer<EasyTypeDescriptor, EasyTypeDescriptorItem, EasyTypeDescriptorItemCompiled>
    {
        private readonly ConcurrentDictionary<Type, EasyTypeDescriptorItem> _container;

        protected ContainerBase()
        {
            _container = new ConcurrentDictionary<Type, EasyTypeDescriptorItem>();
        }

        public void AddMapping(Type key, EasyTypeDescriptor disp)
        {
            var item = new EasyTypeDescriptorItem();
            _container.AddOrUpdate(key, item.Add(disp), (_key, oldValue) => {
                return oldValue.Add(disp);
            });
        }

        public abstract IProvider CreateProvider();

        public abstract ITracker<EasyTypeDescriptorItem, EasyTypeDescriptorItemCompiled> CreateTracker();

        public EasyTypeDescriptorItem GetMappingDisp(Type key)
        {
            return _container[key];
        }

        public EasyTypeDescriptorItem RemoveMapping(Type key)
        {
            _container.TryRemove(key, out EasyTypeDescriptorItem value);
            return value;
        }
    }
}
