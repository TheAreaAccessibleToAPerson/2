namespace Butterfly.system.objects.main.objects.global
{
    public sealed class ListenMessage<ListenValueType> : IInput<ListenValueType>, main.objects.description.IRedirect<ListenValueType>,
        IInfomation
    {
        private System.Action<ListenValueType> _action;

        private readonly string _explorer;
        private readonly ulong _id;

        string IInfomation.GetExplorer() => _explorer;
        ulong IInfomation.GetID() => _id;

        public ListenMessage(string explorer, ulong id)
        {
            _explorer = explorer;
        }
        void main.objects.description.IRedirect<ListenValueType>.output_to(System.Action<ListenValueType> action) => _action = action;
        void IInput<ListenValueType>.To(ListenValueType value) => _action(value);
    }
}