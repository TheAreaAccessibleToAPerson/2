namespace Butterfly.system.objects.main
{
    public sealed class FuncObject<T1, R> : Redirect<R>, IInput<T1>
    {
        private readonly Func<T1, R> _func;

        public FuncObject(Func<T1, R> func, string explorer, ulong id, 
            manager.IGlobalObjects globalObjectsManager)
            : base (explorer, id, globalObjectsManager)
            => _func = func;

        public void To(T1 value) 
            => _returnAction(_func(value));
    }

    public sealed class FuncObject<T1, T2, R> : Redirect<R>, IInput<T1, T2>
    {
        private readonly Func<T1, T2, R> _func;

        public FuncObject(Func<T1, T2, R> func, string explorer, ulong id, 
            manager.IGlobalObjects globalObjectsManager)
            : base (explorer, id, globalObjectsManager)
            => _func = func;

        public void To(T1 value1, T2 value2) 
            => _returnAction(_func(value1, value2));
    }

    public sealed class FuncObject<T1, T2, T3, R> : Redirect<R>, IInput<T1, T2, T3>
    {
        private readonly Func<T1, T2, T3, R> _func;

        public FuncObject(Func<T1, T2, T3, R> func, string explorer, ulong id, 
            manager.IGlobalObjects globalObjectsManager)
            : base (explorer, id, globalObjectsManager)
            => _func = func;

        public void To(T1 value1, T2 value2, T3 value3) 
            => _returnAction(_func(value1, value2, value3));
    }
    public sealed class FuncObject<T1, T2, T3, T4, R> : Redirect<R>, IInput<T1, T2, T3, T4>
    {
        private readonly Func<T1, T2, T3, T4, R> _func;

        public FuncObject(Func<T1, T2, T3, T4, R> func, string explorer, ulong id, 
            manager.IGlobalObjects globalObjectsManager)
            : base (explorer, id, globalObjectsManager)
            => _func = func;

        public void To(T1 value1, T2 value2, T3 value3, T4 value4) 
            => _returnAction(_func(value1, value2, value3, value4));
    }

    public sealed class FuncObject<T1, T2, T3, T4, T5, R> : Redirect<R>, IInput<T1, T2, T3, T4, T5>
    {
        private readonly Func<T1, T2, T3, T4, T5, R> _func;

        public FuncObject(Func<T1, T2, T3, T4, T5, R> func, string explorer, ulong id, 
            manager.IGlobalObjects globalObjectsManager)
            : base (explorer, id, globalObjectsManager)
            => _func = func;

        public void To(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5) 
            => _returnAction(_func(value1, value2, value3, value4, value5));
    }

    public sealed class FuncObject<T1, T2, T3, T4, T5, T6, R> : Redirect<R>, IInput<T1, T2, T3, T4, T5, T6>
    {
        private readonly Func<T1, T2, T3, T4, T5, T6, R> _func;

        public FuncObject(Func<T1, T2, T3, T4, T5, T6, R> func, string explorer, ulong id, 
            manager.IGlobalObjects globalObjectsManager)
            : base (explorer, id, globalObjectsManager)
            => _func = func;

        public void To(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6) 
            => _returnAction(_func(value1, value2, value3, value4, value5, value6));
    }

    public sealed class FuncObject<T1, T2, T3, T4, T5, T6, T7, R> : Redirect<R>, IInput<T1, T2, T3, T4, T5, T6, T7>
    {
        private readonly Func<T1, T2, T3, T4, T5, T6, T7, R> _func;

        public FuncObject(Func<T1, T2, T3, T4, T5, T6, T7, R> func, string explorer, ulong id, 
            manager.IGlobalObjects globalObjectsManager)
            : base (explorer, id, globalObjectsManager)
            => _func = func;

        public void To(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7) 
            => _returnAction(_func(value1, value2, value3, value4, value5, value6, value7));
    }

    public sealed class FuncObject<T1, T2, T3, T4, T5, T6, T7, T8, R> : Redirect<R>, IInput<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, R> _func;

        public FuncObject(Func<T1, T2, T3, T4, T5, T6, T7, T8, R> func, string explorer, ulong id, 
            manager.IGlobalObjects globalObjectsManager)
            : base (explorer, id, globalObjectsManager)
            => _func = func;

        public void To(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8) 
            => _returnAction(_func(value1, value2, value3, value4, value5, value6, value7, value8));
    }

    public sealed class FuncObject<T1, T2, T3, T4, T5, T6, T7, T8, T9, R> : Redirect<R>, IInput<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, R> _func;

        public FuncObject(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, R> func, string explorer, ulong id, 
            manager.IGlobalObjects globalObjectsManager)
            : base (explorer, id, globalObjectsManager)
            => _func = func;

        public void To(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9) 
            => _returnAction(_func(value1, value2, value3, value4, value5, value6, value7, value8, value9));
    }

    public sealed class FuncObject<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R> : Redirect<R>, IInput<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
    {
        private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R> _func;

        public FuncObject(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R> func, string explorer, ulong id, 
            manager.IGlobalObjects globalObjectsManager)
            : base (explorer, id, globalObjectsManager)
            => _func = func;

        public void To(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9, T10 value10) 
            => _returnAction(_func(value1, value2, value3, value4, value5, value6, value7, value8, value9, value10));
    }
}