namespace Butterfly.system.objects.main.informing
{
    /// <summary>
    /// Описывает методы для вывода необходимой информации через базовый обьект Main. 
    /// </summary>
    public interface IMain 
    {
        /// <summary>
        /// Выводит сообщение в консоль.
        /// </summary>
        /// <param name="message">Сообщение</param>
        public void Console(string message);

        /// <summary>
        /// Выводит сообщение в консоль.
        /// </summary>
        /// <param name="message">Сообщение</param>
        public void Console(int message);

        /// <summary>
        /// Выводит сообщение в консоль.
        /// </summary>
        /// <param name="message">Сообщение</param>
        public void Console(uint message);

        /// <summary>
        /// Выводит сообщение в консоль.
        /// </summary>
        /// <param name="message">Сообщение</param>
        public void Console(long message);
        /// <summary>
        /// Выводит сообщение в консоль.
        /// </summary>
        /// <param name="message">Сообщение</param>
        public void Console(ulong message);

        /// <summary>
        /// Выводит сообщение в консоль.
        /// </summary>
        /// <param name="message">Сообщение</param>
        public void Console(double message);

        /// <summary>
        /// Выводит сообщение в консоль.
        /// </summary>
        /// <param name="message">Сообщение</param>
        public void Console(bool message);

        /// <summary>
        /// Выводит сообщение в консоль.
        /// </summary>
        /// <param name="message">Сообщение</param>
        public void Console(float message);

        /// <summary>
        /// Вызывает исключение времени сборки обьекта и выводит причину в консоль.
        /// </summary>
        /// <param name="message">Сообщение содержащее описание причины сбоя.</param>
        /// <param name="arg">Необходимые аргументы для того что бы точно понять причину сбоя.</param>
        public void Exception(string message, params string[] arg);

        /// <summary>
        /// Выводит в консоль системное сообщение.
        /// </summary>
        /// <param name="message">Системное сообщение для вывода в консоль.</param>
        public void SystemInformation(string message);
    }
}