namespace Butterfly.system.objects.main.manager
{
    /// <summary>
    /// Описывает методы для работы с глобальными обьектами с проверкой на соответсвие:
    /// 1) Создания/получений в определеный момент жизненого цикла.
    /// 2) При создании отсутвия схожего обьекта по ключу.
    /// 3)  
    /// </summary>
    public interface IGlobalObjects
    {
        public bool TryGet(string key, out object value);
        public bool TryGetInput<T>(string key, out T value);
        public bool TryAdd(string key, object value);
    }

    public sealed class GlobalObjects : Informing, IGlobalObjects
    {
        private readonly Dictionary<string, object> _values;

        /// <summary>
        /// Ключи обьектов созданых в текущем обьекте. 
        /// </summary>
        private string[] _creatingObjectKey = new string[0];

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

        bool IGlobalObjects.TryAdd(string key, object value) => true;
        bool IGlobalObjects.TryGet(string key, out object value)
        {
            value = null;
            return true;
        }
        bool IGlobalObjects.TryGetInput<T>(string key, out T value)
        {
            value = default;
            return true;
        }

        public IRedirect<ReceiveType, IReturn<ReturnType>> AddListenEcho<ReceiveType, ReturnType>(string name)
        {
            ListenEcho<ReceiveType, ReturnType> listenEchoObject
                = new ListenEcho<ReceiveType, ReturnType>
                    (_headerInformation.Explorer, _DOMInformation.ID, _stateInformation, this);

            _values.Add(name, listenEchoObject);

            return listenEchoObject;
        }

        public IRedirect<ReceiveValueType> AddSendEcho<InputValueType, ReceiveValueType>
            (ref IInput<InputValueType> input, string name)
        {
            /*
            if (_values.TryGetValue(name, out object listenEchoObject))
            {
                if (listenEchoObject is IInput<InputValueType, IEchoReturn<ReceiveValueType>> listenEchoInput)
                {
                    main.objects.global.SendEcho<InputValueType, ReceiveValueType> sendEcho
                        = new main.objects.global.SendEcho<InputValueType, ReceiveValueType>
                            (listenEchoInput, _DOMInformation.ID, _stateInformation, this);

                    input = sendEcho;

                    return sendEcho;
                }
            }
            */

            return default;
        }

        public RedirectType Get<GlobalObjectType, LocalObjectType, InputType, InputValueType1, InputValueType2, RedirectType>
                    (ref InputType input, string key, LocalObjectType localObject)
                        where LocalObjectType : InputType, RedirectType, IInputConnected<InputValueType1, InputValueType2>
                                where GlobalObjectType : IInputConnect<InputValueType1, InputValueType2>
        {
            input = localObject;

            localObject.Set(Get<GlobalObjectType>(key));

            return localObject;
        }

        public void Get<GlobalObjectType, InputType>(string key, out InputType input)
            where GlobalObjectType : InputType
                => input = Get<GlobalObjectType>(key);

        public RedirectType Add<GlobalObjectType, RedirectType, InputType>(string key, out InputType input, GlobalObjectType value)
            where GlobalObjectType : InputType, RedirectType
        {
            var globalObject = Add(key, value);

            input = globalObject;

            return globalObject;
        }

        public RedirectType Add<GlobalObjectType, RedirectType>(string key, GlobalObjectType value) 
            where GlobalObjectType : RedirectType
                => Add(key, value);



        private GlobalObjectType Get<GlobalObjectType>(string key)
        {
            if (_stateInformation.IsContruction)
            {
                if (_values.TryGetValue(key, out object globalObject))
                {
                    if (globalObject is IInformation globalObjectInformation)
                    {
                        if (_DOMInformation.IsParentID(globalObjectInformation.GetID()))
                        {
                            if (globalObject is GlobalObjectType globalObjectType)
                            {
                                return globalObjectType;
                            }
                            else
                                throw new Exception($"Вы пытаетесь получить глобальный обьект типа {typeof(GlobalObjectType).FullName} по ключу {key}" +
                                    $", но под данным ключом находится обьект типа {globalObject.GetType().FullName}.");
                        }
                        else
                            Exception($"Глобальный обьект с именем {key} не определен не у одного из ваших родителей. " +
                                $"Обьект с таким именем находится в {globalObjectInformation.GetExplorer()}");
                    }
                    else
                        throw new Exception($"Обьект {globalObject.GetType().FullName} не реализует интерфейс {typeof(IInformation).FullName}.");
                }
                else
                    Exception($"Вы пытаетесь получить несущесвующий глобальный обьект по ключу");
            }
            else
                Exception($"Вы можете установить ссылку на глобальный слушатель сообщений {key} только в методе Contruction().");

            return default;
        }

        private GlobalObjectType Add<GlobalObjectType>(string key, GlobalObjectType value)
        {
            if (_stateInformation.IsContruction)
            {
                if (_values.TryGetValue(key, out object globalObject))
                {
                    if (globalObject is IInformation globalObjectExplorer)
                    {
                        Exception($"Вы уже создали глобальный обьект с именем {key} c типом " +
                            $"{globalObject.GetType().FullName} в {globalObjectExplorer.GetExplorer()}.");
                    }
                    else 
                        throw new Exception($"Обьект типа {globalObject.GetType().FullName} не реализует интерфейс {typeof(IInformation).FullName}");
                }
                else
                {
                    _values.Add(key, value);

                    Hellper.ExpendArray(_creatingObjectKey, key);

                    return value;
                }
            }
            else
                Exception($"Вы можете установить ссылку на глобальный слушатель сообщений {key} только в методе Contruction().");

            return default;
        }
    }
}