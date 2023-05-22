
namespace Butterfly.system.objects.main.manager
{
    public sealed class Input : Informing
    {
        public Input(informing.IMain mainInforming) 
            : base("InputManager", mainInforming)
        {
        }

        public void Add<T>(ref IInput<T> input, Action<T> action, DeliveryType type = DeliveryType.Common)
        {
            if (type.HasFlag(DeliveryType.Common))
                input = new objects.input.common.Action<T>(action);
        }

        public main.objects.description.IRedirect<R> Add<T, R>(ref IInput<T> input, Func<T, R> func, DeliveryType type = DeliveryType.Common)
        {
            if (type.HasFlag(DeliveryType.Common))
            {
                objects.input.common.Func<T, R> inputFunc = new objects.input.common.Func<T, R>(func);
                input = inputFunc;
                return inputFunc;
            }

            return default;
        }
    }


}