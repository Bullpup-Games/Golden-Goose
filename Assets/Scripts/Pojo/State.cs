namespace DefaultNamespace
{
    //the type of state possible for the Cleanstate to be. Moved outside of CleanState
    //because it is also called elsewhere, when controlling the state
    public enum State
    {
        
            Shiny,
            Clean,
            Normal,
            Dirty,
            Filthy
        
    }
}