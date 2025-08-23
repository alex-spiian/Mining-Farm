using System;
using MiningFarm.Enums;

namespace MiningFarm.WindowService
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class WindowAttribute : BaseWindowAttribute
    {
        public WindowAttribute(WindowType type) : base(type)
        {
        }
    }
}