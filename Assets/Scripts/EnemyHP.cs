using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent nav;
    public float health;
    public float maxHealth;
    public GameObject healthBar;
    public Slider slider;
    public AnimationClip a_Death;
    public float a_deathSpeed = 2;
    public Animation anim;
    void Start()
    {
        maxHealth = 100;
        health = maxHealth;
        GetComponent<Animation>()[a_Death.name].speed = a_deathSpeed;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        slider.value = CalculateHealth();

    }
    void Update()
    {
        slider.value = CalculateHealth();

        if(health > maxHealth)
        {
            health = maxHealth;
        }
        if (health < 0 & anim[a_Death.name].enabled == false)
        {
           healthBar.SetActive(true);
        }
        if (health <= 0)
        {
            GetComponent<Animation>().CrossFade(a_Death.name);
            Destroy(gameObject);
        }
    }
    float CalculateHealth()
    {
        return health / maxHealth;
    }
}
