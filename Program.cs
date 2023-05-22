namespace Butterfly
{
    public class Program
    {
        static void Main(string[] arg) => Butterfly.fly<TestController>();
    }

    public class TestController : Controller
    {
        IInput<int> _input;

        void Construction()
        {
            listen_echo<int>("Echo")
                .output_to((number, reseive) => { reseive.To(11); });

            listen_message<int>("Message")
                .output_to((message) => { Console(message); });

            //input_to(ref _input, Run);

            Console("Construction()");
        }

        void Configurate()
        {
            Console("Configurate()");
        }

        void Start()
        {
            obj<III>("TEST_OBJECVT");
            Console("Start()");
        }
    }

    public class III : Controller
    {
        IInput<int> _input;

        void Construction()
        {
            send_echo<int>(ref _input, "Echo")
                .output_to((number) => { Console("NUMBER"); });
        }

        void Start()
        {
            _input.To(11);
        }

        public void Set(int i) { }
    }
}

