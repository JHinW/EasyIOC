using System;
using System.Collections.Generic;
using System.Text;

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

        public virtual void SetDep(IResolvable resolvable)
        {
            _depResolvables = _depResolvables ?? new List<IResolvable>();
            _depResolvables.Add(resolvable);
        }

        public void AsEnd()
        {
            _isEnd = true;
        }

        public void NotAsEnd()
        {
            _isEnd = false;
        }
    }
}
