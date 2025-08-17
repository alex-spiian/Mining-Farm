using System;
using Cysharp.Threading.Tasks;
using MiningFarm.Core.Base;
using UnityEngine;
using Zenject;

namespace MiningFarm.WindowService
{
    public class WindowLoader
    {
        private DiContainer _diContainer;

        [Inject]
        public void Inject(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public async UniTask CloseAsync(IModuleInitializeAsync moduleComponent)
        {
            try
            {
                await moduleComponent.CloseAsync();
                moduleComponent.Dispose();
            }
            catch (Exception e)
            {
                Debug.LogWarning("Can't close window " + moduleComponent);
                Debug.LogException(e);
            }
        }

        public async UniTask<IModuleInitializeAsync> ProcessOpen(Type windowType, object arg)
        {
            var moduleComponent = _diContainer.Instantiate(windowType)
                as IModuleInitializeAsync;
            
            if (moduleComponent is IModuleArgsSetter dataReceiver && arg != null)
            {
                dataReceiver.SetArgs(arg);
            }
            
            await moduleComponent.InitializeAsync();
            return moduleComponent;
        }
    }
}