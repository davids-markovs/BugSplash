using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPoison : MonoBehaviour
{
    public GameObject Player;
    public GameObject Poision;
    public int HP;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.GetComponent<PlayerHP>().health += HP;
            Destroy(gameObject);
            StartCoroutine(paraditMix());
        }   
    }
    IEnumerator paraditMix()
    {
        Vector3 position = transform.position;
        yield return new WaitForSeconds(10);
        Instantiate(Poision, position, Quaternion.identity);
    }
}
