using UnityEngine;

namespace MiningFarm.Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObject/Player/PlayerData")]
    public class PlayerDataConfig : ScriptableObject
    {
        [SerializeField] private PlayerData _playerData;
        
        public PlayerData PlayerData => _playerData;
    }
}