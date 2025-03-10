using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayClicked);
        quitButton.onClick.AddListener(OnQuitClicked);
    }
    private void OnPlayClicked()
    {
        SceneManager.LoadScene("FoodTesting");
    }

    private void OnQuitClicked()
    {
        Application.Quit();
    }

}
