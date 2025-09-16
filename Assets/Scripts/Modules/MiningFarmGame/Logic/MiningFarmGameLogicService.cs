using System;
using MiningFarm.Core.Base;
using MiningFarm.Enums;
using MiningFarm.Player;
using Zenject;

namespace MiningFarm.Game
{
    public class MiningFarmGameLogicService : LogicServiceBase
    {
        private MiningFieldBase _gameField;
        private PlayerDataService _playerDataService;
        
        [Inject]
        public void Construct(PlayerDataService playerDataService)
        {
            _playerDataService = playerDataService;
        }

        public void Generate(MiningFarmGameModuleConfig moduleConfig)
        {
            var gameFieldPrefab = moduleConfig.MiningFieldContainer.GetField(MiningFieldType.Default);
            _gameField = DiContainer.InstantiatePrefab(gameFieldPrefab).GetComponent<MiningFieldBase>();
            _gameField.Initialize();
            
            SetMiningMachines(moduleConfig.MiningMachineContainer);
        }

        private void SetMiningMachines(MiningMachineContainer moduleConfigMiningMachineContainer)
        {
            var playerMachines = _playerDataService.PlayerData.OwnedMiningMachines;
            for (var i = 0; i < playerMachines.Length; i++)
            {
                if (Enum.TryParse(playerMachines[i], out MiningMachineType machineTypeValue))
                {
                    var machineConfig = moduleConfigMiningMachineContainer.GetConfig(machineTypeValue);
                    var machine = _gameField.SetSlot(machineConfig.Prefab);
                    machine.Initialize(machineConfig);
                    continue;
                }
                Logger.LogError($"Unknown MiningMachineType: {playerMachines[i]}", Tag);
            }
        }
    }
}