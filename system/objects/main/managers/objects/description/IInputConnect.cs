namespace Butterfly.system.objects.main
{
    public interface IInputConnect
    {
        public object GetConnect();
    }


    public interface IInputConnected
    {
        public void SetConnected(object inputConnect);
    }
}