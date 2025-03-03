using UnityEngine;
using TMPro;

public class FoodBowlDisplayUI : MonoBehaviour
{
    [SerializeField] private FoodBowlManager foodBowlManager;
    [SerializeField] private TMP_Text foodText;

    private void Awake()
    {
        if (foodBowlManager == null)
            foodBowlManager = FindObjectOfType<FoodBowlManager>();
    }

    private void OnEnable()
    {
        if (foodBowlManager != null)
            foodBowlManager.OnFoodChanged += UpdateFoodDisplay;
    }

    private void OnDisable()
    {
        if (foodBowlManager != null)
            foodBowlManager.OnFoodChanged -= UpdateFoodDisplay;
    }

    private void UpdateFoodDisplay(int currentFood, int maxFood)
    {
        if (currentFood <= 9)
        {
            foodText.text = $"0{currentFood}/{maxFood}";
        }
        else
        {
            foodText.text = $"{currentFood}/{maxFood}";
        }
        
    }
}
