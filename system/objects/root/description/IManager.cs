namespace Butterfly.system.objects.root
{
    /// <summary>
    /// Описывает методы для работы обьектов с Root.
    /// </summary>
    public interface IManager
    {
        /// <summary>
        /// Добавить в очередь на вызов Action в системный поток. 
        /// </summary>
        public void ActionInvoke(global::System.Action action);
    }
}