namespace Butterfly
{
    public interface IEchoReturn<ReturnValueType> 
    { 
        void To(ReturnValueType value); 
        ulong GetID();
        ulong GetUnieueID();
    }

}

namespace Butterfly.system.objects.main.objects.global
{
    public sealed class ListenEcho<InputValueType, ReturnValueType> : IInput<InputValueType, IEchoReturn<ReturnValueType>>,
        main.objects.description.IRedirect<InputValueType, IEchoReturn<ReturnValueType>>, IInformation
    {
        private readonly manager.IGlobalObjects _globalObjectsManager;
        private readonly information.State _stateInformation;

        private System.Action<InputValueType, IEchoReturn<ReturnValueType>> _action;

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

        void main.objects.description.IRedirect<InputValueType, IEchoReturn<ReturnValueType>>.output_to
            (System.Action<InputValueType, IEchoReturn<ReturnValueType>> action) => _action = action;
        void IInput<InputValueType, IEchoReturn<ReturnValueType>>.To
            (InputValueType value1, IEchoReturn<ReturnValueType> value2) => _action(value1, value2);
    }

    public sealed class SendEcho<InputValueType, ReturnValueType> : IInput<InputValueType>, IEchoReturn<ReturnValueType>,
        main.objects.description.IRedirect<ReturnValueType>
    {
        private readonly manager.IGlobalObjects _globalObjectsManager;
        private readonly information.State _stateInformation;

        private readonly IInput<InputValueType, IEchoReturn<ReturnValueType>> _inputAction;
        private System.Action<ReturnValueType>[] _returnActions = new System.Action<ReturnValueType>[0];

        private readonly ulong _id, _uniqueID;
        ulong IEchoReturn<ReturnValueType>.GetID() => _id;
        ulong IEchoReturn<ReturnValueType>.GetUnieueID() => _uniqueID;

        public SendEcho(IInput<InputValueType, IEchoReturn<ReturnValueType>> action, ulong id, information.State stateInformation,
            manager.IGlobalObjects globalObjectManager) 
        {
            _inputAction = action;
            _id = id;
            _uniqueID = s_uniqueID++;

            _stateInformation = stateInformation;
            _globalObjectsManager = globalObjectManager;
        }

        void IInput<InputValueType>.To(InputValueType value) => _inputAction.To(value, this);

        void IEchoReturn<ReturnValueType>.To(ReturnValueType value)
        {
            foreach(var _returnAction in _returnActions) 
                _returnAction.Invoke(value); 
        }

        main.objects.description.IRedirect<ReturnValueType> main.objects.description.IRedirect<ReturnValueType>.output_to
            (System.Action<ReturnValueType> action) 
        {
            Hellper.ExpendArray(_returnActions, action);

            return this;
        }

        public objects.description.IRedirect<OutputValueType> output_to<OutputValueType>(Func<ReturnValueType, OutputValueType> func)
        {
            objects.input.common.Func<ReturnValueType, OutputValueType> funcObject =
                new objects.input.common.Func<ReturnValueType, OutputValueType>(func);

            Hellper.ExpendArray(_returnActions, funcObject.To);

            return funcObject;
        }

        private static ulong s_uniqueID = 0;
    }
}