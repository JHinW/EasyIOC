using System;
using System.Collections.Generic;
using System.Text;

namespace EasyDI.ReV2
{
    public interface IResolvable
    {
        Type Type { get; }

        IList<IResolvable> DepResolvables { get; }

        Boolean IsEnd { get; }

        IResolvable SetDep(IResolvable resolvable);

        IResolvable AsEnd();

        IResolvable NotAsEnd();

        Boolean IsResolvable();


        IEnumerable<IResolvable> Flattern();
    }
}
