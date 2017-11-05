using EasyDI.Core;
using EasyDI.Re.Definitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyDI.Re
{
    public static class ReDelgates
    {
        public delegate object InstanceUpFactory(IResolver tracker, ResolvableTypeDef def);
    }
}
