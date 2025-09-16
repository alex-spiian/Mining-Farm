using System;
using MiningFarm.Enums;
using UnityEngine;
using TMPro;

namespace MiningFarm.Game
{
    public abstract class MiningMachineBase : MonoBehaviour
    {
        [Header("World UI")]
        [SerializeField] private TextMeshPro _amountText;
        [SerializeField] private TextMeshPro _progressText;
        [SerializeField] private TextMeshPro _nameText;
        
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
            _nameText.text = Config.Name;
            _timer = 0f;

            UpdateUI();
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            _progressText.text = $"{_timer:0.00} / {_miningTime:0.00} sec";

            if (_timer >= _miningTime)
            {
                OnMined?.Invoke(_miningAmount, Config.CurrencyType);

                _timer = 0;
                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            if (_amountText != null)
                _amountText.text = $"+{_miningAmount} {Config.CurrencyType} per {Config.MiningTimeBase:0.00} sec";
        }
    }
}