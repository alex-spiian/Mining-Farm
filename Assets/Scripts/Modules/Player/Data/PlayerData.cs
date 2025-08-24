using System;

namespace MiningFarm.Player
{
    [Serializable]
    public class PlayerData
    {
        public string Name;
        public int Level;
        public Guid Guid;
        public WalletData Wallet;
    }
}