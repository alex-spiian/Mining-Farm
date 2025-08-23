using System;
using MiningFarm.Enums;

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