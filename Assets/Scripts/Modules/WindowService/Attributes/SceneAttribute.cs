using System;
using MiningFarm.Enums;

namespace MiningFarm.WindowService
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class SceneAttribute : BaseWindowAttribute
    {
        public SceneAttribute(WindowType type) : base(type)
        {
        }
    }
}