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
            //unsafe_parallel_invoke("TestParallel");

            listen_message<int>("Message")
                .output_to((message) => { Console(message); });

            listen_message<string>("MessageString")
                .output_to((message) => { Console(message + "!!!???!!!!!!!!"); });

            listen_echo<int, int>("Echo")
                .output_to((number, reseive) => { Console("KDJFDKJF"); reseive.To(11); });

            listen_echo<int, int>("Echo1")
                .output_to((number, reseive) => { Console("TEST ECHO2"); reseive.To(121); });

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
        IInput<int> _input, _input1, _input2;
        IInput<int> _input3;

        void Construction()
        {
            send_echo<int>(ref _input, "Echo")
                .output_to((number) => Console("ECHO"));

            send_message<int>(ref _input1, "Message");

            input_to(ref _input3, obj<Test>("TEST1").Func)
                .send_message_to("MessageString");

            input_to(ref _input2, obj<Test>("TEST1").Func1)
                .output_to(obj<Test>("TEST2").Func2)
                    .output_to(obj<Test>("TEST3").Func2)
                        .send_echo_to("Echo1")
                            .output_to((number) => 
                                {
                                    Console("ECHO TEST 1");
                                });

            //input_to(ref _input3, obj<Test>("TEST3").Action);

            /*
            input_to_unsafe_parallel
                (ref _input3, obj<Test>("TEST33").Action, "TestParallel");
            */
        }

        void Start()
        {
            _input1.To(333);
            _input2.To(333);
            _input.To(22);
        }
    }

    public class Test : Controller
    {
        public void Action(int i1, int i2, int i3, int i4)
        {
            Console("ACTION4");
        }

        public string Func(int i1)
        {
            Console("FUNC!!!!");
            return "STRT";
        }

        public int Func1(int i)
        {
            Console("FUNC:" + i);

            return i + 1;
        }

        public int Func2(int i)
        {
            return 22;
        }

        public void Action(int i)
        {
            Console("ACTION" + i);
        }
    }
}

