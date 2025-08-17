using System;
using MiningFarm.Common.Enums;

namespace MiningFarm.WindowService
{
    public abstract class BaseWindowAttribute : Attribute
    {
        public readonly WindowType Type;

        protected BaseWindowAttribute(WindowType type)
        {
            Type = type;
        }
    }
}