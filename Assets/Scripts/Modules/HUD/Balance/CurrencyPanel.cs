using MiningFarm.Enums;
using MiningFarm.Player;
using TMPro;
using UnityEngine;
using Zenject;

namespace Modules.HUD.Balance
{
    public class CurrencyPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _amountText;
        [SerializeField] private CurrencyType _currencyType;
        
        private PlayerDataService _playerDataService;

        [Inject]
        public void Construct(PlayerDataService playerDataService)
        {
            _playerDataService = playerDataService;
            
            var currencyData = _playerDataService.WalletService.GetCurrencyData(_currencyType);
            OnCurrencyChanged(currencyData.Amount, currencyData.CurrencyType);
            
            _playerDataService.WalletService.OnCurrencyChanged += OnCurrencyChanged;
        }

        private void OnDestroy()
        {
            _playerDataService.WalletService.OnCurrencyChanged -= OnCurrencyChanged;
        }

        private void OnCurrencyChanged(float amount, CurrencyType currencyType)
        {
            if (currencyType != _currencyType) 
                return;
            
            _amountText.text = amount.ToString();
        }
    }
}