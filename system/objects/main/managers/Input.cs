
namespace Butterfly.system.objects.main.manager
{
    public sealed class Input : Informing
    {
        private readonly manager.IGlobalObjects _globalObjectsManager;
        private readonly information.State _stateInformation;

        private readonly string _explorer;
        private readonly ulong _id;

        public Input(informing.IMain mainInforming, string explorer, ulong id, information.State stateInformation,
            manager.IGlobalObjects globalObjectsManager)
            : base("InputManager", mainInforming)
        {
            _explorer = explorer;
            _id = id;

            _globalObjectsManager = globalObjectsManager;
            _stateInformation = stateInformation;
        }

        public void Add<T>(ref IInput<T> input, Action<T> action)
        { if (IsContructionState()) input = new ActionObject<T>(action); }

        public void Add<T1, T2, T3>(ref IInput<T1, T2> input,
            Action<T1, T2> action)
        { if (IsContructionState()) input = new ActionObject<T1, T2>(action); }

        public void Add<T1, T2, T3>(ref IInput<T1, T2, T3> input,
            Action<T1, T2, T3> action)
        { if (IsContructionState()) input = new ActionObject<T1, T2, T3>(action); }

        public void Add<T1, T2, T3, T4>(ref IInput<T1, T2, T3, T4> input,
            Action<T1, T2, T3, T4> action)
        { if (IsContructionState()) input = new ActionObject<T1, T2, T3, T4>(action); }

        public void Add<T1, T2, T3, T4, T5>(ref IInput<T1, T2, T3, T4, T5> input,
            Action<T1, T2, T3, T4, T5> action)
        { if (IsContructionState()) input = new ActionObject<T1, T2, T3, T4, T5>(action); }

        public void Add<T1, T2, T3, T4, T5, T6>(ref IInput<T1, T2, T3, T4, T5, T6> input,
            Action<T1, T2, T3, T4, T5, T6> action)
        { if (IsContructionState()) input = new ActionObject<T1, T2, T3, T4, T5, T6>(action); }

        public void Add<T1, T2, T3, T4, T5, T6, T7>(ref IInput<T1, T2, T3, T4, T5, T6, T7> input,
            Action<T1, T2, T3, T4, T5, T6, T7> action)
        { if (IsContructionState()) input = new ActionObject<T1, T2, T3, T4, T5, T6, T7>(action); }

