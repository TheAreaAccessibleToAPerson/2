namespace Butterfly.system.objects.main.manager
{
    public sealed class GlobalObjects : Informing
    {
        private readonly Dictionary<string, object> _values;

        private readonly information.Header _headerInformation;
        private readonly information.State _stateInformation;
        private readonly information.DOM _DOMInformation;

        public GlobalObjects(informing.IMain mainInforming, Dictionary<string, object> globalObjects,
            information.Header headerInformation, information.State stateInformation, information.DOM DOMInformation)
            : base("GlobalObjectsManager", mainInforming)
        {
            _values = globalObjects;

            _headerInformation = headerInformation;
            _stateInformation = stateInformation;
            _DOMInformation = DOMInformation;
        }

        public main.objects.description.IRedirect<ReceiveType, main.objects.global.description.IEchoReturn<ReturnType>> AddListenEcho<ReceiveType, ReturnType>
            (string name, DeliveryType type = DeliveryType.Common)
        {
            main.objects.global.ListenEcho<ReceiveType, ReturnType> listenEchoObject 
                = new main.objects.global.ListenEcho<ReceiveType, ReturnType>(_headerInformation.Explorer, _DOMInformation.ID);

            _values.Add(name, listenEchoObject);

            return listenEchoObject;
        }

        public main.objects.description.IRedirect<ReceiveValueType> AddSendEcho<InputValueType, ReceiveValueType>
            (ref IInput<InputValueType> input, string name, DeliveryType type = DeliveryType.Common)
        {
            if (_values.TryGetValue(name, out object listenEchoObject))
            {
                if (listenEchoObject is IInput<InputValueType, main.objects.global.description.IEchoReturn<ReceiveValueType>> listenEchoInput)
                {
                    main.objects.global.SendEcho<InputValueType, ReceiveValueType> sendEcho 
                        = new main.objects.global.SendEcho<InputValueType, ReceiveValueType>(listenEchoInput, _DOMInformation.ID);

                    input = sendEcho;

                    return sendEcho;
                }
            }

            return default;
        }

        public void AddSendMessage<MessageType>(ref IInput<MessageType> input, string name, DeliveryType type = DeliveryType.Common)
        {
            if (_stateInformation.IsContruction)
            {
                if (_values.TryGetValue(name, out object listenMessageObject))
                {
                    if (listenMessageObject is main.objects.global.ListenMessage<MessageType> listenMessage)
                    {
                        if (listenMessage is IInput<MessageType> listenMessageInput)
                        {
                            input = listenMessageInput;
                        }
                        else 
                            Exception($"Вы пытаетесь установить связь с глобаным обьектом {name}, но произошло несовпадение типов передоваемых" +
                                $" и прослушиваемых данных, вы пытаетесь передать тип {typeof(MessageType).FullName}");
                    }
                    else 
                        if (listenMessageObject is IInfomation globalObjectExplorer)
                            Exception($"Вы пытаетесь получить по имени {name} глобальный обьект который не является " +
                                $"слушателем. По данному имени определен глольный обьект созданый в {globalObjectExplorer.GetExplorer()}.");
                }
                else 
                    Exception($"Глобального слушателя сообщений с именем {name} не сущесвует.");
            }
            else
                Exception($"Вы можете установить ссылку на глобальный слушатель сообщений {name} только в методе Contruction().");
        }

        public main.objects.description.IRedirect<MessageType> AddListenMessage<MessageType>(string name, DeliveryType type = DeliveryType.Common)
        {
            if (_stateInformation.IsContruction)
            {
                if (_values.TryGetValue(name, out object globalObject))
                {
                    if (globalObject is IInfomation globalObjectExplorer)
                        Exception($"Вы уже создали глобальный обьект с именем {name} в {globalObjectExplorer.GetExplorer()}.");
                }
                else
                {
                    if (type.HasFlag(DeliveryType.Common))
                    {
                        main.objects.global.ListenMessage<MessageType> listenMessageObject
                            = new main.objects.global.ListenMessage<MessageType>(_headerInformation.Explorer, _DOMInformation.ID);

                        _values.Add(name, listenMessageObject);
                        return listenMessageObject;
                    }
                }
            }
            else 
                Exception($"Вы можете добавить глобальную прослушку сообщений c именем {name} только в методе Contruction().");

            return default;
        }

    }

}