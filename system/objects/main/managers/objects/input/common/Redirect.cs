namespace Butterfly.system.objects.main
{
    public abstract class Information : IInformation
    {
        /// <summary>
        /// Место положение в нутри системы. 
        /// </summary>
        protected readonly string Explorer;

        /// <summary>
        /// 1) id обьекта в нутри которого был создан данный обьект.
        /// 2) id узла в нутри которого был создан данный обьект.
        /// </summary>
        protected readonly ulong[] IDs;

        public Information(string explorer, ulong[] ids)
        {
            Explorer = explorer;
            IDs = ids;
        }

        public string GetExplorer() => Explorer;
        public ulong GetID() => IDs[information.DOM.INDEX_OBJECT_ID];
        public ulong GetNodeID() => IDs[information.DOM.INDEX_NODE_OBJECT_ID];
    }

    public abstract class Redirect<T> : Information, IRedirect<T>
    {
        private readonly manager.IGlobalObjects _globalObjectsManager;

        public Redirect(string explorer, ulong[] ids, manager.IGlobalObjects globalObjectsManager) 
            : base(explorer, ids)
                => _globalObjectsManager = globalObjectsManager;

        protected IInput<T> input;

        public void output_to(Action<T> action)
            => new ActionObject<T>(ref input, action);

        public IRedirect<OutputValueType> output_to<OutputValueType>(Func<T, OutputValueType> func)
            => new FuncObject<T, OutputValueType> (ref input, func, Explorer, IDs, _globalObjectsManager);

        public void to_send_message(string name)
            => _globalObjectsManager.Get<ListenMessage<T>, IInput<T>> (name, ref input);
    }

    public abstract class Redirect<T1, T2> : Information, IRedirect<T1, T2>
    {
        private readonly manager.IGlobalObjects _globalObjectsManager;

        protected Action<T1, T2> _returnAction;

        public Redirect(string explorer, ulong[] ids, manager.IGlobalObjects globalObjectsManager) 
            : base(explorer, ids)
                => _globalObjectsManager = globalObjectsManager;

        public void output_to(Action<T1, T2> action) => _returnAction = action;

        public IRedirect<OutputValueType> output_to<OutputValueType>(Func<T1, T2, OutputValueType> action)
        {
            return default;
        }
    }
}