using UnityEngine;
using UnityEngine.SceneManagement;
using Domain;

public class GameManager: MonoBehaviour
{

    public bool BuildMode = true;

    public void LoadScene(MenuButton button) {
        SceneManager.LoadScene(button.SceneName);
    }

    public void Exit() {
        Application.Quit();
    }

    public void ToggleBuildMode() {
        BuildMode = !BuildMode;
    }
}