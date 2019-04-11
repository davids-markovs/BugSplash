using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class EnemyHP : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent nav;
    public float health;
    public float maxHealth;
    public int number;
    public GameObject healthBar;
    public Slider slider;
    public AnimationClip a_Death;
    public float a_deathSpeed = 2;
    public Animation anim;
    public Component enemyCollider;
    public GameObject item;
    public GameObject enemy;
    public bool enemyDestroyed = false;
    public List<Transform> items = new List<Transform>();
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
        number = Random.Range(1, 255);
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
            
            StartCoroutine("Fade");
            enemyDestroyed = true;
            Destroy(gameObject, 1.0f);
        }
    }
    float CalculateHealth()
    {
        return health / maxHealth;
    }
    IEnumerator Fade()
    {
        GetComponent<Animation>().CrossFade(a_Death.name);
        yield return new WaitForSeconds(3.0f);
    }

   // Update is called once per frame
    void LateUpdate()
    {
        if (enemyDestroyed)
        {
            Vector3 position = transform.position;
            // Clone the objects that are "in" the box.
                if (item != null && number<100)
                {
                    
                    // Add code here to change the position slightly
                    // so the items are scattered a little bit.
                    Instantiate(item, position, Quaternion.identity);
                }

            // Get rid of the box.
            Destroy(gameObject);
        }
    }
}
