namespace Butterfly.system.objects.main
{
    public abstract class Redirect<R> : IRedirect<R>
    {
        protected System.Action<R>[] _returnAction = new System.Action<R>[0];

        IRedirect<R> IRedirect<R>.output_to(Action<R> action)
        {
            Array.Resize(ref _returnAction, _returnAction.Length + 1);
            _returnAction[_returnAction.Length] = action;

            return this;
        }

        IRedirect<O> IRedirect<R>.output_to<O>(Func<R, O> func)
        {
            FuncObject<R, O> funcObject = new FuncObject<R, O>(func);

            Array.Resize(ref _returnAction, _returnAction.Length + 1);
            _returnAction[_returnAction.Length] = funcObject.To;

            return funcObject;
        }
    }
}