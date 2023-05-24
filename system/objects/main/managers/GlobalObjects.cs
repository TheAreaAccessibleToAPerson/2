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

        public RedirectType Get<GlobalObjectType, LocalObjectType, InputValueType1, InputValueType2, RedirectType>
                    (ref IInput<InputValueType1> input, string key, LocalObjectType localObject)
                        where LocalObjectType : IInput<InputValueType1>, RedirectType, IInputConnected<InputValueType1, InputValueType2>
                                where GlobalObjectType : IInputConnect<InputValueType1, InputValueType2>, IInformation
        {
            input = localObject;

            localObject.Set(Get<GlobalObjectType>(key));

            return localObject;
        }

        public RedirectType Get<GlobalObjectType, LocalObjectType, InputType, InputValueType1, InputValueType2, RedirectType>
                    (ref InputType input, string key, LocalObjectType localObject)
                        where LocalObjectType : InputType, RedirectType, IInputConnected<InputValueType1, InputValueType2>
                                where GlobalObjectType : IInputConnect<InputValueType1, InputValueType2>, IInformation
        {
            input = localObject;

            localObject.Set(Get<GlobalObjectType>(key));

            return localObject;
        }

        public void Get<GlobalObjectType, InputValueType>(string key, ref IInput<InputValueType> input)
            where GlobalObjectType : IInput<InputValueType>, IInformation
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

        private GlobalObjectType Get<GlobalObjectType>(string key) where GlobalObjectType : IInformation
        {
            if (_stateInformation.IsContruction)
            {
                if (_values.TryGetValue(key, out object globalObject))
                {
                    if (globalObject is GlobalObjectType globalObjectReduse)
                    {
                        if (_DOMInformation.IsParentID(globalObjectReduse.GetID()))
                        {
                            return globalObjectReduse;
                        }
                        else
                            Exception($"Глобальный обьект с именем {key} не определен не у одного из ваших родителей. " +
                                $"Обьект с таким именем находится в {globalObjectReduse.GetExplorer()}");
                    }
                    else
                        throw new Exception($"Вы пытаетесь получить глобальный обьект типа {typeof(GlobalObjectType).FullName} по ключу {key}" +
                            $", но под данным ключом находится обьект типа {globalObject.GetType().FullName}.");
                }
                else
                    Exception($"Вы пытаетесь получить несущесвующий глобальный обьект по ключу {key}");
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

                    Hellper.ExpendArray(ref _creatingObjectKey, key);

                    return value;
                }
            }
            else
                Exception($"Вы можете установить ссылку на глобальный слушатель сообщений {key} только в методе Contruction().");

            return default;
        }
    }
}