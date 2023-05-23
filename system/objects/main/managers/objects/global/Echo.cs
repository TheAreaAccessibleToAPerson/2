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
    public sealed class ListenEcho<InputValueType, ReturnValueType> : IInput<InputValueType, IReturn<ReturnValueType>>,
        IRedirect<InputValueType, IReturn<ReturnValueType>>, 
            IInputConnect<InputValueType, IReturn<ReturnValueType>>, IInformation
    {
        private readonly manager.IGlobalObjects _globalObjectsManager;
        private readonly information.State _stateInformation;

        private System.Action<InputValueType, IReturn<ReturnValueType>> _action;

        void IInput<InputValueType, IReturn<ReturnValueType>>.To
            (InputValueType value1, IReturn<ReturnValueType> value2) => _action(value1, value2);

        IInput<InputValueType, IReturn<ReturnValueType>> IInputConnect<InputValueType, IReturn<ReturnValueType>>.Get() 
            => this;

        private readonly string _explorer;
        private readonly ulong _id;
        string IInformation.GetExplorer() => _explorer;
        ulong IInformation.GetID() => _id;

        public ListenEcho(string explorer, ulong id, information.State stateInformation, manager.IGlobalObjects globalObjectManager) 
        {
            _explorer = explorer;
            _id = id;
            _stateInformation = stateInformation;
            _globalObjectsManager = globalObjectManager;
        }

        void IRedirect<InputValueType, IReturn<ReturnValueType>>.output_to
            (System.Action<InputValueType, IReturn<ReturnValueType>> action) => _action = action;
    }

    public sealed class SendEcho<InputValueType, ReturnValueType> : IInput<InputValueType>,
        IReturn<ReturnValueType>, IRedirect<ReturnValueType>,
            IInputConnected<InputValueType, IReturn<ReturnValueType>>
    {
        private readonly manager.IGlobalObjects _globalObjectsManager;

        private IInput<InputValueType, IReturn<ReturnValueType>> _inputAction;
        private Action<ReturnValueType>[] _returnActions = new Action<ReturnValueType>[0];

        private readonly ulong _id, _uniqueID;

        ulong IReturn<ReturnValueType>.GetID() => _id;
        ulong IReturn<ReturnValueType>.GetUnieueID() => _uniqueID;

        void IInputConnected<InputValueType, IReturn<ReturnValueType>>.Set
            (IInputConnect<InputValueType, IReturn<ReturnValueType>> inputConnect) => _inputAction = inputConnect.Get();

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