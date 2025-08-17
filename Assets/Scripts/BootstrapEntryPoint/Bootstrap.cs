using System;
using MiningFarm.WindowService;
using Zenject;

namespace MiningFarm.BootstrapEntryPoint
{
    public class Bootstrap : IInitializable, IDisposable
    {
        private WindowsLogicService _windowsLogicService;

        [Inject]
        public void Construct(WindowsLogicService windowsLogicService)
        {
            _windowsLogicService = windowsLogicService;
        }
        
        public void Initialize()
        {
            _windowsLogicService.Initialize();
        }

        public void Dispose()
        {
            _windowsLogicService.Dispose();
        }
    }
}