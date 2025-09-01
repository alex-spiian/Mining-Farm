using Zenject;

namespace Core.Logger
{
    public abstract class Loggable
    {
        protected ICustomLogger Logger { get; set; }
        protected virtual string Tag => GetType().Name;

        [Inject]
        public void Construct(ICustomLogger logger)
        {
            Logger = logger;
        }
    }
}