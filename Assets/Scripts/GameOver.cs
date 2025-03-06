using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayClicked);
        menuButton.onClick.AddListener(OnMenuClicked);
    }
    private void OnPlayClicked()
    {
        SceneManager.LoadScene("FoodTesting");
    }

    private void OnMenuClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Start()
    {
        Debug.Log($"Died From: {DeathStateTracker.GetState().ToString()}");

        DeathState s = DeathStateTracker.GetState();

        switch (s)
        {
            case DeathState.Alive:
                text.text = "You're... alive? How did you get here??? Bugs man.";
                break;
            case DeathState.Touched:
                text.text = "You touched the goose. :0";
                break;
            case DeathState.Starved:
                text.text = "Your goose starved. :(";
                break;
        }
    }
}
