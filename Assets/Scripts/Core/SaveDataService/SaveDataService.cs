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
            Logger.Log($"Saved data with key {key} of type {nameof(T)}", GetTag());
        }
      
        private bool Load<T>(string key, out T content)
        {
            var payLoad= PlayerPrefs.GetString(key);
            content = JsonConvert.DeserializeObject<T>(payLoad);

            if (content != null)
            {
                Logger.Log($"Loaded data with key {key} of type {nameof(T)}", GetTag());
                return true;
            }
            
            Logger.LogError($"Can't load data with key {key} of type {nameof(T)}", GetTag());
            return false;
        }
    }
}