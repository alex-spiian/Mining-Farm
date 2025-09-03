using System;
using Cysharp.Threading.Tasks;
using MiningFarm.Core.Base;
using MiningFarm.Enums;
using MiningFarm.Login;
using MiningFarm.Signals;
using MiningFarm.WindowService;
using Zenject;

namespace MiningFarm.BootstrapEntryPoint
{
    public class Bootstrap : LogicServiceBase, IInitializable
    {
        private WindowsLogicService _windowsService;
        private LoginBridgeService _loginService;

        [Inject]
        public void Construct(WindowsLogicService windowsLogicService, LoginBridgeService loginBridgeService)
        {
            _windowsService = windowsLogicService;
            _loginService = loginBridgeService;
        }
        
        public void Initialize()
        {
           InitializeAsync().Forget();
        }

        public override async UniTask InitializeAsync()
        {
            try
            {
                await _windowsService.InitializeAsync();
                await _loginService.InitializeAsync();
            }
            catch (Exception e)
            {
                var exception = new Exception("Failed while initializing bootstrap", e);
                Logger.LogException(exception, Tag);
            }
            
            await base.InitializeAsync();
        }

        protected override void Subscribe()
        {
            _loginService.LoginCompleted += OnLoginCompleted;
        }

        protected override void Unsubscribe()
        {
            _loginService.LoginCompleted -= OnLoginCompleted;
        }

        private async void OnLoginCompleted()
        {
            try
            {
                SignalBus.Fire(new OpenWindowSignal(WindowType.MiningFarmGame));
                
                _loginService.Dispose();
                await _loginService.CloseAsync();
            }
            catch (Exception e)
            {
                var exception = new Exception("Failed while closing LoginService ", e);
                Logger.LogException(exception, Tag);
            }
        }
    }
}