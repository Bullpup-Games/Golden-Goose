using UnityEngine;
using UnityEngine.UI;

public class GooseHungerBarUI : MonoBehaviour
{
    [SerializeField] private GooseHunger gooseHunger;
    [SerializeField] private Image fillImage;

    private void Update()
    {
        if (gooseHunger is null || fillImage is null)
        {
            return;
        }

        // Calculate the normalized hunger (0 to 1)
        float fillValue = gooseHunger.currentHunger / gooseHunger.startingHunger;
        fillValue = Mathf.Clamp01(fillValue);

        // Set the fill amount of the UI Image, 190 is the max width
        float widthVal = fillValue * 190f;
        fillImage.rectTransform.sizeDelta = new Vector2(widthVal, 20);

        // Change the bar color based on thresholds
        if (fillValue > 0.66f)
        {
            fillImage.color = Color.green;
        }
        else if (fillValue > 0.33f)
        {
            fillImage.color = Color.yellow;
        }
        else
        {
            fillImage.color = Color.red;
        }
    }
}
