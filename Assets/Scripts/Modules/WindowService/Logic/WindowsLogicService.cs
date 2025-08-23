using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Cysharp.Threading.Tasks;
using MiningFarm.Core.Base;
using MiningFarm.Enums;
using MiningFarm.Signals;

namespace MiningFarm.WindowService
{
    public class WindowsLogicService : LogicServiceBase
    {
        private const int K_MAX_COUNT = 5;
        
        private readonly WindowLoader _windowLoader = new();
        private readonly SceneLoader _sceneLoader = new();
        
        private readonly List<Metadata> _metadataQueue = new();
        private readonly Dictionary<WindowType, Type> _windowsMap = new();
        private readonly HashSet<WindowType> _windowTypesNoScene = new();

        public void Initialize()
        {
            DiContainer.Inject(_sceneLoader);
            DiContainer.Inject(_windowLoader);
            
            InitializeWindowsMap();
        }

        private void InitializeWindowsMap()
        {
            List<Type> types = new List<Type>();
            try
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();

                foreach (var assembly in assemblies)
                {
                    types.AddRange(assembly.GetTypes()
                        .Where(t =>
                            typeof(IModuleInitializeAsync).IsAssignableFrom(t) && !t.IsAbstract));   
                }
            }
            catch (Exception e)
            {
                Logger.LogException(e, GetTag());
            }

            foreach (var type in types)
            {
                var attribute = type.GetCustomAttribute<BaseWindowAttribute>();

                if (null == attribute)
                    continue;

                _windowsMap[attribute.Type] = type;

                if (attribute is WindowAttribute)
                {
                    _windowTypesNoScene.Add(attribute.Type);
                }
            }

            var allValues = Enum.GetValues(typeof(WindowType));
            foreach (WindowType value in allValues)
            {
                if (value != WindowType.None && !_windowsMap.ContainsKey(value))
                {
                    Logger.LogWarning("Can't find window " + value, GetTag());
                }
            }
        }

        public override async UniTask InitializeAsync()
        {
            await base.InitializeAsync();
            SignalBus.Subscribe<OpenWindowSignal>(OnOpenedWindow);
            SignalBus.Subscribe<CloseWindowSignal>(OnClosedWindow);
        }

        public override void Dispose()
        {
            base.Dispose();
            SignalBus.Unsubscribe<OpenWindowSignal>(OnOpenedWindow);
            SignalBus.Unsubscribe<CloseWindowSignal>(OnClosedWindow);
        }

        private void OpenWindow(WindowType types, object args = null)
        {
            if (AssertOpenWindow(types))
            {
                Logger.LogWarning("Can't open window during existing transition "+types, GetTag());
                return;
            }
            Logger.Log("Open "+types, GetTag());
            _metadataQueue.Add(new Metadata(types, args));

            if (_metadataQueue.Count > K_MAX_COUNT)
            {
                _metadataQueue.RemoveAt(0);
            }
            Process().Forget();
        }

        private void CloseWindow(WindowType types)
        {
            if (_metadataQueue.Count == 0 || _metadataQueue.LastOrDefault().Type != types)
                return;

            Logger.Log("Close "+types, GetTag());
            _metadataQueue.LastOrDefault().IsNeedToClose = true;
            Process().Forget();
        }
        
        private bool AssertOpenWindow(WindowType types)
        {
            if (_metadataQueue.Count <= 0)
                return false;

            if (!IsScene(types))
                return false;

            return _sceneLoader.IsSceneLoading;
        }

        private async UniTask Process()
        {
            if (_metadataQueue.Count == 0)
                return;

            var metadata = _metadataQueue.LastOrDefault();

            if (null == metadata.ModuleComponent)
            {
                await ProcessOpen(metadata);
            }
            else if (metadata.IsNeedToClose)
            {
                await ProcessClose(metadata);
            }
        }

        private async UniTask ProcessOpen(Metadata metadata)
        {
            var type = _windowsMap[metadata.Type];
            if (_windowTypesNoScene.Contains(metadata.Type))
            {
                await _windowLoader.ProcessOpen(type, metadata.Args);
            }
            else
            {
                await _sceneLoader.LoadScene(metadata.Type, metadata.Args);
            }

            if (IsScene(metadata.Type))
            {
                _metadataQueue.RemoveAll(temp => 
                    !IsScene(temp.Type));
                
                foreach (var currentMetadata in _metadataQueue)
                {
                    currentMetadata.ModuleComponent = null;
                }
            }
        }

        private async UniTask ProcessClose(Metadata metadata)
        {
            await _windowLoader.CloseAsync(metadata.ModuleComponent);
            _metadataQueue.Remove(metadata);

            if (IsScene(metadata.Type))
            {
                await Process();
            }
        }
        
        private bool IsScene(WindowType windowTypes)
        {
            return _windowTypesNoScene.Contains(windowTypes);
        }
        
        protected override string GetTag() => nameof(WindowsLogicService);

        #region Signals

        private void OnOpenedWindow(OpenWindowSignal openWindowSignal)
        {
            OpenWindow(openWindowSignal.WindowType, openWindowSignal.Args);
        }

        private void OnClosedWindow(CloseWindowSignal closeWindowSignal)
        {
            CloseWindow(closeWindowSignal.WindowType);
        }

        #endregion
    }
}