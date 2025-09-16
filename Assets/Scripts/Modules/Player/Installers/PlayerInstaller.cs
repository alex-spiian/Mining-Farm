using UnityEngine;
using Zenject;

namespace MiningFarm.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] protected PlayerDataConfig _playerDataConfig;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerDataService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WalletService>().AsSingle();
            
            Container.BindInstance(_playerDataConfig).AsSingle();
        }
    }
}