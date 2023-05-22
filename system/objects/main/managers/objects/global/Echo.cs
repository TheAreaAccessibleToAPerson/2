using Butterfly.system.objects.main.objects.global.description;

namespace Butterfly.system.objects.main.objects.global.description
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
    public sealed class ListenEcho<InputValueType, ReturnValueType> : IInput<InputValueType, description.IEchoReturn<ReturnValueType>>,
        main.objects.description.IRedirect<InputValueType, description.IEchoReturn<ReturnValueType>>, IInfomation
    {
        private System.Action<InputValueType, description.IEchoReturn<ReturnValueType>> _action;
        private readonly string _explorer;
        private readonly ulong _id;
        string IInfomation.GetExplorer() => _explorer;
        ulong IInfomation.GetID() => _id;
        public ListenEcho(string explorer, ulong id) => _explorer = explorer;
        void main.objects.description.IRedirect<InputValueType, description.IEchoReturn<ReturnValueType>>.output_to
            (System.Action<InputValueType, description.IEchoReturn<ReturnValueType>> action) => _action = action;
        void IInput<InputValueType, description.IEchoReturn<ReturnValueType>>.To
            (InputValueType value1, description.IEchoReturn<ReturnValueType> value2) => _action(value1, value2);
    }

    public sealed class SendEcho<InputValueType, ReturnValueType> : IInput<InputValueType>, description.IEchoReturn<ReturnValueType>,
        main.objects.description.IRedirect<ReturnValueType>
    {
        private readonly IInput<InputValueType, description.IEchoReturn<ReturnValueType>> _inputAction;
        private System.Action<ReturnValueType> _returnAction;
        private readonly ulong _id, _uniqueID;
        ulong IEchoReturn<ReturnValueType>.GetID() => _id;
        ulong IEchoReturn<ReturnValueType>.GetUnieueID() => _uniqueID;
        public SendEcho(IInput<InputValueType, description.IEchoReturn<ReturnValueType>> action, ulong id) 
        {
            _inputAction = action;
            _id = id;
            _uniqueID = s_uniqueID++;
        }
        void IInput<InputValueType>.To(InputValueType value) => _inputAction.To(value, this);
        void description.IEchoReturn<ReturnValueType>.To(ReturnValueType value) => _returnAction(value);
        void main.objects.description.IRedirect<ReturnValueType>.output_to(System.Action<ReturnValueType> action) => _returnAction = action;

        private static ulong s_uniqueID = 0;
    }
}