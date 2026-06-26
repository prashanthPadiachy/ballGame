using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void QuitGame() {
        Application.Quit();
    }

    public void loadLevel1() 
    {
        SceneManager.LoadScene("Level1");
    }
    public void loadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void loadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void loadLevel4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void loadLevel5()
    {
        SceneManager.LoadScene("Level5");
    }
    public void loadLevel6()
    {
        SceneManager.LoadScene("Level6");
    }

}
