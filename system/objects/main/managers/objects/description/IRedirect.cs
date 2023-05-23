namespace Butterfly.system.objects.main
{
    public interface IRedirect<InputValueType>
    {
        public IRedirect<InputValueType> output_to(Action<InputValueType> action);
        public IRedirect<OutputValueType> output_to<OutputValueType>(Func<InputValueType, OutputValueType> func);
    }

    public interface IRedirect<ValueType1, ValueType2>
    {
        public void output_to(System.Action<ValueType1, ValueType2> action);
    }
}