using System;
using MiningFarm.Enums;

namespace MiningFarm.Player
{
    [Serializable]
    public class CurrenciesData
    {
        public CurrencyType CurrencyType;
        public float Amount;
    }
}