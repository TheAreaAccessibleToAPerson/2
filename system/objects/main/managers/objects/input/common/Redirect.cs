namespace Butterfly.system.objects.main
{
    public abstract class Information : IInformation
    {
        protected readonly string _explorer;
        protected readonly ulong _id;

        public Information(string explorer, ulong id)
        {
            _explorer = explorer;
            _id = id;
        }

        public string GetExplorer() => _explorer;
        public ulong GetID() => _id;
    }

    public abstract class Redirect<T> : Information, IRedirect<T>
    {
        private readonly manager.IGlobalObjects _globalObjectsManager;

        public Redirect(string explorer, ulong id, manager.IGlobalObjects globalObjectsManager) 
            : base(explorer, id)
                => _globalObjectsManager = globalObjectsManager;

        protected Action<T> _returnAction;

        public void output_to(Action<T> action) => _returnAction = action;

        public IRedirect<OutputValueType> output_to<OutputValueType>(Func<T, OutputValueType> func)
        {
            FuncObject<T, OutputValueType> funcObject = new FuncObject<T, OutputValueType>
                (func, _explorer, _id, _globalObjectsManager);

            _returnAction = funcObject.To;

            return funcObject;
        }
    }

    public abstract class Redirect<T1, T2> : Information, IRedirect<T1, T2>
    {
        private readonly manager.IGlobalObjects _globalObjectsManager;

        protected Action<T1, T2> _returnAction;

        public Redirect(string explorer, ulong id, manager.IGlobalObjects globalObjectsManager) 
            : base(explorer, id)
                => _globalObjectsManager = globalObjectsManager;

        public void output_to(Action<T1, T2> action) => _returnAction = action;

        public IRedirect<OutputValueType> output_to<OutputValueType>(Func<T1, T2, OutputValueType> action)
        {
            return default;
        }
    }
}