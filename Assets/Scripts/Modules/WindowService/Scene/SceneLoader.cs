using Core.Logger;
using Cysharp.Threading.Tasks;
using MiningFarm.Core.Base;
using MiningFarm.Enums;
using UnityEngine.SceneManagement;
using Zenject;

namespace MiningFarm.WindowService
{
    public class SceneLoader : Loggable
    {
        public bool IsSceneLoading => _isLoading;
        
        private SceneComponentFinder _sceneComponentFinder = new();
        private bool _isLoading;
        
        public async UniTask<IModuleInitializeAsync> LoadScene(WindowType types, object args)
        {
            if (types == WindowType.None)
            {
                Logger.LogError($"Scene loading error, Scene name = {types}", GetTag());
                return null;
            }
            
            if (_isLoading) 
                return null;

            _isLoading = true;
            SceneManager.LoadScene(types.ToString(), LoadSceneMode.Single);
            
            var moduleComponent = await InitializeSceneComponent(types.ToString(), args);
            _isLoading = false;

            return moduleComponent;
        }
        
        private async UniTask<IModuleInitializeAsync> InitializeSceneComponent(string sceneName, object args)
        {
            var sceneContext = _sceneComponentFinder.GetComponentInSceneChildren<SceneContext>(sceneName);
            if (sceneContext == null)
            {
                Logger.LogError($"SceneContext not found in scene {sceneName}", GetTag());
                return null;
            }

            if (sceneContext.Container.TryResolve<IModuleInitializeAsync>() is not { } moduleComponent)
            {
                Logger.LogError($"Bad configuration. IModuleInitializeAsync not found in scene {sceneName}.", GetTag());
                return null;
            }

            TrySetArgs(args, moduleComponent);
            
            await moduleComponent.InitializeAsync();
            await UniTask.WaitUntil(() => moduleComponent.IsInitialized());
            return moduleComponent;
        }
        
        private void TrySetArgs(object args, IModuleInitializeAsync moduleComponent)
        {
            if (moduleComponent is  IModuleArgsSetter moduleArgsSetter)
            {
                moduleArgsSetter.SetArgs(args);
            }
        }
    }
}