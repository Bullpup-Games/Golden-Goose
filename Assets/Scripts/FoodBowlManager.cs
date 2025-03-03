using System;
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

    // Event gets invoked whenever the food amount changes
    public event Action<int, int> OnFoodChanged;

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

    private void Start()
    {
        OnFoodChanged?.Invoke(foodInBowl, maxFoodAllowed);
    }

    private void OnMouseDown()
    {
        AddFoodToBowl();
    }

    public void AddFoodToBowl()
    {
        if (foodInBowl < maxFoodAllowed)
        {
            foodInBowl++;
            OnFoodChanged?.Invoke(foodInBowl, maxFoodAllowed);
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
        OnFoodChanged?.Invoke(foodInBowl, maxFoodAllowed);
        return true;
    }
}
