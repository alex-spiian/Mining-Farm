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
        public WalletService WalletService { get; private set; }

        private SaveDataService _saveDataService;
        private PlayerDataConfig _initialPlayerDataConfig;

        [Inject]
        public void Construct(SaveDataService saveDataService, WalletService walletService, PlayerDataConfig initialPlayerDataConfig)
        {
            _initialPlayerDataConfig = initialPlayerDataConfig;
            _saveDataService = saveDataService;
            WalletService = walletService;
        }
        
        public bool TryLoadPlayerData()
        {
            if (_saveDataService.Load<PlayerData>(PLAYER_DATA_KEY, out var playerData))
            {
                PlayerData = playerData;
                InitializeWallet();
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
            InitializeWallet();
        }

        private void InitializeWallet()
        {
            WalletService.Initialize(PlayerData.Wallet);
        }
    }
}