using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAi
{

    public class StateMachine<T>
    {

        T Owner { get; set; }
        State<T> CurrentState { get; set; }
        State<T> PreviousState { get; set; }
        State<T> GlobalState { get; set; }

        public StateMachine (T o, State<T> curState, State<T> globState)
        {
           Owner = o;
            CurrentState = curState;
            GlobalState = globState;

        }


        public void SetCurrentState(State<T> s)
        {
            CurrentState = s;
        }

        public void SetPreviousState(State<T> s)
        {
            PreviousState = s;
        }

        public void Update()
        {
            if (GlobalState != null) GlobalState.Execute(Owner);
            if (CurrentState != null) CurrentState.Execute(Owner);

        }

        public void ChangeState(State<T> newState)
        {
            PreviousState = CurrentState;
            CurrentState.Exit(Owner);
            CurrentState = newState;
            CurrentState.Enter(Owner);
        }


        public void RevertToPreviousState()
        {
            ChangeState(PreviousState);
        }

        public State<T> GetCurrentState()
        {
            return CurrentState;
        }

        public State<T> GetPreviousState()
        {
            return PreviousState;
        }

        public bool IsinState(State<T> st)
        {
            return CurrentState == st;
        }
    }
}
