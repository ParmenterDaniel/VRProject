using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerTriggers : MonoBehaviour
{
    // Start is called before the first frame update
    public GameVariables variables;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        variables.hide();
        Debug.Log(variables.isHiding);
        Debug.Log("In locker!");
    }
    public void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        variables.hide();
        Debug.Log(variables.isHiding);
    
    }
}
