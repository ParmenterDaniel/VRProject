using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class damageEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GhoulHealth health = other.GetComponent<GhoulHealth>();

            if(health != null)
            {
                health.TakeDamage();
                Debug.Log("hit!");
            }

            Destroy(gameObject);
        }
    }
}
