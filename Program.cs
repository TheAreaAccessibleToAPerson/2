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
                .output_to((number, reseive) => { Console("KDJFDKJF"); reseive.To(11); });


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
        IInput<int> _input, _input1;

        void Construction()
        {
            send_echo1<int>(ref _input, "Echo")
                .output_to((number) => Console("ECHO"));

            send_message<int>(ref _input1, "Message");
        }

        void Start()
        {
            _input.To(11);
            _input.To(11);
            _input1.To(22);
        }

        public void Set(int i) { }
    }
}

