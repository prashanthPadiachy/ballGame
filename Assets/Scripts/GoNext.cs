using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNext : MonoBehaviour
{
    public uiManager levelUIManager;

    private void Start()
    {
        levelUIManager = GameObject.Find("Panels").GetComponent<uiManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            levelUIManager.LevelComplete();
        }
    }
}
