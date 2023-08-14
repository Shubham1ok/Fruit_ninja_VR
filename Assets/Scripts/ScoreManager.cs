using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    #region Singleton

    public static ScoreManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }

    #endregion
    public TextMeshProUGUI scoreText;
    public float score;
    public GameObject winPanel;
    public FireFruits[] fireFruits;

    bool isfire;

    private void Start()
    {
        isfire = true;
    }
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        if (isfire)
        {
            if (score > 200)
            {
                OffFirefruits();
                winPanel.SetActive(true);
                isfire = false;
            }
        }
           
    }
    
    void OffFirefruits()
    {

        for (int i = 0; i < fireFruits.Length; i++)
        {
            fireFruits[i].isFire = false;
        }
    }
}
