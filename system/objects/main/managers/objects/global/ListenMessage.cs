namespace Butterfly.system.objects.main
{
    public sealed class ListenMessage<ListenValueType> : Redirect<ListenValueType>, IInput<ListenValueType>
    {
        public ListenMessage(IInformation information) : base (information){}

        public void To(ListenValueType value) => input.To(value);
    }
}