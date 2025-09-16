using System;
using MiningFarm.Enums;
using UnityEngine;

namespace MiningFarm.Game
{
    public abstract class MiningMachineBase : MonoBehaviour
    {
        public event Action<float, CurrencyType> OnMined;

        protected MiningMachineConfig Config;

        private float _timer;
        private float _miningTime;
        private float _miningAmount;

        public void Initialize(MiningMachineConfig config)
        {
            Config = config;
            
            _miningTime = Config.MiningTimeBase;
            _miningAmount = Config.MiningAmountBase;
            _timer = 0f;
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= _miningTime)
            {
                OnMined?.Invoke(_miningAmount, Config.CurrencyType);
                _timer = 0;
            }
        }
    }
}