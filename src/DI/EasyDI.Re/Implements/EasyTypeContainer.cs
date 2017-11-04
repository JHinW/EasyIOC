using EasyDI.Core;
using EasyDI.Re.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyDI.Re.Implements
{
    public class EasyTypeContainer: ContainerBase
    {
        public EasyTypeContainer()
        {
        }

        public override ITracker CreateTracker()
        {
            return null;
        }

        public override IResolver CreateTypeResolver()
        {
            return null;
        }
    }
}
