using MiningFarm.Core.Base;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace MiningFarm.Core
{
    public class SaveDataService : LogicServiceBase
    {
        public void Save<T>(string key, T content)
        {
            var jsonContent = JsonConvert.SerializeObject(content);
            PlayerPrefs.SetString(key, jsonContent);
            Logger.Log($"Saved data with key {key}. Content {jsonContent}", Tag);
        }
      
        public bool Load<T>(string key, out T content)
        {
            var payLoad= PlayerPrefs.GetString(key);
            content = JsonConvert.DeserializeObject<T>(payLoad);

            if (content != null)
            {
                Logger.Log($"Loaded data with key {key}", Tag);
                return true;
            }
            
            Logger.LogWarning($"Can't load data with key {key}", Tag);
            return false;
        }
    }
}