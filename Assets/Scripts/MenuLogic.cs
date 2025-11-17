using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    public void playButton()
    {
        SceneManager.LoadScene(1);
    }

    public void menuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