        public void Add<T1, T2, T3, T4, T5, T6, T7, T8>(ref IInput<T1, T2, T3, T4, T5, T6, T7, T8> input,
            Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
        { if (IsContructionState()) input = new ActionObject<T1, T2, T3, T4, T5, T6, T7, T8>(action); }

        public void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9>(ref IInput<T1, T2, T3, T4, T5, T6, T7, T8, T9> input,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
        { if (IsContructionState()) input = new ActionObject<T1, T2, T3, T4, T5, T6, T7, T8, T9>(action); }

        public void Add<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(ref IInput<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> input,
            Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
        { if (IsContructionState()) input = new ActionObject<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(action); }

        public IRedirect<R> Add<T, R>(ref IInput<T> input, Func<T, R> func)
        {
            if (IsContructionState())
            {
                FuncObject<T, R> funcObject = new FuncObject<T, R>
                    (func, _explorer, _id, _globalObjectsManager);

                input = funcObject;

                return funcObject;
            }
            else
                return default;
        }

        public IRedirect<R> Add<T1, T2, R>
            (ref IInput<T1, T2> input, Func<T1, T2, R> func)
        {
            if (IsContructionState())
            {
                FuncObject<T1, T2, R> funcObject = new FuncObject<T1, T2, R>
                    (func, _explorer, _id, _globalObjectsManager);

                input = funcObject;

                return funcObject;
            }
            else
                return default;
        }

        public IRedirect<R> Add<T1, T2, T3, R>
            (ref IInput<T1, T2, T3> input, Func<T1, T2, T3, R> func)
        {
            if (IsContructionState())
            {
                FuncObject<T1, T2, T3, R> funcObject = new FuncObject<T1, T2, T3, R>
                    (func, _explorer, _id, _globalObjectsManager);

                input = funcObject;

                return funcObject;
            }
            else
                return default;
        }

        public IRedirect<R> Add<T1, T2, T3, T4, R>
            (ref IInput<T1, T2, T3, T4> input, Func<T1, T2, T3, T4, R> func)
        {
            if (IsContructionState())
            {
                FuncObject<T1, T2, T3, T4, R> funcObject = new FuncObject<T1, T2, T3, T4, R>
                    (func, _explorer, _id, _globalObjectsManager);

                input = funcObject;

                return funcObject;
            }
            else
                return default;
        }

        public IRedirect<R> Add<T1, T2, T3, T4, T5, R>
            (ref IInput<T1, T2, T3, T4, T5> input, Func<T1, T2, T3, T4, T5, R> func)
        {
            if (IsContructionState())
            {
                FuncObject<T1, T2, T3, T4, T5, R> funcObject = new FuncObject<T1, T2, T3, T4, T5, R>
                    (func, _explorer, _id, _globalObjectsManager);

                input = funcObject;

                return funcObject;
            }
            else
                return default;
        }

        public IRedirect<R> Add<T1, T2, T3, T4, T5, T6, R>
            (ref IInput<T1, T2, T3, T4, T5, T6> input, Func<T1, T2, T3, T4, T5, T6, R> func)
        {
            if (IsContructionState())
            {
                FuncObject<T1, T2, T3, T4, T5, T6, R> funcObject = new FuncObject<T1, T2, T3, T4, T5, T6, R>
                    (func, _explorer, _id, _globalObjectsManager);

                input = funcObject;

                return funcObject;
            }
            else
                return default;
        }

        public IRedirect<R> Add<T1, T2, T3, T4, T5, T6, T7, R>
            (ref IInput<T1, T2, T3, T4, T5, T6, T7> input, Func<T1, T2, T3, T4, T5, T6, T7, R> func)
        {
            if (IsContructionState())
            {
                FuncObject<T1, T2, T3, T4, T5, T6, T7, R> funcObject = new FuncObject<T1, T2, T3, T4, T5, T6, T7, R>
                    (func, _explorer, _id, _globalObjectsManager);

                input = funcObject;

                return funcObject;
            }
            else
                return default;
        }

        public IRedirect<R> Add<T1, T2, T3, T4, T5, T6, T7, T8, R>
            (ref IInput<T1, T2, T3, T4, T5, T6, T7, T8> input, Func<T1, T2, T3, T4, T5, T6, T7, T8, R> func)
        {
            if (IsContructionState())
            {
                FuncObject<T1, T2, T3, T4, T5, T6, T7, T8, R> funcObject = new FuncObject<T1, T2, T3, T4, T5, T6, T7, T8, R>
                    (func, _explorer, _id, _globalObjectsManager);

                input = funcObject;

                return funcObject;
            }
            else
                return default;
        }

        public IRedirect<R> Add<T1, T2, T3, T4, T5, T6, T7, T8, T9, R>
            (ref IInput<T1, T2, T3, T4, T5, T6, T7, T8, T9> input, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, R> func)
        {
            if (IsContructionState())
            {
                FuncObject<T1, T2, T3, T4, T5, T6, T7, T8, T9, R> funcObject = new FuncObject<T1, T2, T3, T4, T5, T6, T7, T8, T9, R>
                    (func, _explorer, _id, _globalObjectsManager);

                input = funcObject;

                return funcObject;
            }
            else
                return default;
        }

        public IRedirect<R> Add<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R>
            (ref IInput<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> input, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R> func)
        {
            if (IsContructionState())
            {
                FuncObject<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R> funcObject = new FuncObject<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R>
                    (func, _explorer, _id, _globalObjectsManager);

                input = funcObject;

                return funcObject;
            }
            else
                return default;
        }

        private bool IsContructionState()
        {
            if (_stateInformation.IsContruction)
            {
                return true;
            }
            else
                Exception("Вы можете использовать input_to только в методе void Contruction().");

            return false;
        }
    }
}