using UnityEngine;
using UnityEngine.AI;

public class GooseMovement : MonoBehaviour
{

    //this should be the cursor, unless something else is more urgent
    //such as food, water, a toy, etc. 
    public Transform player;
    public Transform foodBowl;
    
    private GooseHunger _hunger;
    
    NavMeshAgent _agent;
    
   
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _hunger = GetComponent<GooseHunger>();

        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
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
        }  
        else if (other.CompareTag("FoodBowl"))
        {
            Debug.Log("Food bowl hit.");
            _hunger.StopHungerDecay();
            _hunger.StartHungerReplenish();
        }
    }
}
