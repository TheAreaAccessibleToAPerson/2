
namespace Butterfly.system.objects.main.manager
{
    public sealed class Input : Informing
    {
        public Input(informing.IMain mainInforming) 
            : base("InputManager", mainInforming)
        {
        }

        public void Add<T>(ref IInput<T> input, Action<T> action)
            => input = new ActionObject<T>(action);

        public IRedirect<R> Add<T, R>(ref IInput<T> input, Func<T, R> func)
        {
            FuncObject<T, R> inputFunc = new FuncObject<T, R>(func);
            input = inputFunc;
            return inputFunc;
        }
    }


}