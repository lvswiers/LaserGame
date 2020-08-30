using UnityEngine;
using UnityEngine.SceneManagement;
using Domain;

/// <summary>
/// Handles anything out of scope of a level, such as level loading and global exit.
/// </summary>
public class GameManager: MonoBehaviour
{
    public void LoadScene(MenuButton button) {
        SceneManager.LoadScene(button.SceneName);
    }

    public void Exit() {
        Application.Quit();
    }
}