namespace Butterfly.system.objects.main
{
    public sealed class FuncObject<InputValueType, ReturnValueType> : IInput<InputValueType>, IRedirect<ReturnValueType>
    {
        private readonly System.Func<InputValueType, ReturnValueType> _func;

        public IInput<ReturnValueType>[] _return = new IInput<ReturnValueType>[0];

        public System.Action<ReturnValueType>[] _returnAction = new System.Action<ReturnValueType>[0];

        public FuncObject(System.Func<InputValueType, ReturnValueType> func) => _func = func;

        public void To(InputValueType value)
        {
            foreach(var action in _returnAction)
                action(_func(value));
        }

        IRedirect<ReturnValueType> IRedirect<ReturnValueType>.output_to (System.Action<ReturnValueType> action)
        {
            Hellper.ExpendArray(ref _returnAction, action);

            return this;
        }

        IRedirect<OutputValueType> IRedirect<ReturnValueType>.output_to<OutputValueType>
            (System.Func<ReturnValueType, OutputValueType> func)
        {
            FuncObject<ReturnValueType, OutputValueType> funcObject = new FuncObject<ReturnValueType, OutputValueType>(func);

            Hellper.ExpendArray(ref _returnAction, funcObject.To);

            return funcObject;
        }
    }
}