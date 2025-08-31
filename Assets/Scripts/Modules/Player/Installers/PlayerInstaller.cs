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
            
            Container.BindInstance(_playerDataConfig).AsSingle();
        }
    }
}