using System;
using Cysharp.Threading.Tasks;
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
            _windowsLogicService.InitializeAsync().Forget();
        }

        public void Dispose()
        {
            _windowsLogicService.CloseAsync().Forget();
        }
    }
}