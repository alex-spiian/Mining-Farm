using System;
using MiningFarm.Core.Base;
using MiningFarm.Enums;

namespace MiningFarm.Player
{
    public class WalletService : LogicServiceBase
    {
        public event Action<float, CurrencyType> OnCurrencyChanged; 
        public event Action<WalletData> OnWalletChanged;
        
        private WalletData _walletData;

        public void Initialize(WalletData walletData)
        {
            _walletData = walletData;
        }
        
        public void AddMoney(float amount, CurrencyType currencyType)
        {
            var currenciesData = GetCurrencyData(currencyType);
            currenciesData.Amount += amount;
            OnCurrencyChanged?.Invoke(currenciesData.Amount, currencyType);
            OnWalletChanged?.Invoke(_walletData);
        }
        
        public void SpendMoney(float amount, CurrencyType currencyType)
        {
            var currenciesData = GetCurrencyData(currencyType);
            currenciesData.Amount -= amount;
            OnCurrencyChanged?.Invoke(currenciesData.Amount, currencyType);
            OnWalletChanged?.Invoke(_walletData);
        }
        
        public CurrenciesData GetCurrencyData(CurrencyType currencyType)
        {
            var currenciesData = _walletData.Currencies.Find(type => type.CurrencyType == currencyType);
            if (currenciesData == null)
            {
                Logger.LogError($"CurrencyType not found: {currencyType}", Tag);
                return null;
            }
            return currenciesData;
        }
    }
}