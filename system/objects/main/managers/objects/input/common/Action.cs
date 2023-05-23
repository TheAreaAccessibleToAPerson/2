namespace Butterfly.system.objects.main
{
    public sealed class ActionObject<InputValueType> : IInput<InputValueType>
    {
        private readonly System.Action<InputValueType> _action;

        public ActionObject(System.Action<InputValueType> action) => _action = action;

        void IInput<InputValueType>.To(InputValueType value) => _action.Invoke(value);
    }
}