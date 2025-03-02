using UnityEngine;

public class FoodBowlManager : MonoBehaviour
{
    public int foodInBowl = 0;
    public int maxFoodAllowed = 50;

    [Tooltip("The minimum amount of food the bowl can have and the snail will still track to it.")]
    public int minFoodToEat = 15;

    public static FoodBowlManager Instance => _instance;
    private static FoodBowlManager _instance;

    public Transform Transform;

    public bool IsBowlFilled() => foodInBowl >= minFoodToEat;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(_instance);
        }

        _instance = this;

        // Transform = gameObject.transform;
    }

    public void AddFoodToBowl()
    {
        if (foodInBowl < maxFoodAllowed)
        {
            foodInBowl++;
        }
        else
        {
            Debug.Log("The Food Bowl is full.");
        }
    }

    public bool RemoveFoodFromBowl(int amountToEat)
    {
        if (foodInBowl < amountToEat)
        {
            return false;
        }

        foodInBowl -= amountToEat;
        return true;
    }
}
