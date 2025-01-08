using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulHealth : MonoBehaviour
{
    public int health = 3;
    public GameObject respawnLoc;

    private void Update()
    {
        if(health <= 0)
        {
            //transform.parent.position = respawnLoc.transform.position;
            transform.position = respawnLoc.transform.position;
            health = 3;
        }
    }

    public void TakeDamage()
    {
        health--;
    }

}
