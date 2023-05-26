namespace Butterfly
{
    public interface IReturn<R> 
    { 
        void To(R value); 
        ulong GetID();
        ulong GetUnieueID();
    }

    public interface IReturn<R1, R2> 
    { 
        void To(R1 value1, R2 value2); 
        ulong GetID();
        ulong GetUnieueID();
    }
}

namespace Butterfly.system.objects.main
{
    /// <summary>
    /// Прослушивает входящие сообщения с возможностью возрата отправителю ответа.
    /// </summary>
    /// <typeparam name="T">Тип входящий данных.</typeparam>
    /// <typeparam name="R">Тип возращаемых данныx.</typeparam>
    public sealed class ListenEcho<T, R> : Redirect<T, IReturn<R>>, IInput<T, IReturn<R>>, IInputConnect
    {
        void IInput<T, IReturn<R>>.To
            (T value1, IReturn<R> value2) => _returnAction(value1, value2);

        object IInputConnect.GetConnect() => this;

        public ListenEcho(IInformation information) : base (information) {}
    }

    public sealed class SendEcho<T, R> : Redirect<R>, IInput<T>, IInputConnected, IReturn<R>
    {
        private IInput<T, IReturn<R>> _inputAction;

        void IInputConnected.SetConnected(object inputConnect)
        {
            if (inputConnect is IInput<T, IReturn<R>> inputConnectReduse)
            {
                _inputAction = inputConnectReduse;
            }
            else 
                throw new Exception($"Не удалось установить связь объекта {GetType().FullName} c обьектом {inputConnect.GetType().FullName}.");
        }

        public SendEcho(IInformation information) : base(information){}

        void IInput<T>.To(T value) => _inputAction.To(value, this);

        public void To(R value) => input.To(value);

        public ulong GetUnieueID() => s_uniqueID;

        private static ulong s_uniqueID = 0;
    }
}