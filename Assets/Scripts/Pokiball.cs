using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokiball : MonoBehaviour
{
    //Destroys objects on trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pokeball")
        {
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Flipper>().IncrementScore();
            Destroy(gameObject);
            Debug.Log("Pokeballs collected: " + other.gameObject.GetComponent<Flipper>().Scorecounter);
        }
    }
}
