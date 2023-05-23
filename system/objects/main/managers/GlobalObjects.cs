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

        bool IGlobalObjects.TryAdd(string key, object value) => TryAdd(key, value);
        bool IGlobalObjects.TryGet(string key, out object value) => TryGet(key, out value);
        bool IGlobalObjects.TryGetInput<T>(string key, out T value) => TryGet(key, out value);

        public main.objects.description.IRedirect<ReceiveType, IEchoReturn<ReturnType>> AddListenEcho<ReceiveType, ReturnType>
            (string name, DeliveryType type = DeliveryType.Common)
        {
            main.objects.global.ListenEcho<ReceiveType, ReturnType> listenEchoObject
                = new main.objects.global.ListenEcho<ReceiveType, ReturnType>
                    (_headerInformation.Explorer, _DOMInformation.ID, _stateInformation, this);

            _values.Add(name, listenEchoObject);

            return listenEchoObject;
        }

        public main.objects.description.IRedirect<ReceiveValueType> AddSendEcho<InputValueType, ReceiveValueType>
            (ref IInput<InputValueType> input, string name)
        {
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

            return default;
        }

        public main.objects.description.IRedirect<ReceiveValueType> TryGet<InputValueType, ReceiveValueType>
            (ref IInput<InputValueType> input, string name)
        {
            return default;
        }


        public RedirectType TryAdd<MessageType, ObjectType, RedirectType, InputType>(string key, out InputType input, ObjectType value)
        {
            input = default;

            if (TryAdd(key, value))
            {
                if (value is RedirectType valueRedirect)
                {
                    if (value is InputType valueInput)
                    {
                        input = valueInput;
                    }

                    return valueRedirect;
                }
            }

            return default;
        }

        public RedirectType TryAdd<MessageType, ObjectType, RedirectType>(string key, ObjectType value) 
        {
            if (TryAdd(key, value))
            {
                if (value is RedirectType valueRedirect)
                {
                    return valueRedirect;
                }
            }

            return default;
        }

        public bool TryGet<T, InputType>(string key, out InputType input)
        {
            input = default;

            if (TryGet(key, out T globalObject))
            {
                if (globalObject is InputType globalObjectInput)
                {
                    input = globalObjectInput;

                    return true;
                }
                else 
                    throw new Exception($"Объект типа {typeof(T).FullName} не реализует Input типа {typeof(InputType).FullName}.");
            }
            else 
                return false;
        }


        private bool TryGet<T>(string key, out T value)
        {
            value = default;

            if (_stateInformation.IsContruction)
            {
                if (_values.TryGetValue(key, out object globalObject))
                {
                    if (globalObject is IInformation globalObjectInformation)
                    {
                        if (_DOMInformation.IsParentID(globalObjectInformation.GetID()))
                        {
                            if (globalObject is T globalObjectType)
                            {
                                value = globalObjectType;

                                return true;
                            }
                            else
                                throw new Exception($"Вы пытаетесь получить глобальный обьект типа {typeof(T).FullName} по ключу {key}" +
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

            return false;
        }

        private bool TryAdd<T>(string key, T value)
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

                    return true;
                }
            }
            else
                Exception($"Вы можете установить ссылку на глобальный слушатель сообщений {key} только в методе Contruction().");

            return false;
        }
    }
}