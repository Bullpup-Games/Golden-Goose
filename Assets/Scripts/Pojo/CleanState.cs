using System;

namespace DefaultNamespace
{
    public class CleanState
    {
        public float speed;

        public int payout;

        //TODO add a sprite for each one
        public State state;

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


    }
}