namespace Butterfly.system.objects.main.description
{
    public interface IPoll
    {
        /// <summary>
        /// Метод для добавления метода в пулл потоков.
        /// </summary>
        /// <param name="name">Имя пулла на который нужно подписаться.</param>
        /// <param name="action">Action который мы выставляем в пулл потоков для обработки.</param>
        /// <param name="size">Максимально возможный размер пулла.</param>
        /// <param name="timeDelay">timeDelay для пула потока.</param>
        public void Add(string name, Action action, uint size, uint timeDelay);
    }
}