using System;
using MiningFarm.Core;
using MiningFarm.Core.Base;
using Zenject;

namespace MiningFarm.Player
{
    public class PlayerDataService : LogicServiceBase
    {
        private const string PLAYER_DATA_KEY = "PlayerDataKey";
        
        public PlayerData PlayerData { get; private set; }

        private SaveDataService _saveDataService;
        private PlayerDataConfig _initialPlayerDataConfig;

        [Inject]
        public void Construct(SaveDataService saveDataService, PlayerDataConfig initialPlayerDataConfig)
        {
            _initialPlayerDataConfig = initialPlayerDataConfig;
            _saveDataService = saveDataService;
        }
        
        public bool TryLoadPlayerData()
        {
            if (_saveDataService.Load<PlayerData>(PLAYER_DATA_KEY, out var playerData))
            {
                PlayerData = playerData;
                return true;
            }
            
            return false;
        }

        public void CreateNewPlayer()
        {
            var playerData = new PlayerData
            {
                Guid = Guid.NewGuid(),
                Wallet = _initialPlayerDataConfig.PlayerData.Wallet,
                OwnedMiningMachines = _initialPlayerDataConfig.PlayerData.OwnedMiningMachines,
            };
            
            _saveDataService.Save(PLAYER_DATA_KEY, playerData);
            PlayerData = playerData;
        }
    }
}