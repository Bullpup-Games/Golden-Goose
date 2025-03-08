using System.Collections;
using DefaultNamespace;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GooseMovement : MonoBehaviour
{

    //this should be the cursor, unless something else is more urgent
    //such as food, water, a toy, etc. 
    public Transform player;
    public Transform foodBowl;
    
    private GooseHunger _hunger;
    
    NavMeshAgent _agent;

    private Coroutine moneyRoutine;
    
    public CleanState cleanState;

    public string stateName;
    
    
    
   
    void Start()
    {
        player = CursorManager.Instance.transform;
        _agent = GetComponent<NavMeshAgent>();
        _hunger = GetComponent<GooseHunger>();

        // _agent.updateRotation = false;
        _agent.updateUpAxis = false;

        setInitialState();

        startMoneyMaking();
    }

    
    void Update()
    {
        if (ShouldTrackFoodBowl())
        {
            _agent.SetDestination(foodBowl.position);
        }

        else
        {
            _agent.SetDestination(player.position);
        }

        Vector2 velocity = _agent.velocity;
        // If velocity is large enough, rotate to face direction
        if (velocity.sqrMagnitude > 0.001f)
        {
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

    }

    /*
     *  Returns true if the goose is hungry and there is food in the bowl to eat,
     *  Or if the goose is currently eating
     */
    private bool ShouldTrackFoodBowl()
    {
        if ((FoodBowlManager.Instance.IsBowlFilled() && _hunger.IsGooseHungry()) ||
            _hunger.IsEating)
        {
            return true;
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cursor"))
        {
            Debug.Log("You Died");
            DeathStateTracker.SetState(DeathState.Touched);
            SceneManager.LoadScene("GameOver");
        }  
        else if (other.CompareTag("FoodBowl"))
        {
            Debug.Log("Food bowl hit.");
            _hunger.StopHungerDecay();
            _hunger.StartHungerReplenish();
        }
    }

    private void setInitialState()
    {
        switch (stateName)
        {
            case "Shiny" :
                changeState(State.Shiny);
                break;
            case "Clean" :
                changeState(State.Clean);
                break;
            case "Normal" :
                changeState(State.Normal);
                break;
            case "Dirty" :
                changeState(State.Dirty);
                break;
            case "Filthy" :
                changeState(State.Filthy);
                break;
            default :
                changeState(State.Normal);
                break;
        }
    }


    public void changeState(State newState)
    {
        this.cleanState = new CleanState(newState);
        gameObject.GetComponent<NavMeshAgent>().speed = this.cleanState.speed;
        
    }
    
    private void startMoneyMaking()
    {
        moneyRoutine ??= StartCoroutine(MakeMoney());
    }
    private IEnumerator MakeMoney()
    {

        while (true)
        {
            MoneyUi.Instance.updateMoney(cleanState.payout);
            yield return new WaitForSeconds(2);
        }
    }
}
