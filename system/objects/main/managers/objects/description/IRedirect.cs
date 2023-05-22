namespace Butterfly.system.objects.main.objects.description
{
    public interface IRedirect<ValueType>
    {
        public void output_to(System.Action<ValueType> action);
    }

    public interface IRedirect<ValueType1, ValueType2>
    {
        public void output_to(System.Action<ValueType1, ValueType2> action);
    }
}