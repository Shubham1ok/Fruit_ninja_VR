using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    #region Singleton

    public static HealthManager instance;

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

    public Image healthbar;
    public float healthamount = 100f;
    public GameObject gameOverPanel;
    public FireFruits[] fireFruits;
    bool isfire;

    private void Start()
    {
        isfire = true;
    }
    private void Update()
    {
        if (isfire)
        {
            if (healthamount <= 0)
            {
                gameOverPanel.SetActive(true);
                OffFirefruits();
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

    public void TakeDamage(float damage)
    {
        healthamount -= damage;
        healthbar.fillAmount = healthamount / 100;
    }
    public void Healing(float healingAmount)
    {
        healthamount += healthamount;
        healthamount = Mathf.Clamp(healthamount, 0, 100);
        healthbar.fillAmount = healthamount / 100;
    }
}
