namespace Butterfly
{
    public abstract class Controller : system.objects.main.Object
    {
        public Controller() : base(system.objects.main.information.Header.Data.CONTROLLER) {}
        public Controller(string type) : base(type) {}

        public abstract class Board : Controller 
        {
            public Board() : base(system.objects.main.information.Header.Data.BOARD){}
        }
    }
}