namespace Butterfly.system.objects.main.manager
{
    public struct SubscribeTicket
    {
        /// <summary>
        /// Настройка для пулла. Имя.
        /// </summary>
        public string Name;

        /// <summary>
        /// Ссылка на Action которую будет обрабатывать пулл.
        /// </summary>
        public Action Action;

        /// <summary>
        /// Настройка для пулла. Максимальный размер пулла. 
        /// </summary>
        public uint Size;

        /// <summary>
        /// Настройка для пулла. TimeDelay для пулла потоков.
        /// </summary>
        public uint TimeDelay;

        /// <summary>
        /// Ссылка на метод в PollManager с помощью которого пулл будет общатся со своим подписоным обьектом. 
        /// </summary>
        public Action<root.poll.InformingType, int , ulong, int> Informing;

        /// <summary>
        /// ID обьекта(узла) который регистрирует свои и подписки своих веток в пулл.
        /// </summary>
        public ulong IDObject;

        /// <summary>
        /// Индекс в массиве где хранится информация о регистрации в PollManager.  
        /// </summary>
        public int IndexInPollManager;
    }

    public struct UnsubscribeTicket
    {
    }

    public struct StateType
    {
        /// <summary>
        /// Создание билетов.
        /// </summary>
        public const string CREATING_TICKET = "CreatingTicket";

        /// <summary>
        /// Регистрируем подписки.
        /// </summary>
        public const string REGISTER_SUBSCRIBE = "RegisterSubscribe";

        /// <summary>
        /// Все подписки зарегистрировались.
        /// </summary>
        public const string END_SUBSCRIBE = "EndSubscribe";

        /// <summary>
        /// Регистрируем все отписки.
        /// </summary>
        public const string REGISTER_UNSUBSCRIBE = "RegisterUnsubscribe";

        /// <summary>
        /// Мы отписались ото всех отписок.
        /// </summary>
        public const string END_UNSUBSCRIBE = "EndUnsubscribe";
    }

    public class Poll : Informing
    {
        private readonly information.State _stateInformation;
        private readonly information.Header _headerInformation;
        private readonly information.DOM _DOMInformation;

        public Poll(informing.IMain mainInforming, information.State stateInformation, information.Header headerInformation,
            information.DOM DOMInformation)
            : base("SubscribeManager", mainInforming)
        {
            _stateInformation = stateInformation;
            _headerInformation = headerInformation;
            _DOMInformation = DOMInformation;
        }

        /// <summary>
        /// Добавляет регистриационый билет для пулла потоков. 
        /// </summary>
        /// <param name="name">Имя пулла потоков куда нам будет неоходимо произвести подписку.</param>
        /// <param name="action">Action который нам предстоит обрабатывать.</param>
        /// <param name="size">Размер пулла.</param>
        /// <param name="timeDelay">TimeDelay для пулла.</param>
        public void Add(string name, Action action, uint size, uint timeDelay)
        {
            if (_headerInformation.IsNodeObject())
            {
            }
            else 
                ((main.description.IPoll)_DOMInformation.NodeObject).Add(name, action, size, timeDelay);
        }

        public void Subscribe()
        {
        }
    }
}