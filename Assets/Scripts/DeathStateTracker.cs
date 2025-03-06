using UnityEngine;

public class DeathStateTracker : MonoBehaviour
{
    [SerializeField] public static DeathState State;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void SetState(DeathState state)
    {
        State = state;
    }

    public static DeathState GetState() => State;
}

public enum DeathState
{
    Alive,
    Touched,
    Starved
}
