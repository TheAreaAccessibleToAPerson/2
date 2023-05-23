namespace Butterfly.system.objects.main
{
    public interface IInformation
    {
        /// <summary>
        /// Хранит адрес обьекта в системе.
        /// </summary>
        /// <returns></returns>
        public string GetExplorer();

        /// <summary>
        /// Хранит ID создателя.
        /// </summary>
        /// <returns></returns>
        public ulong GetID();
    }
}