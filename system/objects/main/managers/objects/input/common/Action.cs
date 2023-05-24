namespace Butterfly.system.objects.main
{
    public sealed class ActionObject<T> : IInput<T>
    {
        private readonly Action<T> _action;

        public ActionObject(Action<T> action) => _action = action;

        void IInput<T>.To(T value) => _action.Invoke(value);
    }

    public sealed class ActionObject<T1, T2> : IInput<T1, T2>
    {
        private readonly Action<T1, T2> _action;

        public ActionObject(Action<T1, T2> action) => _action = action;

        void IInput<T1, T2>.To(T1 value1, T2 value2) => _action.Invoke(value1, value2);
    }

    public sealed class ActionObject<T1, T2, T3> : IInput<T1, T2, T3>
    {
        private readonly Action<T1, T2, T3> _action;

        public ActionObject(Action<T1, T2, T3> action) => _action = action;

        void IInput<T1, T2, T3>.To
            (T1 value1, T2 value2, T3 value3)
                => _action.Invoke(value1, value2, value3);
    }

    public sealed class ActionObject<T1, T2, T3, T4> : IInput<T1, T2, T3, T4>
    {
        private readonly Action<T1, T2, T3, T4> _action;

        public ActionObject(Action<T1, T2, T3, T4> action) => _action = action;

        void IInput<T1, T2, T3, T4>.To
            (T1 value1, T2 value2, T3 value3, T4 value4)
                => _action.Invoke(value1, value2, value3, value4);
    }

    public sealed class ActionObject<T1, T2, T3, T4, T5> : IInput<T1, T2, T3, T4, T5>
    {
        private readonly Action<T1, T2, T3, T4, T5> _action;

        public ActionObject(Action<T1, T2, T3, T4, T5> action) => _action = action;

        void IInput<T1, T2, T3, T4, T5>.To
            (T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
                => _action.Invoke(value1, value2, value3, value4, value5);
    }

    public sealed class ActionObject<T1, T2, T3, T4, T5, T6> : IInput<T1, T2, T3, T4, T5, T6>
    {
        private readonly Action<T1, T2, T3, T4, T5, T6> _action;

        public ActionObject(Action<T1, T2, T3, T4, T5, T6> action) => _action = action;

        void IInput<T1, T2, T3, T4, T5, T6>.To
            (T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6) 
                => _action.Invoke(value1, value2, value3, value4, value5, value6);
    }

    public sealed class ActionObject<T1, T2, T3, T4, T5, T6, T7> : IInput<T1, T2, T3, T4, T5, T6, T7>
    {
        private readonly Action<T1, T2, T3, T4, T5, T6, T7> _action;

        public ActionObject(Action<T1, T2, T3, T4, T5, T6, T7> action) => _action = action;

        void IInput<T1, T2, T3, T4, T5, T6, T7>.To
            (T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7) 
                => _action.Invoke(value1, value2, value3, value4, value5, value6, value7);
    }

    public sealed class ActionObject<T1, T2, T3, T4, T5, T6, T7, T8> : IInput<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8> _action;

        public ActionObject(Action<T1, T2, T3, T4, T5, T6, T7, T8> action) => _action = action;

        void IInput<T1, T2, T3, T4, T5, T6, T7, T8>.To
            (T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8) 
                => _action.Invoke(value1, value2, value3, value4, value5, value6, value7, value8);
    }

    public sealed class ActionObject<T1, T2, T3, T4, T5, T6, T7, T8, T9> : IInput<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> _action;

        public ActionObject(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) => _action = action;

        void IInput<T1, T2, T3, T4, T5, T6, T7, T8, T9>.To
            (T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9) 
                => _action.Invoke(value1, value2, value3, value4, value5, value6, value7, value8, value9);
    }

    public sealed class ActionObject<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : IInput<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
    {
        private readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> _action;

        public ActionObject(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) => _action = action;

        void IInput<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.To
            (T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10) 
                => _action.Invoke(value1, value2, value3, value4, value5, value6, value7, value8, value9, value10);
    }
}