using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class insideHouse : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene ().name == "Inside")
                SceneManager.LoadScene("main");
           else
                SceneManager.LoadScene("Inside");
        }
    }
}
