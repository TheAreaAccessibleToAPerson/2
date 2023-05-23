namespace Butterfly.system.objects.main.objects.input.common
{
    public sealed class Func<InputValueType, ReturnValueType> : IInput<InputValueType>, main.objects.description.IRedirect<ReturnValueType>
    {
        private readonly System.Func<InputValueType, ReturnValueType> _func;

        public System.Action<ReturnValueType>[] _returnAction = new System.Action<ReturnValueType>[0];

        public Func(System.Func<InputValueType, ReturnValueType> func) => _func = func;

        public void To(InputValueType value)
        {
            foreach(var action in _returnAction)
                action(_func(value));
        }

        main.objects.description.IRedirect<ReturnValueType> main.objects.description.IRedirect<ReturnValueType>.output_to
            (System.Action<ReturnValueType> action)
        {
            Hellper.ExpendArray(_returnAction, action);

            return this;
        }

        main.objects.description.IRedirect<OutputValueType> main.objects.description.IRedirect<ReturnValueType>.output_to<OutputValueType>
            (System.Func<ReturnValueType, OutputValueType> func)
        {
            objects.input.common.Func<ReturnValueType, OutputValueType> funcObject =
                new objects.input.common.Func<ReturnValueType, OutputValueType>(func);

            Hellper.ExpendArray(_returnAction, funcObject.To);

            return funcObject;
        }
    }
}