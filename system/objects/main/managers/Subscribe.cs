namespace Butterfly.system.objects.main.manager
{
    namespace description
    {
        /// <summary>
        /// Описывает метод который будет вызываться в менеджерах подписак
        /// после того как придет ответ о подписании в нужное место.
        /// /// </summary>
        public interface ISubscribe
        {
            /// <summary>
            /// Сообщим менеджеру отвечаещего за все подписки о том что нас подписали
            /// в нужные места.
            /// /// </summary>
            public void EndSubscribe();
        }
    }

    public class Subscribe : Informing, dispatcher.ISubscribe, description.ISubscribe
    {
        private readonly information.State _stateInformation;
        private readonly information.DOM _DOMInformation;

        private readonly manager.Poll _pollManager;

        private readonly manager.IDispatcher _dispatcherManager;

        private readonly object _locker = new object();

        /// <summary>
        /// Общее количесво регистраций на подписки. 
        /// </summary>
        private int RegisterSubscribeCount = 0;

        /// <summary>
        /// Когда нас подпишут, нам об этом сообщат, и мы инкременириует данное значение.
        /// Если оно станет равно количесву регистраци, то мы сообщим диспетчеру.
        /// </summary>
        private uint SubscribeCount = 0;

        /// <summary>
        /// Текущее количесво выполненых отписок. 
        /// </summary>
        private uint UnsubscribeCount = 0;

        public Subscribe(informing.IMain mainInforming, information.State stateInformation, information.Header headerInformation,
            information.DOM DOMInformation, manager.Dispatcher dispatcherManager)
                : base("SubscribeManager", mainInforming)
        {
            _stateInformation = stateInformation;
            _DOMInformation = DOMInformation;
            _dispatcherManager = dispatcherManager;

            _pollManager = new manager.Poll(mainInforming, stateInformation, headerInformation, DOMInformation);
        }

        /// <summary>
        /// Добавляется данные для регистрации в пулл потоков.
        /// </summary>
        /// <param name="name">Имя пулла на который нужно подписаться.</param>
        /// <param name="action">Action который мы выставляем в пулл потоков для обработки.</param>
        /// <param name="size">Максимально возможный размер пулла.</param>
        /// <param name="timeDelay">timeDelay для пула потока.</param>
        public void Add(string name, Action action, uint size, uint timeDelay)
        {
            RegisterSubscribeCount++;

            _pollManager.Add(name, action, size, timeDelay);
        }

        /// <summary>
        /// Запустить процесс регистрации на подписку в пуллы потоков и прослушку рассылки сообщений.
        /// </summary>
        void dispatcher.ISubscribe.StartSubscribe()
        {
            lock (_locker)
            {
                if (RegisterSubscribeCount > 0)
                {
                    _pollManager.Subscribe();
                }
                else
                    _dispatcherManager.Process(manager.Dispatcher.Command.END_SUBSCRIBE);
            }
        }

        void description.ISubscribe.EndSubscribe()
        {
            lock (_locker)
            {
                if (RegisterSubscribeCount == ++SubscribeCount)
                {
                   _DOMInformation.RootManager.ActionInvoke(() 
                    => _dispatcherManager.Process(manager.Dispatcher.Command.END_SUBSCRIBE));
                }
            }
        }

        public void StartUnsubscribe()
        {
        }

        public void EndUnsubscribe()
        {
        }

        private void InformingEndSubscribe()
        {
        }

        private void InformingEndUnsubscribe()
        {
        }
    }
}