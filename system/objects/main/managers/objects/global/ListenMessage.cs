namespace Butterfly.system.objects.main.objects.global
{
    public sealed class ListenMessage<ListenValueType> : IInput<ListenValueType>, main.objects.description.IRedirect<ListenValueType>,
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

        main.objects.description.IRedirect<ListenValueType> main.objects.description.IRedirect<ListenValueType>.output_to
            (System.Action<ListenValueType> action)
        {
            _actions = Hellper.ExpendArray(_actions, action);

            return this;
        }

        main.objects.description.IRedirect<OutputValueType> main.objects.description.IRedirect<ListenValueType>.output_to<OutputValueType>
            (Func<ListenValueType, OutputValueType> func)
        {
            objects.input.common.Func<ListenValueType, OutputValueType> funcObject =
                new objects.input.common.Func<ListenValueType, OutputValueType>(func);

            _actions = Hellper.ExpendArray(_actions,new objects.input.common.Func<ListenValueType, OutputValueType>(func).To);

            return funcObject;
        }

        void IInput<ListenValueType>.To(ListenValueType value)
        {
            foreach(var action in _actions)
                action(value);
        }
    }
}