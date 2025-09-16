using System;
using UnityEngine;

namespace MiningFarm.Game
{
    public abstract class MiningMachineBase : MonoBehaviour
    {
        public event Action<float> OnGenerated;

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
                OnGenerated?.Invoke(_miningAmount);
                _timer = 0;
            }
        }
    }
}