using MiningFarm.Core.Base;
using MiningFarm.Enums;
using MiningFarm.Player;
using Zenject;

namespace MiningFarm.Login
{
    public class LoginLogicService : LogicServiceBase
    {
        private PlayerDataService _playerDataService;
        
        public event System.Action<LoginType> OnLoginCompleted;

        [Inject]
        public void Construct(PlayerDataService playerDataService)
        {
            _playerDataService = playerDataService;
        }
        
        public void Login()
        {
            if (_playerDataService.TryLoadPlayerData())
            {
                OnLoginCompleted?.Invoke(LoginType.SignIn);
                return;
            }
            
            _playerDataService.CreateNewPlayer();
            OnLoginCompleted?.Invoke(LoginType.SignUp);
        }
    }
}