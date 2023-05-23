namespace Butterfly.system.objects.main.objects.description
{
    public interface IRedirect<InputValueType>
    {
        public IRedirect<InputValueType> output_to(System.Action<InputValueType> action);
        public IRedirect<OutputValueType> output_to<OutputValueType>(System.Func<InputValueType, OutputValueType> func);
    }

    public interface IRedirect<ValueType1, ValueType2>
    {
        public void output_to(System.Action<ValueType1, ValueType2> action);
    }
}