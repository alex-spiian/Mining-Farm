using System;
using Core.Logger;
using Cysharp.Threading.Tasks;
using MiningFarm.Login;
using MiningFarm.WindowService;
using Zenject;

namespace MiningFarm.BootstrapEntryPoint
{
    public class Bootstrap : Loggable, IInitializable, IDisposable
    {
        private WindowsLogicService _windowsService;
        private LoginBridgeService _loginService;

        [Inject]
        public void Construct(WindowsLogicService windowsLogicService, LoginBridgeService loginBridgeService)
        {
            _windowsService = windowsLogicService;
            _loginService = loginBridgeService;
        }
        
        public async void Initialize()
        {
            try
            {
                await _windowsService.InitializeAsync();
                await _loginService.InitializeAsync();
            }
            catch (Exception e)
            {
                var exception = new Exception("Can't initialize bootstrap", e);
                Logger.LogException(exception, Tag);
            }
        }

        public void Dispose()
        {
            _windowsService.CloseAsync().Forget();
        }
    }
}