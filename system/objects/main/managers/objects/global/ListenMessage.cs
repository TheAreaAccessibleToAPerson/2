namespace Butterfly.system.objects.main
{
    public sealed class ListenMessage<ListenValueType> : Redirect<ListenValueType>, IInput<ListenValueType>
    {
        public ListenMessage(string explorer, ulong id, manager.IGlobalObjects globalObjectsManager)
            : base (explorer, id, globalObjectsManager){}

        public void To(ListenValueType value) => input.To(value);
    }
}