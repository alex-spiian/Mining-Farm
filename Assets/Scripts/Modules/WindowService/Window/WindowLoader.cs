using System;
using Core.Logger;
using Cysharp.Threading.Tasks;
using MiningFarm.Core.Base;
using Zenject;

namespace MiningFarm.WindowService
{
    public class WindowLoader
    {
        private DiContainer _diContainer;
        private ICustomLogger _logger;

        [Inject]
        public void Construct(DiContainer diContainer, ICustomLogger logger)
        {
            _logger = logger;
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
                _logger.LogWarning("Can't close window " + moduleComponent, GetTag());
                _logger.LogException(e, GetTag());
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
        
        private string GetTag() => nameof(WindowLoader);
    }
}