namespace Butterfly
{
    public enum DeliveryType
    {
        Common = 1,
        Guaranteed = 2,
        Safe = 3,
    }

    public interface IInput<InputValueType>
    {
        public void To(InputValueType value);
    }

    public interface IInput<InputValueType1, InputValueType2>
    {
        public void To(InputValueType1 value1, InputValueType2 value);
    }
}