
using System;
using System.Collections.Generic;

using EasyDI.Core;

namespace EasyDI.ReV2.Abstractions
{
    public abstract class ResolvableBase : IResolvable
    {
        public Type Type { get; }

        public IList<IResolvable> DepResolvables => _depResolvables;

        public bool IsEnd => _isEnd;

        protected IList<IResolvable> _depResolvables;

        protected bool _isEnd = false;

       protected ResolvableBase(Type type)
        {
            Type = type;
            _depResolvables = null;
        }

        public virtual IResolvable SetDep(IResolvable resolvable)
        {
            _depResolvables = _depResolvables ?? new List<IResolvable>();
            _depResolvables.Add(resolvable);
            return this;
        }

        public IResolvable AsEnd()
        {
            _isEnd = true;
            return this;
        }

        public IResolvable NotAsEnd()
        {
            _isEnd = false;
            return this;
        }

        public bool IsResolvable()
        {
            foreach(var item in this.Flattern())
            {
                if (item.IsEnd) return true;
            }

            return false;
        }

        public IEnumerable<IResolvable> Flattern()
        {
            yield return this;
            if(_depResolvables != null)
            {
                foreach (var resolve in _depResolvables)
                {
                    foreach (var item in resolve.Flattern())
                    {
                        yield return item;
                    }
                }
            }
            
        }
    }
}
