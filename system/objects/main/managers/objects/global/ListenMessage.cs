namespace Butterfly.system.objects.main
{
    public sealed class ListenMessage<ListenValueType> : IInput<ListenValueType>, IRedirect<ListenValueType>,
        IInformation
    {
        private System.Action<ListenValueType>[] _actions = new System.Action<ListenValueType>[0];

        private readonly string _explorer;
        private readonly ulong _id;

        string IInformation.GetExplorer() => _explorer;
        ulong IInformation.GetID() => _id;

        public ListenMessage(string explorer, ulong id)
        {
            _explorer = explorer;
            _id = id;
        }

        IRedirect<ListenValueType> IRedirect<ListenValueType>.output_to
            (System.Action<ListenValueType> action)
        {
            Hellper.ExpendArray(ref _actions, action);

            return this;
        }

        IRedirect<OutputValueType> IRedirect<ListenValueType>.output_to<OutputValueType>
            (Func<ListenValueType, OutputValueType> func)
        {
            FuncObject<ListenValueType, OutputValueType> funcObject = new FuncObject<ListenValueType, OutputValueType>(func);

            Hellper.ExpendArray(ref _actions, new FuncObject<ListenValueType, OutputValueType>(func).To);

            return funcObject;
        }

        void IInput<ListenValueType>.To(ListenValueType value)
        {
            foreach(var action in _actions)
                action(value);
        }
    }
}