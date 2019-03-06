using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPoison : MonoBehaviour
{
    public GameObject Player;
    public int HP;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player.GetComponent<PlayerHP>().health += HP;
            Destroy(gameObject);
        }   
    }
}
