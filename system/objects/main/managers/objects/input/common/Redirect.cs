namespace Butterfly.system.objects.main
{
    public abstract class Redirect<T> : IRedirect<T>
    {
        public Redirect(manager.GlobalObjects globalObjectsManager)
        {
        }

        protected Action<T>[] _returnAction = new Action<T>[0];

        public IRedirect<T> output_to(Action<T> action)
        {
            Array.Resize(ref _returnAction, _returnAction.Length + 1);
            _returnAction[_returnAction.Length] = action;

            return this;
        }

        public IRedirect<OutputValueType> output_to<OutputValueType>(Func<T, OutputValueType> func)
        {
            FuncObject<T, OutputValueType> funcObject = new FuncObject<T, OutputValueType>(func);

            Array.Resize(ref _returnAction, _returnAction.Length + 1);
            _returnAction[_returnAction.Length] = funcObject.To;

            return funcObject;
        }
    }

    public abstract class Redirect<T1, T2> : IRedirect<T1, T2>
    {
        protected Action<T1, T2> _returnAction;

        public void output_to(Action<T1, T2> action) => _returnAction = action;

        public void output_to<OutputValueType>(Func<T1, T2, OutputValueType> action)
        {
        }
    }
}