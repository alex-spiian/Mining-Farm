using Zenject;

namespace Core.Logger
{
    public abstract class Loggable
    {
        protected ICustomLogger Logger { get; set; }

        [Inject]
        public void Construct(ICustomLogger logger)
        {
            Logger = logger;
        }
        
        protected string GetTag() => GetType().Name;
    }
}