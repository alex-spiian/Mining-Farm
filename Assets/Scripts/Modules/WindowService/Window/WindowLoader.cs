using System;
using Core.Logger;
using Cysharp.Threading.Tasks;
using MiningFarm.Core.Base;
using Zenject;

namespace MiningFarm.WindowService
{
    public class WindowLoader : Loggable
    {
        private DiContainer _diContainer;

        [Inject]
        public void Construct(DiContainer diContainer)
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
                Logger.LogWarning("Can't close window " + moduleComponent, Tag);
                Logger.LogException(e, Tag);
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