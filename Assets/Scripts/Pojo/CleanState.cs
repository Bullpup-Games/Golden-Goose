using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class CleanState
    {
        public float speed;

        public int payout;

        //TODO add a sprite for each one
        public State state;

        public static readonly Dictionary<State, int> StateToInt =  new Dictionary<State,int>()
        {
            [State.Shiny] = 4,
            [State.Clean] = 3,
            [State.Normal] = 2,
            [State.Dirty] = 1,
            [State.Filthy] = 0
        };
        
        public static readonly Dictionary<int, State> IntToState=  new Dictionary<int,State>()
        {
            [5] = State.Shiny,//if we go above 4, we stay at shiny
            [4] = State.Shiny,
            [3] = State.Clean,
            [2] = State.Normal ,
            [1] = State.Dirty,
            [0] = State.Filthy,
            [-1] = State.Filthy//if we go below 0, we stay at filthy
            //this works because when you pull the number from the other Dictionary,
            //it will give the number in bounds. The error will not compound
        };
        
        // public enum State
        // {
        //     Shiny,
        //     Clean,
        //     Normal,
        //     Dirty,
        //     Filthy
        // }





        private CleanState(float speed, int payout, State state)
        {
            this.speed = speed;
            this.payout = payout;
            this.state = state;
        }

        public CleanState(State state) : this(
            state switch
            {
                State.Shiny => 5.0f,
                State.Clean => 4.5f,
                State.Normal => 4.0f,
                State.Dirty => 3.5f,
                State.Filthy => 3.0f,
                _ => 0.0f
            },
            state switch
            {
                State.Shiny => 25,
                State.Clean => 15,
                State.Normal => 10,
                State.Dirty => 5,
                State.Filthy => 1,
                _ => 0
            },
            state) { }//empty body

        public static CleanState changeState(CleanState cleanState, int Modifier)
        {
           int currentState = StateToInt[cleanState.state];
           int newStateNum = currentState + Modifier;
           State newState = IntToState[newStateNum];
           
           Debug.Log(newState);

           return new CleanState(newState);
           

        }

    }
}