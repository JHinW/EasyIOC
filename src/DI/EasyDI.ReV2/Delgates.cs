using EasyDI.Core;
using EasyDI.ReV2.Core;

namespace EasyDI.ReV2
{
    public static class Delgates
    {
         public delegate object InstanceScopeFactory(
             IResolver resolver,
             IScope scope);

        public delegate InstanceScopeFactory InstanceTrackScopeFactory(
             ITracker tracker);

        public delegate InstanceTrackScopeFactory ResolvableFactory(
             IResolvableType resolvableType);
    }
}
