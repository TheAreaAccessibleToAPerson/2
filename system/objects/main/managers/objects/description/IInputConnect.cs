namespace Butterfly.system.objects.main
{
    public interface IInputConnect<ValueType>
    {
        public IInput<ValueType> Get();
    }
    public interface IInputConnect<ValueType1, ValueType2>
    {
        public IInput<ValueType1, ValueType2> Get();
    }

    public interface IInputConnected<ValueType>
    {
        public void Set(IInputConnect<ValueType> inputConnect);
    }

    public interface IInputConnected<ValueType1, ValueType2>
    {
        public void Set(IInputConnect<ValueType1, ValueType2> inputConnect);
    }
}