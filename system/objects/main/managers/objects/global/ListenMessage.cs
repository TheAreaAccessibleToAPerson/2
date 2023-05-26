namespace Butterfly.system.objects.main
{
    public sealed class ListenMessage<ListenValueType> : Redirect<ListenValueType>, IInput<ListenValueType>
    {
        public ListenMessage(string explorer, ulong[] ids, manager.IGlobalObjects globalObjectsManager)
            : base (explorer, ids, globalObjectsManager){}

        public void To(ListenValueType value) => input.To(value);
    }
}