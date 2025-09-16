using System;
using MiningFarm.Core.Base;
using MiningFarm.Enums;

namespace MiningFarm.Player
{
    public class WalletService : LogicServiceBase
    {
        public event Action<float, CurrencyType> OnCurrencyChanged; 
        
        private WalletData _walletData;

        public void Initialize(WalletData walletData)
        {
            _walletData = walletData;
        }
        
        public void AddMoney(int amount, CurrencyType currencyType)
        {
            var currenciesData = GetCurrencyData(currencyType);
            currenciesData.Amount += amount;
            OnCurrencyChanged?.Invoke(currenciesData.Amount, currencyType);
        }
        
        public void SpendMoney(int amount, CurrencyType currencyType)
        {
            var currenciesData = GetCurrencyData(currencyType);
            currenciesData.Amount -= amount;
            OnCurrencyChanged?.Invoke(currenciesData.Amount, currencyType);
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