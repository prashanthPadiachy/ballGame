using TMPro;
using UnityEngine;

public class collectibleManager : MonoBehaviour
{
    public static collectibleManager Instance;

    public int count = 0;
    public TMP_Text countText;

    private void Awake()
    {
        Instance = this;
        countText = GameObject.Find("scoreText").GetComponent<TMP_Text>();
        UpdateUI();

    }

    public void AddCollectible() {
        count++;
        UpdateUI();
    }

    public void UpdateUI() 
    {
        if (countText) 
        {
            countText.text = count.ToString()+" x";
        }
    }

}
