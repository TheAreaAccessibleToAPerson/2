namespace Butterfly
{
    public interface IReturn<ReturnValueType> 
    { 
        void To(ReturnValueType value); 
        ulong GetID();
        ulong GetUnieueID();
    }

}

namespace Butterfly.system.objects.main
{
    /// <summary>
    /// Прослушивает входящие сообщения с возможностью возрата отправителю ответа.
    /// </summary>
    /// <typeparam name="InputValueType">Тип входящий данных.</typeparam>
    /// <typeparam name="ReturnValueType">Тип возращаемых данныx.</typeparam>
    public sealed class ListenEcho<InputValueType, ReturnValueType> : Redirect<InputValueType, IReturn<ReturnValueType>>, 
        IInput<InputValueType, IReturn<ReturnValueType>>, IInputConnect, IInformation
    {
        private readonly manager.IGlobalObjects _globalObjectsManager;

        public IInput<ReturnValueType, IReturn<ReturnValueType>>[] _return = new IInput<ReturnValueType, IReturn<ReturnValueType>>[0];

        void IInput<InputValueType, IReturn<ReturnValueType>>.To
            (InputValueType value1, IReturn<ReturnValueType> value2) => _returnAction(value1, value2);


        object IInputConnect.GetConnect() => this;

        private readonly string _explorer;
        private readonly ulong _id;
        string IInformation.GetExplorer() => _explorer;
        ulong IInformation.GetID() => _id;

        public ListenEcho(string explorer, ulong id, manager.IGlobalObjects globalObjectManager) 
        {
            _explorer = explorer;
            _id = id;
            _globalObjectsManager = globalObjectManager;
        }

    }

    public sealed class SendEcho<InputValueType, ReturnValueType> : IInput<InputValueType>,
        IReturn<ReturnValueType>, IRedirect<ReturnValueType>, IInputConnected
    {
        private readonly manager.IGlobalObjects _globalObjectsManager;

        private IInput<InputValueType, IReturn<ReturnValueType>> _inputAction;
        private Action<ReturnValueType>[] _returnActions = new Action<ReturnValueType>[0];

        private readonly ulong _id, _uniqueID;

        ulong IReturn<ReturnValueType>.GetID() => _id;
        ulong IReturn<ReturnValueType>.GetUnieueID() => _uniqueID;

        void IInputConnected.SetConnected(object inputConnect)
        {
            if (inputConnect is IInput<InputValueType, IReturn<ReturnValueType>> inputConnectReduse)
            {
                _inputAction = inputConnectReduse;
            }
            else 
                throw new Exception($"Не удалось установить связь объекта {GetType().FullName} c обьектом {inputConnect.GetType().FullName}.");
        }

        public SendEcho(ulong id, manager.IGlobalObjects globalObjectManager) 
        {
            _id = id;
            _uniqueID = s_uniqueID++;

            _globalObjectsManager = globalObjectManager;
        }


        void IInput<InputValueType>.To(InputValueType value) => _inputAction.To(value, this);

        void IReturn<ReturnValueType>.To(ReturnValueType value)
        {
            foreach(var _returnAction in _returnActions) 
                _returnAction.Invoke(value); 
        }

        IRedirect<ReturnValueType> IRedirect<ReturnValueType>.output_to (Action<ReturnValueType> action) 
        {
            Hellper.ExpendAction_1Array(ref _returnActions, action);

            return this;
        }

        public IRedirect<OutputValueType> output_to<OutputValueType>(Func<ReturnValueType, OutputValueType> func)
            => Hellper.ExpendAction_1Array(ref _returnActions, new FuncObject<ReturnValueType, OutputValueType>(func));


        private static ulong s_uniqueID = 0;
    }
}