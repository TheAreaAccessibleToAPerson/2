namespace Butterfly.system.objects.main 
{
    public abstract class Informing
    {
        private readonly informing.IMain _mainInforming;

        private readonly string _directory;

        public Informing(string directory, informing.IMain mainInforming)
        {
            _directory = directory;
            _mainInforming = mainInforming;
        }

        /// <summary>
        /// Выводит сообщение в консоль через main обьект в котором определен текущий обьект.
        /// </summary>
        /// <param name="message"></param>
        protected void Console(string message) => _mainInforming.Console(message);

        /// <summary>
        /// Вызывает ошибку времени сборки обьекта и выводит сообщение об ошибки через main object.
        /// </summary>
        /// <param name="message">Сообщение ошибки.</param>
        /// <param name="arg">Дополнительные данные об ошибки.</param>
        protected void Exception(string message, params string[] arg) => _mainInforming.Exception(message, arg);

        /// <summary>
        /// Выводит системую информацию через main обьект. 
        /// </summary>
        /// <param name="message">Системное сообщение.</param>
        protected void SystemInformation(string message) => _mainInforming.SystemInformation(message);
    }
}