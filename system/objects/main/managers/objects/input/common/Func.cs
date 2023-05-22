namespace Butterfly.system.objects.main.manager.objects.input.common
{
    public sealed class Func<InputValueType, ReturnValueType> : IInput<InputValueType>, main.objects.description.IRedirect<ReturnValueType>
    {
        private readonly System.Func<InputValueType, ReturnValueType> _func;

        private System.Action<ReturnValueType> _action;

        public Func(System.Func<InputValueType, ReturnValueType> func) => _func = func;

        void main.objects.description.IRedirect<ReturnValueType>.output_to(System.Action<ReturnValueType> action) => _action = action;

        void IInput<InputValueType>.To(InputValueType value) => _action(_func(value));
    }
}