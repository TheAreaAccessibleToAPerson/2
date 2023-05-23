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
            listen_message<int>("Message")
                .output_to((message) => { Console(message); });

            listen_echo<int>("Echo")
                .output_to((number, reseive) => { reseive.To(11); });


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
            send_message<int>(out _input, "Message");
        }

        void Start()
        {
            Console("INPUT");
            _input.To(11);
            _input.To(11);
        }

        public void Set(int i) { }
    }
}

