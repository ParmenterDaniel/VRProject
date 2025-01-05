using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    bool isFlickering = false;
    float timeDelay;
    public float maxDelay = 0.5f;
    public bool canflicker = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canflicker)
            return;
        
        if (!isFlickering)
        {
            StartCoroutine(Flicker());
        }
    }

    IEnumerator Flicker()
    {
        isFlickering=true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.01f, maxDelay);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(0.01f, maxDelay);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}
