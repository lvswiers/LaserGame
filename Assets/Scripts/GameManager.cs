using UnityEngine;
using UnityEngine.SceneManagement;
using Domain;

public class GameManager: MonoBehaviour
{
    public void LoadScene(MenuButton button) {
        SceneManager.LoadScene(button.SceneName);
    }

    public void Exit() {
        Application.Quit();
    }
}