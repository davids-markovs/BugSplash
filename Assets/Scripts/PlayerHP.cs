using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    void Start()
    {
        maxHealth = 100;
        health = maxHealth;
    }
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
        if(health > maxHealth)
        {
            health = 100;
        }
        if (health < 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
