using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace MiningFarm.WindowService
{
    public class SceneComponentFinder
    {
        public T GetComponentInSceneChildren<T>(string sceneName)
        {
            var scene = SceneManager.GetSceneByName(sceneName);
            if (!scene.IsValid()) 
                return default;

            var component = default(T);
            var rootGameObjects = scene.GetRootGameObjects();
            if (rootGameObjects != null)
            {
                ForEach(rootGameObjects, go =>
                {
                    var temp = go.GetComponentInChildren<T>(true);
                    if (!Equals(temp, default(T)))
                    {
                        component = temp;
                    }
                });
            }
            return component;
        }
        
        private void ForEach<T>(IEnumerable<T> enumerable, Action<T> handler)
        {
            foreach (T item in enumerable)
            {
                handler(item);
            }
        }
    }
}