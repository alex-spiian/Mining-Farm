using System;
using Cysharp.Threading.Tasks;
using MiningFarm.Core.Base;
using MiningFarm.Enums;
using MiningFarm.WindowService;

namespace MiningFarm.Login
{
    [Scene(WindowType.Login)]
    public class LoginBridgeService : BridgeServiceBase<LoginLogicService, LoginUIService, LoginModuleConfig>, IModuleInitializeAsync
    {
        public event Action LoginCompleted;
        public override async UniTask InitializeAsync()
        {
            await base.InitializeAsync();

            UIService.RunLoading(ModuleConfig.FakeLoadingDuration).Forget();
            LogicService.Login();
        }
        
        protected override void Subscribe()
        {
            LogicService.OnLoginCompleted += OnLoginCompleted;
        }

        protected override void Unsubscribe()
        {
            LogicService.OnLoginCompleted -= OnLoginCompleted;
        }

        private void OnLoginCompleted(LoginType loginType)
        {
            Logger.Log($"Successfully logged in. Login type {loginType}", Tag);
            HandleLoginComplete().Forget();
        }

        private async UniTask HandleLoginComplete()
        {
            await UniTask.WaitUntil(() => UIService.IsLoaderFinished);
            LoginCompleted?.Invoke();
        }
    }
}