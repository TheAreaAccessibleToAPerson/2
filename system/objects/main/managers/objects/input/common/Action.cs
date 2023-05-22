namespace Butterfly.system.objects.main.manager.objects.input.common
{
    public sealed class Action<InputValueType> : IInput<InputValueType>
    {
        private readonly System.Action<InputValueType> _action;

        public Action(System.Action<InputValueType> action) => _action = action;

        void IInput<InputValueType>.To(InputValueType value) => _action.Invoke(value);
    }
}