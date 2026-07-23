using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider vol;


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

    public void setVolume()
    {
        if (vol == null) return;
        float volume = vol.value;
        mixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }

    private void Start()
    {
        setVolume();
    }
}
