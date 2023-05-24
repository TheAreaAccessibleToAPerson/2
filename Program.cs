﻿namespace Butterfly
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
        IInput<int> _input, _input1, _input2;

        void Construction()
        {
            send_echo<int>(ref _input, "Echo")
                .output_to((number) => Console("ECHO"));

            send_message<int>(ref _input1, "Message");

            input_to(ref _input2, obj<Test>("TEST1").Func)
                .output_to(obj<Test>("TEST2").Action);
        }

        void Start()
        {
            _input.To(11);
            _input.To(11);

            _input1.To(22);

            _input2.To(0);
        }
    }

    public class Test : Controller
    {
        public int Func(int i)
        {
            Console("FUNC:" + i);

            return i + 1;
        }

        public void Action(int i)
        {
            Console("ACTION" + i);
        }
    }
}

