using Cysharp.Threading.Tasks;
using MiningFarm.Core.Base;
using MiningFarm.Enums;
using MiningFarm.WindowService;

namespace MiningFarm.Login
{
    [Window(WindowType.Login)]
    public class LoginBridgeService : BridgeServiceBase<LoginLogicService, LoginUIService, LoginModuleConfig>, IModuleInitializeAsync
    {
        private const float LOADING_DURATION = 3f;

        protected override bool IsAutoInitialize => true;

        public override async UniTask InitializeAsync()
        {
            await base.InitializeAsync();

            UIService.RunLoading(LOADING_DURATION).Forget();
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
            Logger.Log($"Successfully logged in. Login type {loginType}", GetTag());
            // go to the next scene
        }
    }
}